 using UnityEngine;
using System.Collections;

public class ControlScheme
{
    public static object Reload, PrimaryFire, SecondaryFire;

    public static void PopulateControlScheme()
    {
        Reload = KeyCode.R;
        PrimaryFire = 0;
        SecondaryFire = 1;
    }
}