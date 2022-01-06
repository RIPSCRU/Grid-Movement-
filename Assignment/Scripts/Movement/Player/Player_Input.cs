using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
  

    public float swipeRange = 25f;//test-default value of slide- 25 px
    
 

    public Vector2 inputs = Vector2.zero;
    void Update()
    {
        Swipe();
    }


    /// <summary>
    /// checking if the user touches the screen and if yes then is he swiping 
    /// 1- chek for touch
    /// 2- check for current distance of the touch  on the screen to the start distance 
    /// if its greater tahn the threshold set by us then upsate the input;
    /// </summary>
    public void Swipe()
    {
        if(Input.touchCount>0)
        {

        if ( Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if ( Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;

                    if (Distance.x < -swipeRange)
                    {
                       //left
                        inputs = Vector2.left;
                    }
                    if (Distance.x > swipeRange)
                    {

                        //right
                        inputs = Vector2.right;
                    }
                    if (Distance.y > swipeRange)
                    {
                        //top
                        inputs = Vector2.up;
                    }
                    if (Distance.y < -swipeRange)
                    {
                        //bottom
                   
                        inputs = Vector2.down;
                    }

            }

        }
       


    }


}
