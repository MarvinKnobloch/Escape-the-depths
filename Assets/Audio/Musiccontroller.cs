using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiccontroller : MonoBehaviour
{
    public AudioSource audiosource;
    private float targetvolume;

    [SerializeField] private Musicclips[] clips;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = 0f;       
    }
    public void musiconstart(AudioClip song)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].song == song)
            {
                audiosource.clip = song;
                //audiosource.time = 440f;
                audiosource.Play();
                targetvolume = clips[i].volume;

                StartCoroutine(fadeinvolume(3, 0));
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
        float duration = fadeoutspeed;
        float currentTime = 0;
        float start = audiosource.volume;
        float targetVolume = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audiosource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        if (song != null)
        {
            audiosource.clip = song;
            audiosource.time = cliptime;
            audiosource.Play();
            StartCoroutine(fadeinvolume(fadeinspeed, 0));
        }
        yield break;
    }
    public IEnumerator fadeinvolume(float fadeinspeed, float startvolume)
    {
        float duration = fadeinspeed;
        float currentTime = 0;
        float start = startvolume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audiosource.volume = Mathf.Lerp(start, targetvolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
    public void choosesong(AudioClip song)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if(clips[i].song == song)
            {
                startfadeout(song, 0, 2.5f, 3, clips[i].volume);
                break;
            }
        }
    }
}
