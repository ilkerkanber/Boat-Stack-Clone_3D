using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> levelList;
    int currentLevel;
    void Awake()
    {
       // LoadLevel();
        CreateLevel();
    }
    public void NextLevel()
    {
        if (currentLevel == 2)
        {
            Debug.Log("LEVEL SAYISI BÝTTÝ");
            return;
        }
        currentLevel++;
        DestroyLevel();
        CreateLevel();
        SaveLevel();
    }
    public void RestartLevel()
    {
        DestroyLevel();
        StartCoroutine(waiter(1));
        CreateLevel();
    }
    void CreateLevel()
    {
        GameManager.Instance.IsOver = false;
        GameManager.Instance.IsFinish = false;
        Instantiate(levelList[currentLevel]);
    }
    void DestroyLevel()
    {
        GameObject levelGo = GameObject.FindGameObjectWithTag("LEVEL");
        Destroy(levelGo);
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
    IEnumerator waiter(float time)
    {
       yield return new WaitForSeconds(time);
    }
}
