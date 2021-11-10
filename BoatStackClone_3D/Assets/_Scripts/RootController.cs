using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController: MonoBehaviour
{
    Vector3 newPos;
    float timerBug;
    int removeCount;

    void Update()
    {
        if (transform.childCount == 1) 
        {
            GameManager.Instance.IsGame = false;
        }
    }
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
    void OnTriggerEnter(Collider collider)
    {
        if (Time.time < timerBug + 0.1f)
        {
            return;
        }
        if (collider.CompareTag("Star"))
        {
            AddStar(collider.gameObject);
            timerBug = Time.time;
        }
        if (collider.CompareTag("Obstacle"))
        {
            int wRemove = collider.GetComponentInParent<Obstacle>().objectCount;
            RemoveStar(wRemove);
          
        }
    }
}
