using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public PlayerController pc;
    public BulletController bc;


    private void Start()
    {
        // 获取按钮的引用
        //button1 = GameObject.Find("Button1").GetComponent<Button>();
        //button2 = GameObject.Find("Button2").GetComponent<Button>();
        //button3 = GameObject.Find("Button3").GetComponent<Button>();

        // 为按钮添加点击事件监听器
        //button1.onClick.AddListener(OnClickButton1);
        //button2.onClick.AddListener(OnClickButton2);
        //button3.onClick.AddListener(OnClickButton3);
    }

    /*private void OnClickButton1()
    {
        // 按钮1的点击事件处理逻辑
        Debug.Log("Button 1 clicked!");

        if (pc.gold >= 60)
        {
            pc.gold -= 60;
            pc.health += 40;
        }
        else
            Debug.Log("jinbibuzu");


    }

    private void OnClickButton2()
    {
        // 按钮2的点击事件处理逻辑
        Debug.Log("Button 2 clicked!");
        
        if (pc.gold >= 60)
        {
            pc.gold -= 60;
            pc.speed += 5;
        }else
            Debug.Log("jinbibuzu");
    }

    private void OnClickButton3()
    {
        if (pc.gold >= 60)
        {
            pc.gold -= 60;
            bc.fight = bc.fight + (float)0.5;
        }
        else
            Debug.Log("jinbibuzu");
     
        // 按钮3的点击事件处理逻辑
        Debug.Log("Button 3 clicked!");
    }*/
}

