using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_Movement : MonoBehaviour
{
   
    
    Vector2 currMoveDirection = Vector2.zero; //the direction in which we want our player to move

    private bool isMoving = false;//to chek when can we change the direction of the player

    //used for lerping 
    private Vector2 originalPos, targetPos;

    //how much time it is going to take to move from one point on the grid to another
    [SerializeField] float timeToMove = 0.2f;
    

    //Refrences
    
    Player_Input inputs;
    MovementGrid GRID;

    


    private void Start()
    {
       
        isMoving = false;
        GRID = FindObjectOfType<MovementGrid>();
        inputs = transform.GetComponent<Player_Input>();
        originalPos = transform.position;
      

    }

    private void Update()
    {
        #region KeyBoard Inputs
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        //if (x > 0)
        //{
        //    currMoveDirection = Vector2.right;

        //}
        //else if (x < 0)
        //{
        //    currMoveDirection = Vector2.left;
        //}
        //else if (y > 0)
        //{
        //    currMoveDirection = Vector2.up;
        //}
        //else if (y < 0)
        //{
        //    currMoveDirection = Vector2.down;
        //}
        #endregion

        //constantly update  the move direction
        currMoveDirection = inputs.inputs;

        
        if (!isMoving)
        {

            
            if (currMoveDirection != Vector2.zero)
                StartCoroutine(MovePlayer(currMoveDirection));

        }



    }
    float elapsedTime = 0;
    private IEnumerator MovePlayer(Vector2 direction)
    {
        
       //store the original position of the player and then we add the direction that we have currently ansstore it in targetPos
        originalPos = transform.position;
        targetPos = originalPos + direction;

        //we have to check if the target is within the bounds if its not then we have to reset the position wrt to the start position ofthe grid
        //that we have given in the "Movement Grid " Component
        #region bound Check
        /// the following movement can be done in an efficient way by drawing the grid from the center 
       
        if (targetPos.x >= GRID._startX + GRID._gridWidth)
        {
            transform.position = new Vector3(GRID._startX, transform.position.y, transform.position.z);
        }else if(targetPos.x <GRID._startX  )
        {
            transform.position = new Vector3(GRID._startX + GRID._gridWidth*GRID._cellSize, transform.position.y,transform.position.z);
        }
        else if(targetPos.y > -GRID._startY + GRID._gridHeight)
        {
            transform.position = new Vector3(transform.position.x, -GRID._startY, transform.position.z);
        }else if(targetPos.y<-GRID._startY)
        {
            transform.position = new Vector3(transform.position.x, GRID._startY , transform.position.z);
        }
        #endregion
        isMoving = true;
        elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction;
        //we simply lerp to the position to get a smooth movement;
        while (elapsedTime < timeToMove)
        {
            
            transform.position = Vector3.Lerp(originalPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            
            
            yield return null;
        }
        
        //we assign the transform the position because even if we lerp there is a small % error
        //which may add up after a interval of time to a notable unit 
        //so we assing the transform the target pos;
        transform.position = targetPos;
        isMoving = false;

       
       

    }

 

   
}
