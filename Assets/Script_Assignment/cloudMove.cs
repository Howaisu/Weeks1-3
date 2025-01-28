using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour
{
    // Basic data
    public AnimationCurve curve; // ���ߣ����ڿ����Ƶ��˶�
    [Range(0, 1)] public float number; // ��һ���Ľ��ȣ�0 �� 1��
    public float floatingspeed; // �ƶ��ٶ�

    // Start is called before the first frame update
    void Start()
    {
        number = 0; // ��ʼ������Ϊ 0
    }

    // Update is called once per frame
    void Update()
    {
        // ���� number������ʱ����������
        number += Time.deltaTime * floatingspeed;

        // ѭ������ֵ���� number > 1 ʱ����Ϊ 0
        if (number > 1)
        {
            number = 0;
        }

        // �������߼����Ƶ� x ��λ��
        Vector3 newPosition = transform.position;
        newPosition.x = curve.Evaluate(number) * 13; // ����ֵ����Ŀ�귶Χ��0 �� 13��
        transform.position = newPosition; // Ӧ���µ�λ��
    }
}
