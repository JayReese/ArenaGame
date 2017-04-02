using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent NVAgent;
    [SerializeField] Transform NVTarget;

	// Use this for initialization
	void Start ()
    {
        NVAgent = GetComponent<NavMeshAgent>();
        NVTarget = GameObject.Find("Target Cube").transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
        NVAgent.SetDestination(NVTarget.position);
    }
}