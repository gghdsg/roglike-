using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mtpa : Enemy
{
    public Transform ts;
    private float shotRate = 2.0f;
    private float shotTime;
    public GameObject enemybullets;
    public override void Attack()
    {
        base.Attack();
        shotTime += Time.deltaTime;
        if(shotTime>shotRate)
        {
           GameObject bullets=Instantiate(enemybullets);
            bullets.transform.position = transform.position;
            bullets.transform.parent = GameObject.Find("bulletparent").GetComponent<Transform>();
            shotTime = 0;
        }
    }
    public override void Awake()
    {
        ts = this.transform;
    }
}
