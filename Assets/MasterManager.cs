using UnityEngine;
using System.Collections;

public class MasterManager : MonoBehaviour
{
    void Awake()
    {
        ImplementationManagers.InstantiateNewManagers();
    }
}
