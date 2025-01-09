using UnityEngine;

public class generateStars : MonoBehaviour
{
    public GameObject prefabToSpawn; // Ҫ���ɵ�GameObjectԤ����
    public int spawnCount = 10; // ��������
    public Camera mainCamera; // ����ȷ�����ɷ�Χ�������

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // ���û��ָ���������ʹ���������
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
        // ��ȡ������ӿڷ�Χ�ڵ����λ��
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        // ���ӿ�����ת��Ϊ��������
        Vector3 viewportPosition = new Vector3(randomX, randomY, mainCamera.nearClipPlane + 1f); // nearClipPlane ����ľ������
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        return worldPosition;
    }
}
