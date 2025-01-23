using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour
{
    SpriteRenderer Renderer;
    
    float startSize;
   // public Transform Size;
    // Start is called before the first frame update
    void Start()
    {
       
        //Transfrom Size = GameObject.transform;
        startSize = Random.Range(1f, 8f);
        transform.localScale = new Vector2( startSize, startSize);
        Renderer  = GetComponent<SpriteRenderer>();
        Renderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
