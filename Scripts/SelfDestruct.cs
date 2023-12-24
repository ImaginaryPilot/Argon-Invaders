using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float TimeTillDeath = 5f;
    void Start()
    {
        Destroy(gameObject,TimeTillDeath);
    }
}
