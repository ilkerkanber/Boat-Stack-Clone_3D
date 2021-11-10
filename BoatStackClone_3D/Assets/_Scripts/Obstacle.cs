using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [field:SerializeField]
    public int objectCount{ get; private set; }
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            objectCount++;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
