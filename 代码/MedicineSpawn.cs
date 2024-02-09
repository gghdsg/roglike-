using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineSpawn : MonoBehaviour
{
    public GameObject MedicinePre;
    // Start is called before the first frame update
    public int Num = 2;
    private float timers;
    public float timedetector=5;
    //设置一个随机数
    public double x;
    public float minx, maxx, miny, maxy;
    // Update is called once per frame
    void Update()
    {
        //计时器时间增加
        timers += Time.deltaTime;
        //5s检测一次
        if (timers > timedetector)
        {
            //重置计时器
            timers = 0;
            //设置随机数
            x = Random.Range(-10, 10);

            //查看有几个药品
            int n = transform.childCount;
            if (n < Num&&x>=-1&&x<=1)
            {
                Vector3 v = transform.position;
                v.x += Random.Range(minx, maxx);
                v.y += Random.Range(miny, maxy);

                GameObject medicine = GameObject.Instantiate(MedicinePre, v, Quaternion.identity);
                //设置父子关系
                medicine.transform.SetParent(transform);
            }
        }
    }
}
