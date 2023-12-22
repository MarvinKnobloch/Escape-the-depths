using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class Menucontroller : MonoBehaviour
{
    private Controlls controlls;

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuoverview;
    [SerializeField] private GameObject newgameconfirm;
    [SerializeField] private GameObject pausewindow;
    [SerializeField] private AudioMixer audiomixer;
    [SerializeField] private AudioSource audioSource;
    private string gamevalue = "gamevolume";
    private float normaltimescale;
    private float normalfixeddeltatime;

    public static event Action tutorialupdate;

    [SerializeField] private Menusoundcontroller menusoundcontroller;


    private void Awake()
    {
        controlls = Keybindinputmanager.inputActions;
        normaltimescale = Time.timeScale;
        normalfixeddeltatime = Time.fixedDeltaTime;
        Globalcalls.gameispaused = false;
    }
    private void OnEnable()
    {
        controlls.Enable();
    }
    private void Update()
    {
        if (controlls.Menu.Openmenu.WasPerformedThisFrame() && Globalcalls.gameispaused == false)
        {
            Globalcalls.gameispaused = true;
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
            newgameconfirm.SetActive(false);
            menu.SetActive(true);
            menuoverview.SetActive(true);
            menusoundcontroller.playmenusound1();
        }
        else if(controlls.Menu.Openmenu.WasPerformedThisFrame() && newgameconfirm.activeSelf == true)
        {
            newgameconfirm.SetActive(false);
        }
        else if(controlls.Menu.Openmenu.WasPerformedThisFrame() && menuoverview.activeSelf == true && menu.activeSelf == true)     //menu.activeSelf == true weil menuoverview als aktiv gilt selbst wenn der parent disabled ist
        {
            closemenu();
        }
        if(controlls.Player.Pause.WasPerformedThisFrame() && Globalcalls.gameispaused == false)
        {
            Globalcalls.gameispaused = true;
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
            pausewindow.SetActive(true);

            if (PlayerPrefs.GetFloat(gamevalue + "ismuted") == 0) audiomixer.SetFloat(gamevalue, -80);
            //StartCoroutine("pauseaudio");
        }
        else if(controlls.Player.Pause.WasPerformedThisFrame() && pausewindow.activeSelf == true || controlls.Menu.Openmenu.WasPerformedThisFrame() && pausewindow.activeSelf == true)
        {
            //audioSource.UnPause();
            StartCoroutine("unpausegame");
        }
    }
    IEnumerator pauseaudio()
    {
        yield return null;
        if (Globalcalls.gameispaused == true) audioSource.Pause();
    }
    IEnumerator unpausegame()
    {
        yield return null;
        pausewindow.SetActive(false);
        Globalcalls.gameispaused = false;
        Time.timeScale = normaltimescale;
        Time.fixedDeltaTime = normalfixeddeltatime;


        if (PlayerPrefs.GetFloat(gamevalue + "ismuted") == 0)
        {
            audiomixer.SetFloat(gamevalue, PlayerPrefs.GetFloat(gamevalue));
            bool gotvalue = audiomixer.GetFloat(gamevalue, out float soundvalue);            //verhindert das der audiomixer mehr als 0db haben kann
            if (gotvalue == true)
            {
                if (soundvalue > 0)
                {
                    Debug.Log(soundvalue);
                    audiomixer.SetFloat(gamevalue, 0);
                }
            }
        }
        menusoundcontroller.playmenusound1();
    }
    public void closemenu()
    {
        tutorialupdate?.Invoke();
        menuoverview.SetActive(false);
        Globalcalls.gameispaused = false;
        Time.timeScale = normaltimescale;
        Time.fixedDeltaTime = normalfixeddeltatime;
        if(menu.activeSelf == true) menusoundcontroller.playmenusound1();
        menu.SetActive(false);
        
    }
}
