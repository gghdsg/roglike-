using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponbullets :Weapon1
{
    // Start is called before the first frame update
    public Transform wts;
    private float shotRate = 1f;
    private float shotTime;
    //设置武器出现与否
    public bool emerge=false;
    public shooting shit;
    //public GameObject charabullet;
    /*public override void WAttack()
    {
        base.WAttack();
        shotTime += Time.deltaTime;
        if (shotTime > shotRate)

        {
            shotTime = 0f;
            GameObject wbullets = Instantiate(charabullet,wrbd.position, Quaternion.identity);
            BulletController wbc = wbullets.GetComponent<BulletController>();
            if (wbc != null)
            {
                wbc.Move(shit.wp, 100);
            }
        }
    }*/
    public override void Awake()
    {
        transform.gameObject.SetActive(emerge);
        wts = this.transform;
    }
}
