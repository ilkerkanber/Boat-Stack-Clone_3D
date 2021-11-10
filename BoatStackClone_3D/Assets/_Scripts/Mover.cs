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
    public void LEFT2()
    {
        posX = -2f;
        rotZ = new Quaternion(-0.258819f, 0.9659258f, 0, 0);
    }
    public void LEFT1()
    {
        posX = -1f;
        rotZ = new Quaternion(-0.1305262f, 0.9659258f, 0, 0);
    }
    public void CENTER()
    {
        posX = 0;
        rotZ = new Quaternion(0, 1, 0, 0);
    }
    public void RIGHT1()
    {
        posX = 1f;
        rotZ = new Quaternion(0.1305262f, 0.9914449f, 0, 0);
    }
    public void RIGHT2()
    {
        posX = 2f;
        rotZ = new Quaternion(0.258819f, 0.9659258f, 0, 0);
    }
    
    public void Actived(float verticalSpeed, float lerpSpeed)
    {
        rate += (Time.deltaTime / 100) * verticalSpeed;
        CurveSample curve = spline.GetSample(rate);
        Vector3 targetPos = new Vector3(curve.location.x - posX, curve.location.y + 1f, curve.location.z);
        
        _playerController.transform.position = Vector3.Lerp(_playerController.transform.position, targetPos, Time.deltaTime * lerpSpeed);
        _playerController.transform.rotation = Quaternion.Lerp(_playerController.transform.rotation, rotZ, Time.deltaTime * lerpSpeed);
    }

}
