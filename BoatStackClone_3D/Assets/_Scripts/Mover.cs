using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover 
{
    Spline spline;
    PlayerController _playerController;
    
    Quaternion rotZ;
    float rate=0.1f;
    float posX;
    
    public Mover(PlayerController playerController,GameObject road)
    {
        spline = road.GetComponent<Spline>();
        _playerController = playerController;
    }
    //x=POSX y=ROTX z=ROTY
    public void NewPosition(Vector3 newValue)
    {
        posX = newValue.x;
        rotZ = new Quaternion(newValue.y, newValue.z, 0, 0);
    }
    public void Active(float verticalSpeed, float lerpSpeed)
    {
        rate += (Time.deltaTime / 100) * verticalSpeed;
        CurveSample curve = spline.GetSample(rate);
        Vector3 targetPos = new Vector3(curve.location.x - posX, curve.location.y + 1f, curve.location.z);
        
        _playerController.transform.position = Vector3.Lerp(_playerController.transform.position, targetPos, Time.deltaTime * lerpSpeed);
        _playerController.transform.rotation = Quaternion.Lerp(_playerController.transform.rotation, rotZ, Time.deltaTime * lerpSpeed);
    }

}
