using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove2 : MonoBehaviour
{
    
    public float floatingSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += floatingSpeed;

        Vector2 squareInScreenSpace = Camera.main.WorldToScreenPoint(pos);

        //if it outside the ScreenSpace
        if (squareInScreenSpace.x < 0 || squareInScreenSpace.x > Screen.width)
        {
            floatingSpeed = floatingSpeed * -1; //change direction

        }
        //apply to the Object's position
        transform.position = pos;
    }
}
