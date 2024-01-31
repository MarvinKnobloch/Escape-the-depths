using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Musiccontroller : MonoBehaviour
{
    public AudioSource audiosource;
    private float targetvolume;

    [NonSerialized] public AudioClip currentsong;

    private List<AudioClip> songlist = new List<AudioClip>();
    private int currentsongnumber;

    public Musicclips[] clips;

    public float disabletimer;

    private DateTime startdate;
    private DateTime currentdate;
    private float seconds;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = 0f;
    }
    public void musiconstart(AudioClip[] song)
    {
        StopAllCoroutines();
        songlist.Clear();
        currentsongnumber = 0;
        for (int i = 0; i < song.Length; i++)
        {
            songlist.Add(song[i]);
        }
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].song == song[0])
            {
                audiosource.clip = song[0];
                //audiosource.time = 150f;
                audiosource.Play();
                targetvolume = clips[i].volume;

                StartCoroutine(fadeinvolume(3, 0));
                StartCoroutine("playnextsong");
                break;
            }
        }
    }
    public void startfadeout(AudioClip song, float cliptime, float fadeoutspeed, float fadeinspeed, float endvolume)
    {
        targetvolume = endvolume;
        StopAllCoroutines();
        StartCoroutine(fadeoutvolume(song, cliptime, fadeoutspeed, fadeinspeed));
    }
    public IEnumerator fadeoutvolume(AudioClip song, float cliptime, float fadeoutspeed, float fadeinspeed)
    {
        //currentsong = song;
        //float duration = fadeoutspeed;
        //float currentTime = 0;
        //float start = audiosource.volume;
        //float targetVolume = 0;
        //while (currentTime < duration)
        //{
        //    currentTime += Time.deltaTime;
        //    audiosource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
        //    yield return null;
        //}
        currentsong = song;
        float duration = fadeoutspeed;
        float start = audiosource.volume;
        float targetVolume = 0;
        startdate = DateTime.Now;
        disabletimer = 0f;
        while (disabletimer < duration)
        {
            currentdate = DateTime.Now;
            seconds = currentdate.Ticks - startdate.Ticks;
            disabletimer = seconds * 0.0000001f;
            audiosource.volume = Mathf.Lerp(start, targetVolume, disabletimer / duration);
            yield return null;
        }
        if (song != null)
        {
            audiosource.clip = song;
            audiosource.time = cliptime;
            audiosource.Play();
            StartCoroutine(fadeinvolume(fadeinspeed, 0));
            StartCoroutine("playnextsong");
        }
        yield break;
    }
    public IEnumerator fadeinvolume(float fadeinspeed, float startvolume)
    {
        //currentsong = audiosource.clip;
        //float duration = fadeinspeed;
        //float currentTime = 0;
        //float start = startvolume;
        //while (currentTime < duration)
        //{
        //    currentTime += Time.deltaTime;
        //    audiosource.volume = Mathf.Lerp(start, targetvolume, currentTime / duration);
        //    yield return null;
        //}
        currentsong = audiosource.clip;
        float duration = fadeinspeed;
        float start = startvolume;
        startdate = DateTime.Now;
        disabletimer = 0f;
        while (disabletimer < duration)
        {
            currentdate = DateTime.Now;
            seconds = currentdate.Ticks - startdate.Ticks;
            disabletimer = seconds * 0.0000001f;
            audiosource.volume = Mathf.Lerp(start, targetvolume, disabletimer / duration);
            yield return null;
        }
        yield break;
    }
    public IEnumerator playnextsong()
    {
        yield return new WaitForSecondsRealtime(audiosource.clip.length - 2f);//(audiosource.clip.length - 3f);
        if (currentsongnumber >= songlist.Count -1)
        {
            currentsongnumber = 0;
        }
        else currentsongnumber++;

        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].song == songlist[currentsongnumber])
            {
                startfadeout(songlist[currentsongnumber], 0, 3f, 3, clips[i].volume);
                break;
            }
        }

    }
    public void choosesong(AudioClip[] song)
    {
        StopAllCoroutines();
        songlist.Clear();
        currentsongnumber = 0;
        for (int i = 0; i < song.Length; i++)
        {
            songlist.Add(song[i]);
        }

        for (int i = 0; i < clips.Length; i++)
        {
            if(clips[i].song == song[0])
            {
                startfadeout(song[0], 0, 3f, 3, clips[i].volume);
                break;
            }
        }
    }
    //void OnApplicationFocus(bool hasFocus)
    //{
    //    isPaused = !hasFocus;
    //    pauseupdate();
    //}

    //void OnApplicationPause(bool pauseStatus)
    //{
    //    isPaused = pauseStatus;
    //    pauseupdate();
    //}
    //private void pauseupdate()
    //{
    //    if (isPaused == true) audiosource.Pause();
    //    else audiosource.UnPause();
    //}
}
