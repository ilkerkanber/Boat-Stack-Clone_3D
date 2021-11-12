using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action OnGameOver;
    public static event System.Action OnGameWin;
    public static GameManager Instance { get; set; }

    public Vector3 roadPosition{ get; set; }
    public Quaternion roadRotation{ get; set; }
    public int starCount { get; set; }
    public int diamondCount { get; set; }
    public bool IsFinish { get; set; }
    public bool IsOver{ get; set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (IsOver)
        {
            if (IsFinish)
            {
                OnGameWin?.Invoke();
            }
            else
            {
                OnGameOver?.Invoke();
            }
        }
    }
    public void ResetValues()
    {
        starCount = 0;
        diamondCount = 1;
        IsFinish = false;
        IsOver = false;
    }

}
