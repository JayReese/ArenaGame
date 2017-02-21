using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    DisplayDamage ReportDamage;
    CombatManager CombatManage;

	// Use this for initialization
	void Start ()
    {
        CombatManage = GameObject.FindGameObjectWithTag("Managers").GetComponent<CombatManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Fire();
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(0))
            CombatManage.EvaluateShot(25);
    }
}
