using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPointer : MonoBehaviour
{
    [field:SerializeField]
    public int point { get; private set; }
    void Awake()
    {
        TextMesh text = GetComponentInChildren<TextMesh>();
        text.text = "X" + point;
    }
}
