using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPointer : MonoBehaviour
{
    [field:SerializeField]
    public int point { get; private set; }
    public bool IsHasStar { get; set; }
    void Awake()
    {
        TextMesh text = GetComponentInChildren<TextMesh>();
        text.text = "x" + point;
    }
}
