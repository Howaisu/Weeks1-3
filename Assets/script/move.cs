using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        Vector2 pos = transform.position;
        pos.x = -11;
        transform.position = pos; // 更新物体的位置
        */
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 pos = transform.position;
        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        pos = mousePos;
        /*
            if (mousePos.x < pos.x)
            {
                pos.x += moveSpeed;
            }
            else if (mousePos.x > pos.x)
            {
                pos.x -= moveSpeed;
            }
            
            if (mousePos.y < pos.y)
            {
                pos.y += moveSpeed;
            }
            else if (mousePos.y > pos.y)
            {
                pos.y -= moveSpeed;
            }
        */
            transform.position = pos;
            

    }
}
