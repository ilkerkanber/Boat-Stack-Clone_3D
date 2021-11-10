using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController 
{
    Vector2 startPos;
    Vector2 direction;
    int inputInt;

    public int GetInput()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    startPos = _touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = _touch.position - startPos;
                    if (direction.x > 0)
                    {
                        inputInt = 1;
                        // vector3 eklemesi yap ve player�n x pozisyonunu bir **SA�**lane e ge�ecek kadar de�i�tir
                    }
                    else
                    {
                        inputInt = -1;
                        // vector3 eklemesi yap ve player�n x pozisyonunu bir **SOL** lane e ge�ecek kadar de�i�tir
                    }
                    break;
                case TouchPhase.Ended:
                    inputInt = 0;
                    break;
            }

        }
        return inputInt;
    }
}
