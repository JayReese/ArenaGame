using UnityEngine;
using System.Collections;

public class DamageMonitorDuration : MonoBehaviour
{
    float Lifetime;

	// Use this for initialization
	void Start ()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform, false);
        Lifetime = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Lifetime <= 0)
            Lifetime -= Time.deltaTime * 2f;
        else
            Destroy(gameObject);
	}
}
