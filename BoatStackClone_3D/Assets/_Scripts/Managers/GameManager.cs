using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action OnGameOver;
    public static event System.Action OnGameWin;
    public static GameManager Instance { get; set; }

    public int starCount { get; set; }
    public int diamondCount { get; set; }
    public bool IsFinish { get; set; }
    RootController _rootController;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        _rootController = FindObjectOfType<RootController>();
    }
    void Update()
    {
        if (_rootController.GetChildCount()==1)
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
}
