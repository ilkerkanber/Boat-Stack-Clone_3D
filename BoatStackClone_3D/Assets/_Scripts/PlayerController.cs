using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float verticalSpeed;
    [SerializeField] float heightY;
    [SerializeField] GameObject body;
    GameObject road;
    Pos pos;

    Mover _mover;
    InputController _inputController;

    enum Pos
    {
        LEFT,
        RIGHT,
        CENTER
    }
    void Awake()
    {
        road = GameObject.FindGameObjectWithTag("PATH");
        _mover = new Mover(this, road);
        _inputController = new InputController();
    }
    
    void Update()
    {
        if (_inputController.GetInput() == 1)
        {
            body.transform.Translate(Vector3.right * Time.deltaTime * 10);
        }
        if (_inputController.GetInput() ==-1)
        {
            body.transform.Translate(Vector3.left * Time.deltaTime * 10);
        }
    }
    
    void FixedUpdate()
    {
        _mover.Vertical(verticalSpeed, heightY);
    }
    void ChangePos(int index)
    {
        if (index == 0) 
        {
            return; 
        }
        switch (pos)
        {
            case Pos.LEFT:
                if (index == 1)
                {
                    pos = Pos.CENTER;
                }
                break;
            case Pos.RIGHT:
                if (index == -1)
                {
                    pos = Pos.CENTER;
                }
                break;
            case Pos.CENTER:
                if (index == -1)
                {
                    pos = Pos.RIGHT;
                }
                else
                {
                    pos = Pos.LEFT;
                }
                break;
        }
    }
}
