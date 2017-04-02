using UnityEngine;
using System.Collections;

public class Deployable : MonoBehaviour
{

    [SerializeField] Color DeployableColor;
    [SerializeField] int Health;

	// Use this for initialization
	void Start ()
    {
        DeployableColor = Color.cyan;

        gameObject.GetComponent<MeshRenderer>().material.color = DeployableColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Health <= 0 || Input.GetKeyDown(KeyCode.A))
            gameObject.SetActive(false);
	}

    void OnDisable()
    {
        Debug.Log("Shield has been destroyed");
    }

    void OnEnable()
    {
        Health = 300;
    }
}
