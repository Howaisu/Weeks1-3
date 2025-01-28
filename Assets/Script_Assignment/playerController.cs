using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int state;
    //write down those bool for different stages first
    
    public bool isMoving;
    public bool playerIsKicking;
    public bool npcIsKicking;
    public bool isKickOut = false;
    //Basic values for the player
    public float movingSpeed;
    //The clamp for the player(on field)
    public Transform TopLeft;
    public Transform BottomRight;


    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the Input of keys
        float moveX = Input.GetAxisRaw("Horizontal") * movingSpeed * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * movingSpeed * Time.deltaTime;

        // Adding the postion with new position
        Vector3 newPosition = transform.position;
        newPosition.x += moveX;
        newPosition.y += moveY;

        // Clamp the position to make sure keep it on field
        newPosition.x = Mathf.Clamp(newPosition.x, TopLeft.position.x, BottomRight.position.x);
        newPosition.y = Mathf.Clamp(newPosition.y, BottomRight.position.y, TopLeft.position.y); // 

        // Update
        transform.position = newPosition;

        // MoingCheck
        movingChek();
    }
    void movingChek() {
        //check wheather the player is moving
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 )
        {
            isMoving = true;

        }
        else
        { 
            isMoving=false;
        }
    
    }
}
