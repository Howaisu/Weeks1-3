using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSwing : MonoBehaviour
{
    //Reference
    public playerController player; // Get script of playerController
    //Basic Data
    public float timeSpeed = 120f; //Swing Speed
    public float maxAngle = 85f; // Half of the max angle
    // The Switch
    private bool isSwingingForward = true; // checking: swing to right or swing to left

    void Update()
    {

        // Get the current angle and transfer into rotating
        Vector3 rotating = transform.eulerAngles;
        if (player.isMoving)
        {
            // Z axis: When swing to right
            if (isSwingingForward)
            {
                rotating.z += timeSpeed * Time.deltaTime; // go right
                if (rotating.z >= maxAngle)
                {
                    rotating.z = maxAngle; // the maximum angle
                    isSwingingForward = false; // switch
                }
            }
            else
            {
                rotating.z -= timeSpeed * Time.deltaTime; // go left
                if (rotating.z <= 360 - maxAngle && rotating.z > 180) //deal with the angle
                {
                    rotating.z = 360 - maxAngle; // smallest angle
                    isSwingingForward = true; // switch
                }
            }

            // Update
            transform.eulerAngles = rotating;
        }
    }
}