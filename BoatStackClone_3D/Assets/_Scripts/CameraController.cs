using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 distance;
    void LateUpdate()
    {
        LookAtRoad();
    }
    void LookAtRoad()
    {
        transform.position = GameManager.Instance.roadPosition + distance;
        Vector3 direction = GameManager.Instance.roadPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
