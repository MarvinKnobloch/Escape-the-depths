using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Saveandloadgame : MonoBehaviour
{
    private Isavedata saveloadinterface = new Saveload();

    private Convertdata convertdata = new Convertdata();

    public void savegameonplayerenter()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            saveplayerprefs();
        }
        else
        {
            savegamedata();
        }
    }
    public void saveplayerprefs()
    {
        PlayerPrefs.SetFloat("playerxposi", Globalcalls.playeresetpoint.x);
        PlayerPrefs.SetFloat("playeryposi", Globalcalls.playeresetpoint.y);
        PlayerPrefs.SetInt("sectionnumber", Globalcalls.currentsection);
        PlayerPrefs.SetInt("cameradistance", Globalcalls.savecameradistance);
        if(Globalcalls.candash == false) PlayerPrefs.SetInt("candash", 0);
        else PlayerPrefs.SetInt("candash", 1);
    }
    public void savegamedata()
    {
        convertdata.savedatainscript();
        savestatics();
    }
    private void savestatics()
    {
        string savepath = "/Savadata.json";
        if (saveloadinterface.savedata(savepath, convertdata))
        {
            //Debug.Log("game saved" + savepath);
        }
        else
        {
            Debug.Log("Error: Could not save Data");
        }
    }
    public void loadgamedate()
    {
        loadstaticdata();
        if (convertdata != null)
        {
            convertdata.loaddata();
        }
    }
    private void loadstaticdata()
    {
        string loadpath = "/Savadata.json";
        try
        {
            convertdata = saveloadinterface.loaddata<Convertdata>(loadpath);
        }
        catch
        {
            //Debug.LogError($"error Could not load data {e.Message} {e.StackTrace}");
        }
    }
}
