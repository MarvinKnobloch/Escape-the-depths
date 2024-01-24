using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatecontroller : MonoBehaviour                //wird im menucontroller aktiviert
{
    private Controlls controls;
    [SerializeField] private GameObject controllercursor;
    [SerializeField] private GameObject resumebutton;


    private void Awake()
    {
        controls = Keybindinputmanager.inputActions;
    }
    private void Update()
    {
        if (controls.Menu.Controllermove.WasPerformedThisFrame())
        {
            controllercursor.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
