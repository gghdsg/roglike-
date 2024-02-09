using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public GameObject EnemyPre;
    // Start is called before the first frame update
    public int Num = 3;
    private float timer;
    // Update is called once per frame
    void Update()
    {
        //计时器时间增加
        timer += Time.deltaTime;
        //2s检测一次
        if(timer>2)
        {
            //重置计时器
            timer = 0;
            //查看有几个敌人
            int n = transform.childCount;
            if(n < Num)
            {
                Vector3 v = transform.position;
                v.x += Random.Range(-5, 5);
                v.y += Random.Range(-5, 5);

                GameObject enemy = GameObject.Instantiate(EnemyPre, v, Quaternion.identity);
                //设置父子关系
                enemy.transform.SetParent(transform);
            }
        }
    }
}
