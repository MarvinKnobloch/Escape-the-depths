using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Hooktutorial : MonoBehaviour
{
    private TextMeshProUGUI tutorialtext;
    private Controlls controls;

    private string wipehotkey;

    private void Awake()
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
        wipehotkey = controls.Player.Whip.GetBindingDisplayString(0);
        tutorialtext.text = "If your character is close enough to a whip point it will turn green and can be used by pressing <color=green>" + wipehotkey + "</color>.\n" +
                            //"Press <color=green>" + wipehotkey + "</color> to activate the whip.\n" +
                            "\nThe green color also determines your current whip target.\n" +
                            "\nIf your are straight below a whip point your character will be pulled more upwards.";
    }
}
