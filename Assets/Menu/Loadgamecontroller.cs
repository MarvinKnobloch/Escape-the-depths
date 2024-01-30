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

    [SerializeField] private bool setloadposi;
    [SerializeField] private GameObject loadposi;
    [SerializeField] private int section;
    [SerializeField] private int camdistance;

    [SerializeField] private Gametimer gametimer;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            if (PlayerPrefs.GetInt("firstgamestart") == 1)               //wenn das game zum aller ersten mal gestartet wird und der wert noch nicht geändert worden ist
            {
                Globalcalls.playeresetpoint = new Vector3(PlayerPrefs.GetFloat("playerxposi"), PlayerPrefs.GetFloat("playeryposi"), 0);
                player.transform.position = Globalcalls.playeresetpoint;

                Globalcalls.currentsection = PlayerPrefs.GetInt("sectionnumber");
                Globalcalls.boundscolliderobj = sections[Globalcalls.currentsection];

                cinemachineConfiner.m_BoundingShape2D = sections[Globalcalls.currentsection].GetComponent<PolygonCollider2D>();
                musiccontroller.musiconstart(sections[Globalcalls.currentsection].GetComponent<Sectionmusic>().songs);
                if (Globalcalls.currentsection > 1) Globalcalls.candash = true;
                else Globalcalls.candash = false;

                Globalcalls.savecameradistance = PlayerPrefs.GetInt("cameradistance");
                cinemachineVirtualCamera.m_Lens.OrthographicSize = Globalcalls.savecameradistance;

                Globalcalls.currentgametime = PlayerPrefs.GetInt("gametime");
                gametimer.gametimeupdate();
            }
            else 
            {
                PlayerPrefs.SetInt("firstgamestart", 1);
                newgameonweb();
            }
        }
        else
        {
            if (loadgame == true)
            {
                GetComponent<Saveandloadgame>().loadgamedate();

                if (Globalcalls.couldnotloaddata == false)
                {
                    player.transform.position = Globalcalls.playeresetpoint;

                    cinemachineConfiner.m_BoundingShape2D = sections[Globalcalls.currentsection].GetComponent<PolygonCollider2D>();
                    Globalcalls.boundscolliderobj = sections[Globalcalls.currentsection];
                    cinemachineVirtualCamera.m_Lens.OrthographicSize = Globalcalls.savecameradistance;
                    musiccontroller.musiconstart(sections[Globalcalls.currentsection].GetComponent<Sectionmusic>().songs);
                    gametimer.gametimeupdate();
                }
                else
                {
                    newgameonnonewebplatform();
                }
            }
            else if (setloadposi == true)
            {
                player.transform.position = loadposi.transform.position + Vector3.up;
                Globalcalls.playeresetpoint = loadposi.transform.position + Vector3.up;

                Globalcalls.currentsection = section - 1;
                Globalcalls.boundscolliderobj = sections[Globalcalls.currentsection];

                cinemachineConfiner.m_BoundingShape2D = sections[Globalcalls.currentsection].GetComponent<PolygonCollider2D>();
                musiccontroller.musiconstart(sections[Globalcalls.currentsection].GetComponent<Sectionmusic>().songs);
                if (Globalcalls.currentsection > 1) Globalcalls.candash = true;
                else Globalcalls.candash = false;

                Globalcalls.savecameradistance = camdistance;
                cinemachineVirtualCamera.m_Lens.OrthographicSize = Globalcalls.savecameradistance;
            }
            else
            {
                Globalcalls.savecameradistance = (int)cinemachineVirtualCamera.m_Lens.OrthographicSize;
                musiccontroller.musiconstart(sections[0].GetComponent<Sectionmusic>().songs);
            }
        }
        QualitySettings.vSyncCount = 1;
    }
    private void newgameonnonewebplatform()
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

        musiccontroller.choosesong(sections[0].GetComponent<Sectionmusic>().songs);

        Globalcalls.currentgametime = 0;
        gametimer.gametimeupdate();

        Globalcalls.candash = false;

        GetComponent<Saveandloadgame>().savegamedata();
    }

    private void newgameonweb()
    {
        player.transform.position = new Vector3(-5, 1, 0);
        PlayerPrefs.SetFloat("playerxposi", player.transform.position.x);
        PlayerPrefs.SetFloat("playeryposi", player.transform.position.y);
        Globalcalls.playeresetpoint = player.transform.position;

        player.GetComponent<Playerstatemachine>().resetplayer();

        cinemachineConfiner.m_BoundingShape2D = sections[0].GetComponent<PolygonCollider2D>();
        Globalcalls.boundscolliderobj = sections[0];
        Globalcalls.currentsection = 0;
        PlayerPrefs.SetInt("sectionnumber", Globalcalls.currentsection);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = 7;
        Globalcalls.savecameradistance = 7;
        PlayerPrefs.SetInt("cameradistance", Globalcalls.savecameradistance);

        GetComponent<Menucontroller>().closemenu();

        musiccontroller.choosesong(sections[0].GetComponent<Sectionmusic>().songs);

        Globalcalls.currentgametime = 0;
        PlayerPrefs.SetInt("gametime", 0);
        gametimer.gametimeupdate();

        Globalcalls.candash = false;
        PlayerPrefs.SetInt("candash", 0);
    }
    public void newgamebutton()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer) newgameonweb();
        else newgameonnonewebplatform();
    }
}
