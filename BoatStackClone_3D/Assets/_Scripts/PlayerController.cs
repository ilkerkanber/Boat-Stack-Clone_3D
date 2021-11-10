using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float verticalSpeed;
    [SerializeField] float heightY;
    [SerializeField] GameObject body;
    GameObject road;
    Mover _mover;
    InputController _inputController;

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
}
