using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changjingqiehuan : MonoBehaviour
{

    //点击按钮场景跳转
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("level1");
    }

    //跳转另外一个场景
    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("场景名称2");
    }

//这里的切换要在对应的按钮里选择相应的函数

}
