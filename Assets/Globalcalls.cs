using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globalcalls
{
    public static bool gameispaused;

    public static bool jumpcantriggerswitch;

    public static Vector3 playeresetpoint;

    public static int currentsection;
    public static GameObject boundscolliderobj;                            //wird noch ben�tigt da currentsection nur ein int ist und man das gameobject mit dem collider braucht  (19.12.2023)
    public static int savecameradistance;
    public static int currentgametime;

    public static int currentgravitystacks;
    public static int currentmemorystacks;

    public static bool candash = false;

    public static bool dontreadplayerinputs;

    public static bool webglbuild;
    public static bool couldnotloaddata;
}
