using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fpsdisplay : MonoBehaviour
{
    private Controlls controls;
    [SerializeField] private GameObject fpscounter;
    private void Awake()
    {
        controls = Keybindinputmanager.inputActions;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    void Update()
    {
        if (controls.Menu.Fpscounter.WasPerformedThisFrame())
        {
            Debug.Log("hallo");
            if (fpscounter.activeSelf == false) fpscounter.SetActive(true);
            else fpscounter.SetActive(false);
        }
    }
}
