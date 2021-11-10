using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> levelList;
    int currentLevel;

    void Awake()
    {
        LoadLevel();
        CreateLevel();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void NextLevel()
    {
        currentLevel++;
        GameObject levelGo = GameObject.FindGameObjectWithTag("LEVEL");
        Destroy(levelGo);
        CreateLevel();
    }
    void CreateLevel()
    {
        Instantiate(levelList[currentLevel]);
    }
    void LoadLevel()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            SaveLevel();
        }
    }
    void SaveLevel()
    {
        PlayerPrefs.SetInt("Level", currentLevel);
    }
}
