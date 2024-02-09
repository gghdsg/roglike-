using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullets : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public float speed;
    private float maxLifeTime = 2.5f;
    private float LifeTime;
    public float attackpoint = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("222").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        LifeTime += Time.deltaTime;
        if(LifeTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
    }
    //=====敌人子弹与玩家相碰=====
    private void OnTriggerEnter2D(Collider2D other)
    {


        PlayerController pc = other.GetComponent<PlayerController>();
        Circle ci = other.GetComponent<Circle>();
        if (ci != null)
        {
            Destroy(this.gameObject);
        }

        if (pc != null)
        {
            if (pc.MyCurrentHealth > 0)
            {
                pc.losehealth(attackpoint);
                Debug.Log("玩家受到了伤害");
                Destroy(this.gameObject);
            }



        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

}
