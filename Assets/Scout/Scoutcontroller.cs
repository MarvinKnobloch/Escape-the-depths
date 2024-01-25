using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Scoutcontroller : MonoBehaviour
{
    private Controlls controls;
    [SerializeField] private GameObject scoutobj;
    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject scouttarget;
    [SerializeField] private GameObject player;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtual;
    [SerializeField] private Camera maincam;

    private void Awake()
    {
        controls = Keybindinputmanager.inputActions;
    }
    void Update()
    {
        if (controls.Player.Scoutmode.WasPerformedThisFrame() || Input.GetButtonDown("Scout")) //controls.Player.Controllerscoutmode.WasPerformedThisFrame())
        {
            if(menu.activeSelf == false)
            {
                if (Globalcalls.gameispaused == false && scoutobj.activeSelf == false)
                {
                    Globalcalls.dontreadplayerinputs = true;
                    scoutobj.SetActive(true);
                    scouttarget.transform.position = new Vector3(maincam.transform.position.x, maincam.transform.position.y, 0);
                    cinemachineVirtual.Follow = scouttarget.transform;
                    cinemachineVirtual.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneWidth = 0;
                    cinemachineVirtual.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneHeight = 0;
                    return;
                }
                else if (scoutobj.activeSelf == true) StartCoroutine("closescoutmode");
            }
        }
        if (controls.Menu.Openmenu.WasPerformedThisFrame())
        {
            if (menu.activeSelf == false && scoutobj.activeSelf == true) StartCoroutine("closescoutmode");
        }
    }
    IEnumerator closescoutmode()
    {
        yield return null;
        Globalcalls.gameispaused = false;
        scoutobj.SetActive(false);
        cinemachineVirtual.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneWidth = 0.8f;
        cinemachineVirtual.GetCinemachineComponent<CinemachineFramingTransposer>().m_SoftZoneHeight = 0.8f;
        cinemachineVirtual.Follow = player.transform;
        Globalcalls.dontreadplayerinputs = false;
    }
}
