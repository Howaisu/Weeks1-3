using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    float R, G, B;
    public float colorSpeed;
   // boolean day;
    // Start is called before the first frame update
    void Start()
    {
        R = 1f;
        G = 0.77f;
        B = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = new Color(R, G, B, 1f);
        if (R > 0.07f || G > 0.1f || B > 0.15f) {
            //  if(day = true)
            R = R - colorSpeed;
            G = G - colorSpeed;
            B = B - colorSpeed;

        }
        


    }
}
