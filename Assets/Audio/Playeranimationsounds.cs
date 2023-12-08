using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranimationsounds : MonoBehaviour
{
    [SerializeField] private Playersounds playersounds;
    [SerializeField] private Playersounds playerfootsounds;

    public void playdashsound() => playersounds.playdash();
    public void playfoot1() => playerfootsounds.playfootstep1();
    public void playfoot2() => playerfootsounds.playfootstep2();
    public void playjump() => playersounds.playjump();
    public void playwhipsound() => playersounds.playwhip();
}
