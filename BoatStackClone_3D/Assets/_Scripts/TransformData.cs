using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTransformData", menuName = "Create PlayerData/Create NewData", order = 2)]
public class TransformData : ScriptableObject
{
    Dictionary<string,(float posX,float rotX,float rotY)> datas;
    public TransformData()
    {
        datas = new Dictionary<string, (float posX, float rotX, float rotY)>();

        datas.Add("LEFT2", (-2f, -0.2164396f, 0.9762961f));
        datas.Add("LEFT1", (-1f, -0.1305262f, 0.9659258f));
        datas.Add("CENTER", (0f, 0, 1));
        datas.Add("RIGHT1", (1f, 0.1305262f, 0.9659258f));
        datas.Add("RIGHT2", (2f, 0.2164396f, 0.9762961f));
    }
    public Vector3 GetValue(string target)
    {
        Vector3 newValues=Vector3.zero;
        float pX = datas.Single(s => s.Key == target).Value.posX;
        float rX = datas.Single(s => s.Key == target).Value.rotX;
        float rY = datas.Single(s => s.Key == target).Value.rotY;
        newValues = new Vector3(pX, rX, rY);
        return newValues;
    }
}
