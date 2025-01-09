using UnityEngine;

public class generateStars : MonoBehaviour
{
    public GameObject prefabToSpawn; // 要生成的GameObject预制体
    public int spawnCount = 10; // 生成数量
    public Camera mainCamera; // 用于确定生成范围的摄像机

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // 如果没有指定摄像机，使用主摄像机
        }

        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPosition = GetRandomPositionInCameraView();
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionInCameraView()
    {
        // 获取摄像机视口范围内的随机位置
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        // 将视口坐标转换为世界坐标
        Vector3 viewportPosition = new Vector3(randomX, randomY, mainCamera.nearClipPlane + 1f); // nearClipPlane 后面的距离调整
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        return worldPosition;
    }
}
