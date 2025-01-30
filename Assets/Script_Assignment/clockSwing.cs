using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSwing : MonoBehaviour
{
    /* This Script is for the animation of character walking
     * 
     */
    //Leg Number
    public int leg;
    //public bool kickLeg;
    //Reference
    public playerController player; // Get script of playerController
   // public NPCLogic npc;// Get script of playerController
    //Basic Data
    public float swingSpeed = 120f; //Swing Speed
    public float maxAngle = 85f; // Half of the max angle

    private float timeCounter = 0f; // Time counter
    // The Switch
    //private bool isSwingingForward = true; // checking: swing to right or swing to left 

    void Update()
    {

        // Get the current angle and transfer into rotating
        Vector3 rotating = transform.eulerAngles;


        if (player.isMoving)
        {
            if (leg == 1)
            {
                // The swinging speed
                timeCounter += swingSpeed * Time.deltaTime;

                // Using Mathf.Sin to Calculate the current Angle
                float angle = Mathf.Sin(timeCounter) * maxAngle; //(goes between -1 to 1)*85
                                                                 //
                // animating a pendulum, angle could represent the rotation angle of the pendulum arm 
                // from its vertical position.As timeCounter increases(likely incremented each time your update
                // loop runs), angle will smoothly transition between - maxAngle and maxAngle, causing the 
                // pendulum to swing back and forth.


                // apply to the rotation of z-axis
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
            else if (leg == 2)
            {
                // The swinging speed
                timeCounter += swingSpeed * Time.deltaTime;

                // Using Mathf.Sin to Calculate the current Angle
                float angle = Mathf.Sin(timeCounter) * (-maxAngle);

                // apply to the rotation of z-axis
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
        }
       

        else
        {
            if (leg == 1)
            {
                // apply to the rotation of z-axis
                transform.localRotation = Quaternion.Euler(0, 0, 11);
            }
            else if (leg == 2)
            {
                // apply to the rotation of z-axis
                transform.localRotation = Quaternion.Euler(0, 0, 11);
            }





        }
       
    }
}