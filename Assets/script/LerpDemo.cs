using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    [Range(0, 1)] public float number;
    public Transform start;
    public Transform end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        number += Time.deltaTime;

        if (number > 1)
        {
            number = 0;
        }
      

        transform.position = Vector2.Lerp(start.position,end.position,number);

    }
}
