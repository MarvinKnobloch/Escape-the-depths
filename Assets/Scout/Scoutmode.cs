using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scoutmode : MonoBehaviour
{
    [SerializeField] private Camera maincam;
    private Controlls controls;

    private Rigidbody2D rb;
    private InputAction movehotkey;
    private InputAction controllermovehotkey;
    public Vector2 move;
    private Vector2 scoutvelocity;

    [SerializeField] private float scoutspeed;


    private void Awake()
    {
        controls = Keybindinputmanager.inputActions;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        controls.Enable();
        movehotkey = controls.Menu.Menumove;
        controllermovehotkey = controls.Menu.Controllermove;
    }

    void Update()
    {
        //if (controls.Player.Move.WasPerformedThisFrame()) //controls.Menu.Controllermove.WasPerformedThisFrame())
        //{ 
            if(move.x == 0)
            {
                transform.position = new Vector3(maincam.transform.position.x, transform.position.y, 0);
            }
            if(move.y == 0)
            {
                transform.position = new Vector3(transform.position.x, maincam.transform.position.y, 0);
            //}
        }

        moveinput();
        scoutvelocity.Set(move.x * scoutspeed, move.y * scoutspeed);
        rb.velocity = scoutvelocity;
    }
    private void moveinput()
    {
        move = movehotkey.ReadValue<Vector2>();
        if(Globalcalls.webglbuild == false)
        {
            if (move == Vector2.zero) move = controllermovehotkey.ReadValue<Vector2>();
        }
        else
        {
            if (move == Vector2.zero) move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}