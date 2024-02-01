using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Menucontroller : MonoBehaviour
{
    private Controlls controls;

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuoverview;
    [SerializeField] private GameObject activatecontrollermenucursor;
    [SerializeField] private GameObject controllermenucursor;
    [SerializeField] private GameObject newgameconfirm;
    [SerializeField] private GameObject pausewindow;
    [SerializeField] private GameObject scoutobj;
    [SerializeField] private AudioMixer audiomixer;
    [SerializeField] private AudioSource audioSource;
    private string gamevalue = "gamevolume";
    private float normaltimescale;
    private float normalfixeddeltatime;

    public static event Action tutorialupdate;

    [SerializeField] private Menusoundcontroller menusoundcontroller;

    [SerializeField] private string screenshotpath;

    private void Awake()
    {
        controls = Keybindinputmanager.inputActions;
        normaltimescale = Time.timeScale;
        normalfixeddeltatime = Time.fixedDeltaTime;
        Globalcalls.gameispaused = false;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void Update()
    {
        if (controls.Menu.Openmenu.WasPerformedThisFrame())                       // || Input.GetButtonDown("Start"))
        {
            if (Globalcalls.gameispaused == false && scoutobj.activeSelf == false)
            {
                Globalcalls.gameispaused = true;
                Time.timeScale = 0f;
                Time.fixedDeltaTime = 0f;
                newgameconfirm.SetActive(false);
                menu.SetActive(true);
                menuoverview.SetActive(true);
                activatecontrollermenucursor.SetActive(true);
                menusoundcontroller.playmenusound1();
            }
            else if (newgameconfirm.activeSelf == true)
            {
                newgameconfirm.SetActive(false);
            }
            else if (menuoverview.activeSelf == true && menu.activeSelf == true)     //menu.activeSelf == true weil menuoverview als aktiv gilt selbst wenn der parent disabled ist
            {
                closemenu();
            }
        }
        if(Globalcalls.webglbuild == false)
        {
            if (controls.Player.Pause.WasPerformedThisFrame() || controls.Player.Controllerpause.WasPerformedThisFrame()) handlepausebuttonpress();
        }
        else if (controls.Player.Pause.WasPerformedThisFrame() || Input.GetButtonDown("Pause")) handlepausebuttonpress();
        //if (controls.Player.Pause.WasPerformedThisFrame() || controls.Player.Controllerpause.WasPerformedThisFrame()) //Input.GetButtonDown("Pause")) //controls.Player.Controllerpause.WasPerformedThisFrame())
        if (controls.Menu.Openmenu.WasPerformedThisFrame())                          // || Input.GetButtonDown("Start"))
        {
            if (pausewindow.activeSelf == true) StartCoroutine("unpausegame");
        }
        if (controls.Menu.Nodamage.WasPerformedThisFrame())
        {
            Globalcalls.nodmg = !Globalcalls.nodmg;
        }
    }
    private void handlepausebuttonpress()
    {
        if (Globalcalls.gameispaused == false && scoutobj.activeSelf == false)
        {
            Globalcalls.gameispaused = true;
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
            pausewindow.SetActive(true);

            if (PlayerPrefs.GetFloat(gamevalue + "ismuted") == 0) audiomixer.SetFloat(gamevalue, -80);
            //StartCoroutine("pauseaudio");
        }
        else if (pausewindow.activeSelf == true) StartCoroutine("unpausegame");
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
        controllermenucursor.SetActive(false);
        menuoverview.SetActive(false);
        Globalcalls.gameispaused = false;
        Time.timeScale = normaltimescale;
        Time.fixedDeltaTime = normalfixeddeltatime;
        if(menu.activeSelf == true) menusoundcontroller.playmenusound1();
        menu.SetActive(false);
        
    }
}



//#if UNITY_EDITOR
//        if (controls.Menu.Screenshot.WasPerformedThisFrame())
//        {

//            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
//            date = date.Replace("/", ".");
//            date = date.Replace(" ", "_");
//            date = date.Replace(":", ".");
//            string path = screenshotpath + "Escape the depths " + date + ".png";

//            ScreenCapture.CaptureScreenshot(path);
//        }
//#endif
