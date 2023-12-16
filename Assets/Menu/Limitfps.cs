using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitfps : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 150;
    }
}
