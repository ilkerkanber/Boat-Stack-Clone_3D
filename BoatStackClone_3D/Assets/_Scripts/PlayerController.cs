using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IEntityController
{
    [field:SerializeField]
    public float verticalSpeed { get; set; }

    [SerializeField] TransformData transformData;
    [SerializeField] float LerpVerSpeed, LerpRotSpeed;
    
    IMover _Imover;
    Iinput _inputController;

    int inputPos, currentPos;
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
         Spline road = FindObjectOfType<Spline>();
        _Imover = new Mover(this, road);
        _inputController = new InputController();
    }
    void Update()
    {
        inputPos = _inputController.GetInput();
    }
    void FixedUpdate()
    {
        _Imover.Active(verticalSpeed,LerpVerSpeed,LerpRotSpeed);
        SelectPosition(inputPos);
    }
    void FreezePlayer()
    {
        verticalSpeed = 0;
    }
    public void SetCenterPosition() 
    {
        currentPos = 0;
        _Imover.NewPosition(transformData.GetValue("CENTER"));
    }
    public void SelectPosition(int ind)
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
                    _Imover.NewPosition(transformData.GetValue("LEFT2"));
                    break;
                case -1:
                    _Imover.NewPosition(transformData.GetValue("LEFT1"));
                    break;
                case 0:
                    _Imover.NewPosition(transformData.GetValue("CENTER"));
                    break;
                case 1:
                    _Imover.NewPosition(transformData.GetValue("RIGHT1"));
                    break;
                case 2:
                    _Imover.NewPosition(transformData.GetValue("RIGHT2"));
                    break;
            }
        timer = Time.time;
    }
}
