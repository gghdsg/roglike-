using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{
    Rigidbody2D BRB;
    public float a, b;
    BossBullets bbt;
    PlayerController pc;
    private float maxLifeTime = 5.0f;
    private float LifeTime;
    public float attackpoint;

    //public float speed = 6f;//子弹移动速度
    // Start is called before the first frame update
    void Start()
    {
        BRB = GetComponent<Rigidbody2D>();
        bbt = GetComponent<BossBullets>();
        pc = GameObject.Find("222").gameObject.GetComponent<PlayerController>();
        Vector2 Direction = new Vector2(pc.transform.position.x - bbt.transform.position.x, pc.transform.position.y - bbt.transform.position.y );
        bbt.Move(Direction, 20);

    }

    // Update is called once per frame
    void Update()
    {
        LifeTime += Time.deltaTime;
        if (LifeTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void Move(Vector2 moveDirection, float MoveForce)
    {
        BRB.AddForce(moveDirection * MoveForce);
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
