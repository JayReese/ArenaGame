using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

delegate void DisplayDamage(List<int> damagesDealt);

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDisplay InterfaceDisplay;
    [SerializeField] Image StatDisplayRenderer;
    [SerializeField] Text StatDisplayText;
    [SerializeField] Dictionary<string, Color> StatDisplayColorMeanings;
    [SerializeField]
    sbyte test;


    // Use this for initialization
    void Start()
    {
        test = 4;
        InterfaceDisplay = GameObject.FindGameObjectWithTag("UI").GetComponent<UIDisplay>();
        StatDisplayRenderer = GameObject.FindGameObjectWithTag("UI.StatDisplayBoard").GetComponent<Image>();
        StatDisplayText = GameObject.FindGameObjectWithTag("UI.StatNumber").GetComponent<Text>();

        PreallocateDisplayColors();

        Debug.Log(StatDisplayColorMeanings["Neutral"]);

        Cursor.visible = false;
    }

    void Update()
    {
        CorrectDisplayStat();
    }

    public void GiveDamageReport(RaycastHit hit, int damageDealt)
    {
        InterfaceDisplay.CreateDamageDisplay(new Vector3(hit.point.x + 30, hit.point.y + 30, 0), damageDealt);
    }

    void CreateCrosshair()
    {
        
    }

    // Testing method.
    void CorrectDisplayStat()
    {
        StatDisplayText.text = Mathf.Abs(test).ToString();

        switch(test <= 6 && test >= -6)
        {
            case true:
                if (test > 0 || test < 0)
                {
                    if (test > 0) StatDisplayRenderer.color = StatDisplayColorMeanings["Positive"];
                    else if (test < 0) StatDisplayRenderer.color = StatDisplayColorMeanings["Negative"];
                }
                else
                    StatDisplayRenderer.color = StatDisplayColorMeanings["Neutral"];
                break;
            default:
                test = 0;
                break;
        }
        
    }

    void PreallocateDisplayColors()
    {
        StatDisplayColorMeanings = new Dictionary<string, Color>();

        Vector3[] c = new Vector3[] { new Vector3(0.1294f, 0.3019f, 0.6901f), new Vector3(0, 0.6980f, 0), new Vector3(0.6901f, 0, 0) };
        string[] s = new string[] { "Neutral", "Positive", "Negative" };

        for (byte i = 0; i < c.Length; i++)
            StatDisplayColorMeanings.Add(s[i], new Color(c[i].x, c[i].y, c[i].z));
    }
}
