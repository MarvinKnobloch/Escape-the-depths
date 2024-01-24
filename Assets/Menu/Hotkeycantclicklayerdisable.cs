using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotkeycantclicklayerdisable : MonoBehaviour
{
    [SerializeField] private GameObject cantclicklayer1;
    [SerializeField] private GameObject cantclicklayer2;
    private void OnEnable()
    {
        Keybindinputmanager.disablecantclicklayer += startcountdown;
    }
    private void OnDisable()
    {
        Keybindinputmanager.disablecantclicklayer -= startcountdown;
    }

    private void startcountdown()
    {
        StartCoroutine("disablelayer");
    }
    IEnumerator disablelayer()
    {
        yield return null;
        cantclicklayer1.SetActive(false);
        cantclicklayer2.SetActive(false);
    }
}
