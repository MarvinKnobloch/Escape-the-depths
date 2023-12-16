using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersounds : MonoBehaviour
{
    private AudioSource audiosource;

    [SerializeField] private AudioClip footstep1;
    [SerializeField] private AudioClip footstep2;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip dash;
    [SerializeField] private AudioClip gravityswitch;
    [SerializeField] private AudioClip whip;
    [SerializeField] private AudioClip memory;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void playsound(AudioClip newclip, float volume)
    {
        audiosource.clip = newclip;
        audiosource.volume = volume;
        audiosource.Play();
    }

    public void playfootstep1() => playsound(footstep1, 0.2f);
    public void playfootstep2() => playsound(footstep2, 0.2f);
    public void playjump() => playsound(jump, 0.7f);
    public void playdash() => playsound(dash, 0.4f);
    public void playgravityswitch() => playsound(gravityswitch, 0.4f);
    public void playwhip() => playsound(whip, 0.35f);
    public void playmemory() => playsound(memory, 0.2f);
}
