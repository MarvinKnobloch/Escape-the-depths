using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Loadgamecontroller : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private CinemachineConfiner cinemachineConfiner;

    [SerializeField] private GameObject section1;
    void Start()
    {
        GetComponent<Saveandloadgame>().loadgamedate();

        if(Globalcalls.couldnotloaddata == false)
        {
            player.transform.position = Globalcalls.playeresetpoint;

            cinemachineConfiner.m_BoundingShape2D = Globalcalls.boundscolliderobj.GetComponent<PolygonCollider2D>();
            cinemachineVirtualCamera.m_Lens.OrthographicSize = Globalcalls.savecameradistance;
        }
        else
        {
            newgame();
        }
    }
    public void newgame() 
    {
        Globalcalls.couldnotloaddata = false;
        player.transform.position = new Vector3(-5, 1, 0);
        Globalcalls.playeresetpoint = player.transform.position;

        cinemachineConfiner.m_BoundingShape2D = section1.GetComponent<PolygonCollider2D>();
        Globalcalls.boundscolliderobj = section1;

        cinemachineVirtualCamera.m_Lens.OrthographicSize = 7;
        Globalcalls.savecameradistance = 7;

        GetComponent<Menucontroller>().closemenu();
    }
}
