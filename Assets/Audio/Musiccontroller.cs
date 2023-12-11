using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiccontroller : MonoBehaviour
{
    private AudioSource audiosource;
    private float targetvolume;

    [SerializeField] private AudioClip[] songs;
    [SerializeField] private float[] songvolume;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = 0f;       
    }
    public void musiconstart(AudioClip song)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i] == song)
            {
                audiosource.clip = song;
                targetvolume = songvolume[i];
                audiosource.Play();
                StartCoroutine(fadeinvolume(2f, 0));
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
    public void choosesong(AudioClip song)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            if(songs[i] == song)
            {
                startfadeout(song, 0, 1, 1, songvolume[i]);
                Globalcalls.zonemusic = i;
                break;
            }
        }
    }
}
