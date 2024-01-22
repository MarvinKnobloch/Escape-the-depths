using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Gametimer : MonoBehaviour
{
    [NonSerialized] public TextMeshProUGUI gametimertext;
    private float gametime;
    public int currentgametime;
    private void Awake()
    {
        gametimertext = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        gametime += Time.deltaTime;
        if(gametime >= 1)
        {
            gametime -= 1;
            currentgametime += 1;
            int seconds = Mathf.FloorToInt(currentgametime % 60);
            int minutes = Mathf.FloorToInt(currentgametime / 60 % 60);
            int hours = Mathf.FloorToInt(currentgametime / 3600);
            gametimertext.text = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }
    public void gametimeupdate()
    {
        currentgametime = Globalcalls.currentgametime;
        int seconds = Mathf.FloorToInt(currentgametime % 60);
        int minutes = Mathf.FloorToInt(currentgametime / 60 % 60);
        int hours = Mathf.FloorToInt(currentgametime / 3600);
        gametimertext.text = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
