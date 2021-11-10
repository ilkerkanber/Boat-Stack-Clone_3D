using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover 
{
    PlayerController _playerController;
    float rate=0.1f;
    Spline spline;
    public Mover(PlayerController playerController,GameObject road)
    {
        spline = road.GetComponent<Spline>();
        _playerController = playerController;
    }
    public void Horizontal(float speed)
    {

    }
    public void Vertical(float speed,float distanceY)
    {
        rate += Time.deltaTime / speed;
        if (rate > spline.nodes.Count - 1)
        {
            rate -= spline.nodes.Count - 1;
        }
        CurveSample sample = spline.GetSample(rate);
       _playerController.transform.position = new Vector3(sample.location.x, sample.location.y + distanceY, sample.location.z);
       _playerController.transform.localRotation = sample.Rotation;
    }

}
