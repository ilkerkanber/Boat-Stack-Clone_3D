using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController: MonoBehaviour
{
    public bool IsFinish { get; private set; }

    Vector3 newPos;
    float timerBug,timerBug2;
    int removeCount;
  
    void AddStar(GameObject star)
    {
        StarsUp();
        star.GetComponent<Collider>().isTrigger = false;
        star.transform.parent = transform;
        star.transform.position = newPos;
    }
    void RemoveStar(int willRemove)
    {
        for (int i = transform.childCount-1; i >= 0; i--)
        {
            if (removeCount == willRemove)
            {
                removeCount = 0;
                break;
            }
            else if (transform.GetChild(i).CompareTag("Star"))
            {
                Destroy(transform.GetChild(i).gameObject);
                removeCount++;
            }
        }
    }
    void ChangePosStar(GameObject col)
    {
        for (int i = transform.childCount-1; i>= 0; i--)
        {
            if (transform.GetChild(i).CompareTag("Star")) 
            {
               GameObject go = transform.GetChild(i).gameObject;
               go.transform.parent = col.transform;
               go.transform.position = transform.position;
               break;
            }
        }
    }
    void StarsUp()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == transform.childCount - 1)
            {
                newPos = transform.GetChild(i).transform.position;
            }
            transform.GetChild(i).position += Vector3.up * 0.25f;
        }
    }
    public int GetChildCount()
    {
        return transform.childCount;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (Time.time < timerBug + 0.1f)
        {
            return;
        }
        if (collider.CompareTag("Star"))
        {
            AddStar(collider.gameObject);
        }
        if (collider.CompareTag("Obstacle"))
        {
            int wRemove = collider.GetComponentInParent<Obstacle>().objectCount;
            RemoveStar(wRemove);
        }
        if (collider.CompareTag("FINISH"))
        {
            IsFinish = true;
        }
        timerBug = Time.time;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (Time.time < timerBug2 + 0.1f)
        {
            return;
        }
        if (collision.collider.GetComponent<XPointer>())
        {
            ChangePosStar(collision.collider.gameObject);
        }
        timerBug2 = Time.time;
    }
}
