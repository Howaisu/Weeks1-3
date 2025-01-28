using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSwing : MonoBehaviour
{

    //Leg Number
    public int leg;
    //Reference
    public playerController player; // Get script of playerController
    //Basic Data
    public float swingSpeed = 120f; //Swing Speed
    public float maxAngle = 85f; // Half of the max angle

    private float timeCounter = 0f; // 时间计数器
    // The Switch
    private bool isSwingingForward = true; // checking: swing to right or swing to left

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
                float angle = Mathf.Sin(timeCounter) * maxAngle;

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