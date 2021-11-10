using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float verticalSpeed;
    GameObject road;
    Mover _mover;
    InputController _inputController;

    int inputPos;
    float timer;
    public PlayerPosition playerPosition;
    public enum PlayerPosition
    {
        LEFT2,
        LEFT1,
        CENTER,
        RIGHT1,
        RIGHT2,
    }
    void Awake()
    {
        road = GameObject.FindGameObjectWithTag("PATH");
        _mover = new Mover(this, road);
        _inputController = new InputController();
    }
    void Start()
    {
        playerPosition = PlayerPosition.CENTER;
    }

    void Update()
    {
        inputPos = _inputController.GetInput();
    }
    
    void FixedUpdate()
    {
        _mover.Actived(verticalSpeed,1);
        SelectPosition(inputPos);
    }
    void SelectPosition(int ind)
    {
        if (ind == 0 || Time.time < timer + 0.2f)
        {
            return;
        }
        switch (playerPosition)
        {
            case PlayerPosition.LEFT2:
                if (ind == 1) 
                {
                    playerPosition = PlayerPosition.LEFT1;
                    _mover.LEFT1();
                }
                break;

            case PlayerPosition.LEFT1:
                if (ind == -1)
                {
                    playerPosition = PlayerPosition.LEFT2;
                    _mover.LEFT2();
                }
                else
                {
                    playerPosition = PlayerPosition.CENTER;
                    _mover.CENTER();
                }
                break;

            case PlayerPosition.CENTER:
                if (ind == -1)
                {
                    playerPosition = PlayerPosition.LEFT1;
                    _mover.LEFT1();
                }
                else if(ind == 1)
                {
                    playerPosition = PlayerPosition.RIGHT1;
                    _mover.RIGHT1();
                }
                break;

            case PlayerPosition.RIGHT1:
                if (ind == -1)
                {
                    playerPosition = PlayerPosition.CENTER;
                    _mover.LEFT1();
                }
                else if (ind == 1)
                {
                    playerPosition = PlayerPosition.RIGHT2;
                    _mover.RIGHT2();
                }
                break;

            case PlayerPosition.RIGHT2:
                if (ind == -1)
                {
                    playerPosition = PlayerPosition.RIGHT1;
                    _mover.RIGHT1();
                }
                break;
        }
        timer = Time.time;
    }
}
