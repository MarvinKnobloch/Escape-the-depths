using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Scouttutorial : MonoBehaviour
{
    private TextMeshProUGUI tutorialtext;
    private Controlls controls;

    private string scouthotkey;

    private void Start()                                          // bei awake wird der text im build mode nicht upgedated?????????????????
    {
        tutorialtext = GetComponent<TextMeshProUGUI>();
        controls = Keybindinputmanager.inputActions;
        hotkeysandtextupdate();
    }
    private void OnEnable()
    {
        Menucontroller.tutorialupdate += hotkeysandtextupdate;
    }
    private void OnDisable()
    {
        Menucontroller.tutorialupdate -= hotkeysandtextupdate;
    }

    private void hotkeysandtextupdate()
    {
        scouthotkey = controls.Player.Scoutmode.GetBindingDisplayString(0);
        tutorialtext.text = "Press <color=green>" + scouthotkey + "</color> to move the camera freely to see what's ahead.";
    }
}
