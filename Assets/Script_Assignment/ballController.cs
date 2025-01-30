using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    // Reference playerController
    public playerController player; // Get script of playerController
    public Transform TopLeft;
    public Transform BottomRight;

    // the basic data of ball///CURVE
    public AnimationCurve curve;
    [Range(0, 5)] public float maxSpeed;// (Don't forget make a speed curve later)
    public float rotationSpeed = -1000f;
    private Vector3 targetPosition; // Target position for the ball
    private float elapsedTime = 0f; // Time counter for the curv

    //
   // Vector3 targetPosition;
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
            elapsedTime = 0f;//this is an extra, idk why others not work
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
        //
     
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Get the speed from the curve
        float evaluatedSpeed = curve.Evaluate(elapsedTime) * maxSpeed;

        // Debug the speed value
       // Debug.Log($"Evaluated Speed: {evaluatedSpeed}");

        // Normalize the direction between the ball and target
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move the ball
        transform.position += direction * evaluatedSpeed * Time.deltaTime;

        // Stop moving if close enough to the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            transform.position = targetPosition;
            rotationSpeed = 0; // Stop rotation
            elapsedTime = 0f;
        }
    }

    void MoveToPlayer()
    {
        
        Vector3 direction2 = (player.transform.position - transform.position).normalized;
        float evaluatedSpeed = curve.Evaluate(elapsedTime) * maxSpeed;

        transform.position += direction2 * evaluatedSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
        {
            transform.position = player.transform.position;
            player.state = 0;
            elapsedTime = 0f;
        }
    }
}

