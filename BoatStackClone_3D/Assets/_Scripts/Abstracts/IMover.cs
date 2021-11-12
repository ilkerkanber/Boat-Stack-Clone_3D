using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover 
{
    public void Active(float verticalSpeed, float lerpVerSpeed, float lerpRotSpeed);
    public void NewPosition(Vector3 newValue);
    public void ResetRoad();

}
