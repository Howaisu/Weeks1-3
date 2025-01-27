using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSwing : MonoBehaviour
{
    //Reference
    public playerController player; // Get script of playerController
    //Basic Data
    public float swingSpeed = 120f; //Swing Speed
    public float maxAngle = 85f; // Half of the max angle

    private float timeCounter = 0f; // ʱ�������
    // The Switch
    private bool isSwingingForward = true; // checking: swing to right or swing to left

    void Update()
    {

        // Get the current angle and transfer into rotating
        Vector3 rotating = transform.eulerAngles;
        if (player.isMoving)
        {
            // The swinging speed
            timeCounter += swingSpeed * Time.deltaTime;

            // Using Mathf.Sin to Calculate the current Angle
            float angle = Mathf.Sin(timeCounter) * maxAngle;

            // apply to the rotation of z-axis
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}