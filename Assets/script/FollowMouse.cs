using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        // 将鼠标的屏幕位置转换成世界坐标
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 确保z坐标不会影响2D位置
        mousePosition.z = transform.position.z;
        // 更新对象位置
        transform.position = mousePosition;
    }

    // Activate when triggered collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check the object wheather is "thing"
        if (collision.gameObject.tag == "thing")

        {
            Debug.Log("On 2");
          
            if (Input.GetMouseButtonDown(0))
            {
                // Destroy"thing"tag object
                Destroy(collision.gameObject);
            }
        }
    }
}

