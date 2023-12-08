using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Loadgamecontroller : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private CinemachineConfiner cinemachineConfiner;
    void Start()
    {
        GetComponent<Saveandloadgame>().loadgamedate();

        player.transform.position = Globalcalls.playeresetpoint;

        cinemachineConfiner.m_BoundingShape2D = Globalcalls.boundscolliderobj.GetComponent<PolygonCollider2D>();
        cinemachineVirtualCamera.m_Lens.OrthographicSize = Globalcalls.savecameradistance;
    }
}
