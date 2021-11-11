using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject WinGameCanvas;
    [SerializeField] GameObject LoseGameCanvas;

    void OnEnable()
    {
        GameManager.OnGameWin += EnableWinCanvas;
        GameManager.OnGameOver += EnableLoseCanvas;
    }
    void OnDisable()
    {
        GameManager.OnGameWin -= EnableWinCanvas;
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
    public void RestartCanvas()
    {
        WinGameCanvas.SetActive(false);
        LoseGameCanvas.SetActive(false);
    }
}
