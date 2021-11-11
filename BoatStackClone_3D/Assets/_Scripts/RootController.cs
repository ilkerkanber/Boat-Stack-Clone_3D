using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController: MonoBehaviour
{
    Vector3 newPos;
    float timerBug,timerBug2;
    int removeCount;

    void AddStar(GameObject star)
    {
        StarsUp();
        star.GetComponent<Collider>().isTrigger = false;
        star.transform.parent = transform;
        star.transform.position = newPos;
        star.transform.rotation = Quaternion.Euler(0, 0, 0);
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
                Invoke("DeadControl", 0.1f);
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
               go.transform.position = col.transform.position + new Vector3(0, 0.5f, 0);
               break;
            }
        }
        DeadControl();
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
    void DeadControl()
    {
        if (transform.childCount == 1)
        {
            GameManager.Instance.IsOver = true;
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent<XPointer>(out XPointer xpointer))
        {
            if (!xpointer.IsHasStar)
            {
                ChangePosStar(collider.gameObject);
                xpointer.IsHasStar = true;
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (Time.time < timerBug + 0.1f)
        {
            return;
        }
        switch (collider.tag)
        {
            case "Star":
                AddStar(collider.gameObject);
                break;

            case "Obstacle":
                int wRemove = collider.GetComponentInParent<Obstacle>().objectCount;
                RemoveStar(wRemove);
                break;

            case "FINISH":
                PlayerController pl = transform.parent.GetComponent<PlayerController>();
                pl.verticalSpeed = 10;
                pl.SetCenterPosition();
                GameManager.Instance.IsFinish = true;
                GameManager.Instance.starCount = transform.childCount - 1;
                break;
        }
     
     
        
        timerBug = Time.time;
    }
}
