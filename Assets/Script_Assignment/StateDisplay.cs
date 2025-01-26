using UnityEngine;
using UnityEngine.UI;

public class StateDisplay : MonoBehaviour
{
    public playerController player; // 获取 playerController 脚本
    public Text stateText; // 关联 Unity UI 的 Text 组件

    void Update()
    {
        // 更新 Text 显示内容为 player.state
        stateText.text = "Game State: " + player.state;
    }
}
