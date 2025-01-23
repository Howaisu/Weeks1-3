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

    // 当触发器触发时调用此方法
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查碰撞对象的标签是否是"thing"
        if (collision.gameObject.tag == "thing")

        {
            Debug.Log("On 2");
          
            if (Input.GetMouseButtonDown(0))
            {
                // 销毁带有"thing"标签的对象
                Destroy(collision.gameObject);
            }
        }
    }
}

