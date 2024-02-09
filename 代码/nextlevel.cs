using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel: MonoBehaviour
{
    private PlayerController npc;
    private BulletController nbc;
    // Start is called before the first frame update

    public void changjing()
        {
        SceneManager.LoadScene("level2");
        /*PlayerPrefs.SetFloat("Blood", npc.health);
        PlayerPrefs.SetInt("Gold", npc.gold);
        PlayerPrefs.SetFloat("Speed", npc.health);
        PlayerPrefs.SetFloat("Fight", nbc.fight);*/
        Debug.Log(Time.timeScale);
        }
}
