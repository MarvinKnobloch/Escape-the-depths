using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertdata
{
    public Vector3 playerposition;
    public int sectionnumber;
    public int cameradistance;
    public bool candash;
    public int currentzonemusic;
    public float musicvolume;

    public void savedatainscript()
    {
        playerposition = Globalcalls.playeresetpoint;
        sectionnumber = Globalcalls.currentsection;
        cameradistance = Globalcalls.savecameradistance;
        candash = Globalcalls.candash;
        currentzonemusic = Globalcalls.zonemusic;
    }
    public void loaddata()
    {
        Globalcalls.playeresetpoint = playerposition;
        Globalcalls.currentsection = sectionnumber;
        Globalcalls.savecameradistance = cameradistance;
        Globalcalls.candash = candash;
        Globalcalls.zonemusic = currentzonemusic;
    }
}
