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
    //����һ�������
    public double x;
    public float minx, maxx, miny, maxy;
    // Update is called once per frame
    void Update()
    {
        //��ʱ��ʱ������
        timers += Time.deltaTime;
        //5s���һ��
        if (timers > timedetector)
        {
            //���ü�ʱ��
            timers = 0;
            //���������
            x = Random.Range(-10, 10);

            //�鿴�м���ҩƷ
            int n = transform.childCount;
            if (n < Num&&x>=-1&&x<=1)
            {
                Vector3 v = transform.position;
                v.x += Random.Range(minx, maxx);
                v.y += Random.Range(miny, maxy);

                GameObject medicine = GameObject.Instantiate(MedicinePre, v, Quaternion.identity);
                //���ø��ӹ�ϵ
                medicine.transform.SetParent(transform);
            }
        }
    }
}
