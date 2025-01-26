using UnityEngine;
using UnityEngine.UI;

public class StateDisplay : MonoBehaviour
{
    public playerController player; // ��ȡ playerController �ű�
    public Text stateText; // ���� Unity UI �� Text ���

    void Update()
    {
        // ���� Text ��ʾ����Ϊ player.state
        stateText.text = "Game State: " + player.state;
    }
}
