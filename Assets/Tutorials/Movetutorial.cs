using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Movetutorial : MonoBehaviour
{
    private TextMeshProUGUI movetutorialtext;
    private Controlls controls;

    private string lefthotkey;
    private string righthotkey;
    private string jumphotkey;
    private string menuhotkey;

    private void Awake()
    {
        movetutorialtext = GetComponent<TextMeshProUGUI>();
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
        lefthotkey = controls.Player.Move.GetBindingDisplayString(3);
        righthotkey = controls.Player.Move.GetBindingDisplayString(4);
        jumphotkey = controls.Player.Jump.GetBindingDisplayString(0);
        menuhotkey = controls.Menu.Openmenu.GetBindingDisplayString(0);
        movetutorialtext.text = "Use <color=green>" + lefthotkey + "</color>/<color=green>" + righthotkey + "</color> or <color=green>Arrow Keys</color> to move.\n" +
                                "Press <color=green>" + jumphotkey + "</color> to jump.\n" + 
                                "Hotkeys can be changed in the menu(<color=green>" + menuhotkey + "</color>) -> Settings"; 
    }
}
