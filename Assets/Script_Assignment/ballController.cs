using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    // Reference playerController
    public playerController player; // Get script of playerController
    public Transform TopLeft;
    public Transform BottomRight;

    // the basic data of ball
    public float Speed = 4f;// (Don't forget make a speed curve later)
    public float rotationSpeed = -1000f;

    //
    Vector3 targetPosition;
    void Update()
    {
    
        if(player.state == 0)
        {
            //I need make another different stage for the NPC get the ball
            transform.position = player.transform.position;
            // Check the clicking of mouse
            if (Input.GetMouseButtonDown(0)) // left button
            {
                // get the location
                Vector3 mousePosition = Input.mousePosition;
                // change the screen location to world location
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

                // Check whether the location is in-between TopLeft and BottomRight range (on field)
                if (worldPosition.x >= TopLeft.position.x && worldPosition.x <= BottomRight.position.x &&
                    worldPosition.y >= BottomRight.position.y && worldPosition.y <= TopLeft.position.y)
                {
                    player.state = 1;
                    // Set playerController's playerIsKicking and isKickOut as true
                    //player.playerIsKicking = true;
                    //player.isKickOut = true;

                    //////Debug/////
                    //Debug.Log($"Ball clicked at {worldPosition}. Player is kicking: {player.playerIsKicking}, isKickOut: {player.isKickOut}");
                    targetPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
                }
            }
        }

        // Rotating
        if (player.state == 1)
        {
            RotateBall();
            MoveToTarget();
        }
        
        else if (player.state == 2)
        {
           rotationSpeed = -18f;
            RotateBall();
            MoveToPlayer();
        }
       

    }

    // Rotating Function
    void RotateBall()
    {
        Vector3 rotating = transform.eulerAngles;
        rotating.z -= rotationSpeed;
        transform.eulerAngles = rotating;
    }
    void MoveToTarget()
    {
        // normalize the direction between starting point and target point
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move the ball as the speed
        transform.position += direction * Speed * Time.deltaTime;

        // If it is reach the target, stops moving
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
         //   player.isKickOut = false; // Stop moves
            transform.position = targetPosition; // Get to that location
            //stop rotating
           // player.state = 2;
           rotationSpeed = 0;
        }
    }
    void MoveToPlayer()
    {
        //normalize
        Vector3 direction2 = (player.transform.position - transform.position).normalized;
       
        //move to the player as speed
        transform.position += direction2 * Speed * Time.deltaTime;
       
        // If it is reach the target(player£©, stops moving
        if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
        {
            //   player.isKickOut = false; // Stop moves
            transform.position = player.transform.position; // Get to that location
            player.state = 0;
        }

    }
}

