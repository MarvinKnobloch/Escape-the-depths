using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;

public class Clampcursor : MonoBehaviour
{
    private VirtualMouseInput virtualMouseInput;

    private void Awake()
    {
        virtualMouseInput = GetComponent<VirtualMouseInput>();
    }
    private void LateUpdate()
    {
        Vector2 cursorposi = virtualMouseInput.virtualMouse.position.ReadValue();
        cursorposi.x = Mathf.Clamp(cursorposi.x, 20, Screen.width - 20);
        cursorposi.y = Mathf.Clamp(cursorposi.y, 20, Screen.height - 20);
        InputState.Change(virtualMouseInput.virtualMouse.position, cursorposi);
    }
}
