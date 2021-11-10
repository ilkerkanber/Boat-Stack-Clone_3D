using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController: MonoBehaviour
{
    Vector3 newPos;
    public void AddStar(GameObject star)
    {
        StarsUp();
        star.GetComponent<Collider>().isTrigger = false;
        star.transform.parent = transform;
        star.transform.position = newPos;
    }
    void StarsUp()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == transform.childCount - 1)
            {
                newPos = transform.GetChild(i).transform.position;
            }
            transform.GetChild(i).position += Vector3.up*0.2f;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Star>())
        {
            AddStar(collider.gameObject);
        }    
    }
}
