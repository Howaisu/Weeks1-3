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
    public float Speed = 4f;
    public float rotationSpeed = 100f;

    //
    Vector3 targetPosition;
    void Update()
    {
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
                // Set playerController's playerIsKicking and isKickOut as true
                player.playerIsKicking = true;
                player.isKickOut = true;
                //////Debug/////
                //Debug.Log($"Ball clicked at {worldPosition}. Player is kicking: {player.playerIsKicking}, isKickOut: {player.isKickOut}");
               targetPosition = new Vector3(worldPosition.x, worldPosition.y,0);
            }
        }
        if(player.isKickOut == false)
        {
            transform.position = player.transform.position;
        
        }

        // Rotating
        if (player.isKickOut)
        {
            RotateBall();
            MoveToTarget();
        }
    }

    // Rotating Function
    void RotateBall()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    void MoveToTarget()
    {
        // ���㵱ǰλ�õ�Ŀ��λ�õķ�����������һ��
        Vector3 direction = (targetPosition - transform.position).normalized;

        // �����ٶ��ƶ���
        transform.position += direction * Speed * Time.deltaTime;

        // ����ӽ�Ŀ��λ�ã�ֹͣ�ƶ�
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            player.isKickOut = false; // ֹͣ�ƶ�
            transform.position = targetPosition; // ȷ����ȷ��Ŀ��λ��
        }
    }
}

