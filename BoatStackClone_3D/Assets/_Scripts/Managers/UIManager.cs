using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] GameObject WinGameCanvas;
    [SerializeField] GameObject LoseGameCanvas;
    [SerializeField] Text pointText;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void OnEnable()
    {
        GameManager.OnGameWin += EnableWinCanvas;
        GameManager.OnGameWin += SetPoint;
        GameManager.OnGameOver += EnableLoseCanvas;
    }
    void OnDisable()
    {
        GameManager.OnGameWin -= EnableWinCanvas;
        GameManager.OnGameWin -= SetPoint;
        GameManager.OnGameOver -= EnableLoseCanvas;
    }
    void EnableLoseCanvas()
    {
        LoseGameCanvas.SetActive(true);
        WinGameCanvas.SetActive(false);
    }

    void EnableWinCanvas()
    {
        WinGameCanvas.SetActive(true);
        LoseGameCanvas.SetActive(false);
    }
    void SetPoint()
    {
        int total = GameManager.Instance.diamondCount * GameManager.Instance.starCount * 10;
        pointText.text = total.ToString();
    }
}
