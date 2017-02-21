﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

delegate void DisplayDamage(List<int> damagesDealt);

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject DamageMonitor;
    [SerializeField] UIDisplay InterfaceDisplay;

    // Use this for initialization
    void Start()
    {
        DamageMonitor = Resources.Load("Art/UI/Damage Dealt") as GameObject;
        InterfaceDisplay = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDisplay>();
    }

    public void GiveDamageReport(RaycastHit hit, int damageDealt)
    {
        InterfaceDisplay.CreateDamageDisplay(new Vector3(30, 50, 0), damageDealt);
    }

    void CreateCrosshair()
    {
        
    }
}
