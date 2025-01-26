using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //write down those bool for different stages first
    public bool isMoving;
    public bool playerIsKicking;
    public bool npcIsKicking;
    public bool isKickOut;
    //Basic values for the player
    public float movingSpeed;
    //The clamp for the player(on field)
    public Transform TopLeft;
    public Transform BottomRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input and calculate new position
        Vector2 pos = transform.position;
        pos.x += Input.GetAxisRaw("Horizontal") * movingSpeed * Time.deltaTime;
        pos.y += Input.GetAxisRaw("Vertical") * movingSpeed * Time.deltaTime;

        // Clamp the position within bounds
        pos.x = Mathf.Clamp(pos.x, TopLeft.position.x, BottomRight.position.x);
        pos.y = Mathf.Clamp(pos.y, TopLeft.position.y, BottomRight.position.y);

        // Apply the position
        transform.position = pos;

        // Check movement
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
