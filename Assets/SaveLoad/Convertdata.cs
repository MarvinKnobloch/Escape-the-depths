using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertdata
{
    public Vector3 playerposition;
    public GameObject camerasection;
    public int cameradistance;
    public bool candash;
    public int currentzonemusic;

    public void savedatainscript()
    {
        playerposition = Globalcalls.playeresetpoint;
        camerasection = Globalcalls.boundscolliderobj;
        cameradistance = Globalcalls.savecameradistance;
        candash = Globalcalls.candash;
        currentzonemusic = Globalcalls.zonemusic;
    }
    public void loaddata()
    {
        Globalcalls.playeresetpoint = playerposition;
        Globalcalls.boundscolliderobj = camerasection;
        Globalcalls.savecameradistance = cameradistance;
        Globalcalls.candash = candash;
        Globalcalls.zonemusic = currentzonemusic;
    }
}
