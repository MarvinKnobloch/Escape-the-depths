using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Loadgamecontroller : MonoBehaviour
{
    [SerializeField] private bool loadgame;
    [SerializeField] private GameObject player;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private CinemachineConfiner cinemachineConfiner;

    [SerializeField] private GameObject[] sections;

    [SerializeField] private Musiccontroller musiccontroller;
    void Start()
    {
        if(loadgame == true)
        {
            GetComponent<Saveandloadgame>().loadgamedate();

            if (Globalcalls.couldnotloaddata == false)
            {
                player.transform.position = Globalcalls.playeresetpoint;

                cinemachineConfiner.m_BoundingShape2D = sections[Globalcalls.currentsection].GetComponent<PolygonCollider2D>();
                Globalcalls.boundscolliderobj = sections[Globalcalls.currentsection];
                cinemachineVirtualCamera.m_Lens.OrthographicSize = Globalcalls.savecameradistance;
                musiccontroller.musiconstart(sections[Globalcalls.currentsection].GetComponent<Sectionmusic>().song);
            }
            else
            {
                newgame();
            }
        }
        else
        {
            Globalcalls.savecameradistance = (int)cinemachineVirtualCamera.m_Lens.OrthographicSize;
            musiccontroller.musiconstart(sections[0].GetComponent<Sectionmusic>().song);
        }
        QualitySettings.vSyncCount = 1;
    }
    public void newgame()
    {
        Globalcalls.couldnotloaddata = false;
        player.transform.position = new Vector3(-5, 1, 0);
        Globalcalls.playeresetpoint = player.transform.position;

        player.GetComponent<Playerstatemachine>().resetplayer();

        cinemachineConfiner.m_BoundingShape2D = sections[0].GetComponent<PolygonCollider2D>();
        Globalcalls.boundscolliderobj = sections[0];
        Globalcalls.currentsection = 0;

        cinemachineVirtualCamera.m_Lens.OrthographicSize = 7;
        Globalcalls.savecameradistance = 7;

        GetComponent<Menucontroller>().closemenu();

        musiccontroller.choosesong(sections[0].GetComponent<Sectionmusic>().song);

        Globalcalls.candash = false;

        GetComponent<Saveandloadgame>().savegamedata();
    }
}
