using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    //Reference
    public playerController player; // Getting playerController Script
    public Transform ball; // Getting the ball's Transform

    //Basic Data
    public float Speed = 5f; // NPC speed (Don't forget make a speed curve later)
  //  private bool isMovingToBall = false; // 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // CALL NPC moving when state 1
        if (player.state == 1)
        {
            GoToBall();
        }
        if (player.state == 2)
        {
            KickTheBall();
        }
        

    }

    void GoToBall()
    {
        if (ball != null)
        {



            // Collect the position of the ball, and normalize the location
            Vector3 direction = (ball.position - transform.position).normalized;

            // Move towards the ball
            transform.position += direction * Speed * Time.deltaTime;

            // Wheather she get it?
            if (Vector3.Distance(transform.position, ball.position) < 0.1f)
            {
                player.state = 2;
                transform.position = ball.position; // Ensure the position again
                Debug.Log("NPC has reached the ball!");
            }
            else
            {
                player.state = 1;
            }
        }
    }
    void KickTheBall()
    { 
    
    }
}