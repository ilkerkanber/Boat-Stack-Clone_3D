using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Obstacle : MonoBehaviour
{
    [field:SerializeField]
    public int objectCount{ get; private set; }

    [SerializeField] GameObject obstacle;
    [SerializeField] float distanceObjects;
 
    void Update()
    {
        if (runInEditMode)
        {
            Control();
            SortObjects();
        }
    }
    void Control()
    {
        if (objectCount == transform.childCount)
        {
            return;
        }
        else if (transform.childCount < objectCount)
        {
            CreateObstacle(objectCount - transform.childCount);
        }
        else
        {
            RemoveObstacle(transform.childCount - objectCount);
        }
    }
    void CreateObstacle(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(obstacle, transform);
        }
    }
    void RemoveObstacle(int count)
    {
        int max = transform.childCount-1;
        for (int i = 0; i < count; i++)
        {
            DestroyImmediate(transform.GetChild(max).gameObject);
            max--;
        }
    }
    void SortObjects()
    {
        float rate=0f;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = Vector3.up * rate;
            rate += distanceObjects;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
