using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Setresetpoint : MonoBehaviour
{
    private Vector3 resetposi;

    [SerializeField] private GameObject sectionobj;
    private int sectionnumber;
    [SerializeField] private int camdistance;
    private Saveandloadgame saveandloadgame;

    private void Awake()
    {
        sectionobj = GetComponentInParent<Sectioncamera>().sectiongameobj;
        sectionnumber = GetComponentInParent<Sectioncamera>().sectionnumber - 1;
        camdistance = GetComponentInParent<Sectioncamera>().cameradistance;
        resetposi = transform.GetChild(0).transform.position;

        saveandloadgame = GetComponent<Saveandloadgame>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Globalcalls.currentgametime = collision.GetComponent<Playerstatemachine>().gametimer.currentgametime;
            Globalcalls.playeresetpoint = resetposi;
            Globalcalls.currentsection = sectionnumber;
            Globalcalls.boundscolliderobj = sectionobj;
            Globalcalls.savecameradistance = camdistance;
            saveandloadgame.savegameonplayerenter();
        }          
    }
}
