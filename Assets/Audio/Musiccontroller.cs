using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiccontroller : MonoBehaviour
{
    private AudioSource audiosource;
    private float targetvolume = 0.7f;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = 0f;
        StartCoroutine(fadeinvolume(2f, 0));          
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
        float targetVolume = 0.1f;
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
            StartCoroutine(fadeinvolume(fadeinspeed, 0.1f));
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
}
