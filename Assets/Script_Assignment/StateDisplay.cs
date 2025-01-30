using UnityEngine;
using UnityEngine.UI;

public class StateDisplay : MonoBehaviour
{
    public playerController player; // ªÒ»° playerController Ω≈±æ
    public Text stateText; 

    void Update()
    {
       
        stateText.text = "Game State: " + player.state;
    }
}
