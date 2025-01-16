using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float timeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotating = transform.eulerAngles;
         rotating.z -= timeSpeed;
        transform.eulerAngles = rotating;

    }
}
