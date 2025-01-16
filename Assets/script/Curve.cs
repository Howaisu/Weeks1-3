using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public AnimationCurve curve;
   [Range(0,1)] public float number;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        number = curve.Evaluate(number);
       // SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
       // renderer.color = new Color(0f+number, 0f, 0f+number, 1f);
       transform.localScale = new Vector3(number, number, number);
        */
        number += Time.deltaTime;

        if (number > 1) { 
            number = 0;
        }

        transform.localScale = Vector2.one * curve.Evaluate(number);
        
    }
}
