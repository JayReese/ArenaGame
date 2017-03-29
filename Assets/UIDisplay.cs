using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] GameObject DamageMonitor;

    void Start()
    {
        DamageMonitor = Resources.Load("Art/UI/Damage Dealt") as GameObject;
    }

    public void CreateDamageDisplay(Vector3 positioning, int damageToDisplay)
    {
        GameObject newDisplay = Instantiate(DamageMonitor) as GameObject;
        newDisplay.GetComponent<RectTransform>().localPosition = positioning;
        newDisplay.GetComponent<Text>().text = damageToDisplay.ToString();
    }
}
