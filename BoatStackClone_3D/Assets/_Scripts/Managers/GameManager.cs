using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action OnGameOver;
    public static event System.Action OnGameWin;
    public static GameManager Instance { get; set; }
    
    [field:SerializeField]
    public bool IsGame { get; set; }
    
    RootController _rootController;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _rootController = FindObjectOfType<RootController>();
    }
    void Update()
    {
        if (_rootController.GetChildCount()==1)
        {
            OnGameOver?.Invoke();
        }
    }
}
