using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Saveload : Isavedata
{
    public bool savedata<T>(string dataname, T data)
    {
        string path = Application.persistentDataPath + dataname;
        try
        {
            if (File.Exists(path))
            {
                //Debug.Log("already exits, delete and creat new one");
                File.Delete(path);
            }
            else
            {
                //Debug.Log("creat first save");
            }
            string json_data = JsonUtility.ToJson(data);
            File.WriteAllText(path, json_data);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"error {e.Message} {e.StackTrace}");
            return false;
        }
    }
    public T loaddata<T>(string dataname)                       //mit der methode k�nnen kein monobehaviour/scriptable objects geladen werden
    {
        string path = Application.persistentDataPath + dataname;
        {
            if (File.Exists(path) == false)
            {
                Debug.Log($"Could not load, file doesnt exist {path}");
            }
        }
        try
        {
            string jsontostring = File.ReadAllText(path);
            T loadeddata = JsonUtility.FromJson<T>(jsontostring);
            //T loadeddata = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return loadeddata;
        }
        catch (Exception e)
        {
            Globalcalls.couldnotloaddata = true;
            //Debug.LogError($"error {e.Message} {e.StackTrace}");
            throw e;
        }
    }
}
