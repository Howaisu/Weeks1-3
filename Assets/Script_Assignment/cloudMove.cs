using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour
{
    // Basic data
    public AnimationCurve curve; // 曲线，用于控制云的运动
    [Range(0, 1)] public float number; // 归一化的进度（0 到 1）
    public float floatingspeed; // 移动速度

    // Start is called before the first frame update
    void Start()
    {
        number = 0; // 初始化进度为 0
    }

    // Update is called once per frame
    void Update()
    {
        // 增加 number，根据时间驱动曲线
        number += Time.deltaTime * floatingspeed;

        // 循环进度值，当 number > 1 时重置为 0
        if (number > 1)
        {
            number = 0;
        }

        // 根据曲线计算云的 x 轴位置
        Vector3 newPosition = transform.position;
        newPosition.x = curve.Evaluate(number) * 13; // 曲线值乘以目标范围（0 到 13）
        transform.position = newPosition; // 应用新的位置
    }
}
