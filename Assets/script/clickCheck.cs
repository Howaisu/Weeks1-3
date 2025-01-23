using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickCheck : MonoBehaviour
{
    bool isDetect;
    float x, y, w, h;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        w = transform.localScale.x/2;
        h = transform.localScale.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 pos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = mousePos;

        if (pos.x < x + h && pos.x > x - h && pos.y < y + h && pos.y > y - h)
        {
            isDetect = true;
            Debug.Log("The mouse is detecting" + isDetect);
        }
        else
        {
            isDetect = false;
        }
        if(isDetect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
        }

    }
}
