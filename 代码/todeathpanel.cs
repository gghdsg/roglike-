using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    public GameObject deathPanel;

    private void Start()
    {
        // 隐藏死亡面板
        deathPanel.SetActive(false);
    }

    public void ShowDeathPanel()
    {
        // 显示死亡面板
        deathPanel.SetActive(true);
    }
}

