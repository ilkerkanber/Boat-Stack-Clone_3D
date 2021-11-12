using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover 
{
    public void Active(float verticalSpeed, float lerpSpeed);
    public void NewPosition(Vector3 newValue);
}
