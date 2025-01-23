using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    public Color color;
    public GameObject sprite;
    SpriteRenderer spriteRenderer;
    public float shrink = 0.01f;
    [Range(0, 1)] public float number;
    public float location;
    public float where;
    // Start is called before the first frame update
    void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        location = sprite.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 pos = transform.position;
       
        mousePos.z = 0;
        pos = mousePos;
       */
        // float 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        where = Mathf.Abs(mousePos.x - location);
        number = where*shrink;
       // float Red = Mathf.Lerp(0f, 1f, number);
        float Other = Mathf.Lerp(1f, 0f, number);
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1f,Other,Other, 1f);

        }
    }
}
