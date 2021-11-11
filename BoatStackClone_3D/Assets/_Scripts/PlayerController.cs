using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field:SerializeField]
    public float verticalSpeed { get; set; }

    [SerializeField] TransformData transformData;
    [SerializeField] float LerpSpeed=5f;
    
    Mover _mover;
    InputController _inputController;

    GameObject road;
    public int inputPos, currentPos;
    float timer;
    void OnEnable()
    {
        GameManager.OnGameOver += FreezePlayer;
        GameManager.OnGameWin += FreezePlayer;
    }
    void OnDisable()
    {
        GameManager.OnGameOver -= FreezePlayer;
        GameManager.OnGameWin -= FreezePlayer;
    }
    void Awake()
    {
        road = GameObject.FindGameObjectWithTag("PATH");
        _mover = new Mover(this, road);
        _inputController = new InputController();
    }
    void Update()
    {
        inputPos = _inputController.GetInput();
    }
    void FixedUpdate()
    {
        _mover.Active(verticalSpeed,LerpSpeed);
        SelectPosition(inputPos);
    }
    void FreezePlayer()
    {
        verticalSpeed = 0;
    }
    public void SetCenterPosition() 
    {
        currentPos = 0;
        _mover.NewPosition(transformData.GetValue("CENTER"));
    }
    void SelectPosition(int ind)
    {
        //INPUT YOKKEN VEYA OYUN SONUNDA
        if (ind == 0 || Time.time < timer + 0.2f || GameManager.Instance.IsFinish)
        {
            return;
        }
        //SINIRLAR ÝÇÝN
        if ((ind == 1 && currentPos==2) || (ind ==-1 && currentPos == -2))
        {
            return;
        }
        
        currentPos+=ind;
            switch (currentPos)
            {
                case -2:
                    _mover.NewPosition(transformData.GetValue("LEFT2"));
                    break;
                case -1:
                    _mover.NewPosition(transformData.GetValue("LEFT1"));
                    break;
                case 0:
                    _mover.NewPosition(transformData.GetValue("CENTER"));
                    break;
                case 1:
                    _mover.NewPosition(transformData.GetValue("RIGHT1"));
                    break;
                case 2:
                    _mover.NewPosition(transformData.GetValue("RIGHT2"));
                    break;
            }
        timer = Time.time;
    }
}
