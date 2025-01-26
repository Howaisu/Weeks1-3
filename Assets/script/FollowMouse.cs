using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        // ��������Ļλ��ת������������
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ȷ��z���겻��Ӱ��2Dλ��
        mousePosition.z = transform.position.z;
        // ���¶���λ��
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
