using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60f; // 总倒计时时间（以秒为单位）
    public Text timerText; // 显示倒计时的文本组件
    public GameObject winpanel;
    private float currentTime; // 当前剩余时间
    public PlayerController pc;
    public AudioSource bgm;
    private void Start()
    {
        currentTime = totalTime;
        winpanel.SetActive(false);
    }

    private void Update()
    {
        // 更新倒计时
        currentTime -= Time.deltaTime;

        // 将时间格式化为分钟:秒的字符串形式
        string minutes = Mathf.Floor(currentTime / 60f).ToString("00");
        string seconds = Mathf.Floor(currentTime % 60f).ToString("00");

        // 更新倒计时文本显示
        timerText.text = minutes + ":" + seconds;

        // 当倒计时结束时执行相应逻辑
        if (currentTime <= 0f)
        {
            TimerExpired();
        }
        showjinbi();
        
        
            if (pc.currenthealth <= 0)
            {
                Time.timeScale = 0;
                bgm.Stop();
            }
        
    }

    private void TimerExpired()
    {
        if (pc.currenthealth >0)
            winpanel.SetActive(true);
            Debug.Log("Time's up!");
        Time.timeScale = 0;
    }
    public int jinbi;
    public Text jinbitext;
    public void showjinbi()
    {
        string goldstring = pc.gold.ToString();
        jinbitext.text = goldstring;
    }

}


