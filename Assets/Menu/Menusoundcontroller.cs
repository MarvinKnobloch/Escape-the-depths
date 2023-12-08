using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menusoundcontroller : MonoBehaviour
{
    private AudioSource audiosource;
    [SerializeField] private AudioClip menubuttonsound;
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void playmenusound1()
    {
        audiosource.clip = menubuttonsound;
        audiosource.volume = 0.5f;
        audiosource.Play();
    }
    public void playmenubuttonsound()
    {
        if (audiosource != null)               //falls der awake call zu spät kommt
        {
            playmenusound1();
        }
        else
        {
            audiosource = GetComponent<AudioSource>();
            playmenusound1();
        }
    }
}


