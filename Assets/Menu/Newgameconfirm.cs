using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newgameconfirm : MonoBehaviour
{
    [SerializeField] private Menusoundcontroller menusoundcontroller;
    public void closeconfirm()
    {
        menusoundcontroller.playmenusound1();
        gameObject.SetActive(false);
    }
}
