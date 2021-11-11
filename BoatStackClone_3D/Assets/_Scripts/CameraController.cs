using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 distance;
    Quaternion rotation;
    void Start()
    {
        SearchPlayer();
    }
    void LateUpdate()
    {
        if (target == null)
        {
            SearchPlayer();
        }
        transform.position = target.transform.position - distance;
        rotation = target.transform.rotation; //z+ x-
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x+5, rotation.eulerAngles.y, rotation.eulerAngles.z-3);
    }
    void SearchPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
