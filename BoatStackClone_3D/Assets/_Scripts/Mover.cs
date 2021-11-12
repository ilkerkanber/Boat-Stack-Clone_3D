using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover: IMover
{
    Spline spline;
    IEntityController _playerController;
    CurveSample curve;

    Quaternion rotZ;
    float rate=0.1f;
    float posX;
    
    public Mover(IEntityController playerController,Spline roadSpline)
    {
        spline = roadSpline;
        _playerController = playerController;
    }
    //x=POSX y=ROTX z=ROTY
    public void NewPosition(Vector3 newValue)
    {
        posX = newValue.x;
        rotZ = new Quaternion(newValue.y, newValue.z, 0, 0);
    }
    public void Active(float verticalSpeed, float lerpVerSpeed,float lerpRotSpeed)
    {
        rate += (Time.deltaTime / 100) * verticalSpeed;
        curve = spline.GetSample(rate);
        
        GameManager.Instance.roadPosition = curve.location;
        GameManager.Instance.roadRotation = curve.Rotation;
        Vector3 targetPos = new Vector3(curve.location.x - posX, curve.location.y + 1f, curve.location.z);
        
        _playerController.transform.position = Vector3.Lerp(_playerController.transform.position, targetPos, Time.deltaTime * lerpVerSpeed);
        _playerController.transform.rotation = Quaternion.Lerp(_playerController.transform.rotation, rotZ, Time.deltaTime * lerpRotSpeed);
    }
    
}
