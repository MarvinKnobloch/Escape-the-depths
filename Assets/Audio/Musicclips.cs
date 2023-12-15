using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Songs/Song")]
public class Musicclips : ScriptableObject
{
    [SerializeField] public AudioClip song;
    [SerializeField] public float volume;
}
