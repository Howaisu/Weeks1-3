using UnityEngine;
using UnityEngine.UI;

public class StateDisplay : MonoBehaviour
{
    public playerController player; // ��ȡ playerController �ű�
    public Text stateText; 

    void Update()
    {
       
        stateText.text = "Game State: " + player.state;
    }
}
