using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volumecontroller : MonoBehaviour
{
    [SerializeField] private AudioMixer audiomixer;
    [SerializeField] private string gamevolume;
    [SerializeField] private string musicvolume;
    [SerializeField] private string soundeffecsvolume;
    void Start()
    {
        if (PlayerPrefs.GetInt("audiohasbeenchange") == 0)
        {
            PlayerPrefs.SetFloat(gamevolume, -10);
            audiomixer.SetFloat(gamevolume, PlayerPrefs.GetFloat(gamevolume));
            PlayerPrefs.SetFloat(musicvolume, -15);
            audiomixer.SetFloat(musicvolume, PlayerPrefs.GetFloat(musicvolume));
            PlayerPrefs.SetFloat(soundeffecsvolume, 5);
            audiomixer.SetFloat(soundeffecsvolume, PlayerPrefs.GetFloat(soundeffecsvolume));
        }
        else
        {
            setvolume(gamevolume, 0);
            setvolume(musicvolume, 0);
            setvolume(soundeffecsvolume, 10);
        }
    }
    private void setvolume(string volumename, float maxdb)
    {
        if (PlayerPrefs.GetFloat(volumename + "ismuted") == 1)
        {
            audiomixer.SetFloat(volumename, -80);
        }
        else
        {
            audiomixer.SetFloat(volumename, PlayerPrefs.GetFloat(volumename));
            bool gotvalue = audiomixer.GetFloat(volumename, out float soundvalue);
            if (gotvalue == true)
            {
                if (soundvalue > maxdb)
                {
                    audiomixer.SetFloat(volumename, maxdb);
                }
            }
        }
    }
}
