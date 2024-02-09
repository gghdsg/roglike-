using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
    
{
    public Rigidbody2D wrbd;


    //ÎäÆ÷×·×ÙËÙ¶È
    private float wspeed;

    //ÎäÆ÷³¯Ïò
    public SpriteRenderer WSR;

    public float WrangeDistance=0.5f;

    //ÎäÆ÷·¢Éä×Óµ¯¼ä¸ô
    public float shotrate;
    public float shottime;

    public GameObject charabullet;

   public PlayerController wpc;
    // Start is called before the first frame update
    public virtual void Awake()
    {

    }
    void Start()
    {
        wrbd = GetComponent<Rigidbody2D>();
        //wpc = GetComponent<PlayerController>();
        wspeed = wpc.speed;


    }

    // Update is called once per frame
    void Update()
    {
        wspeed = wpc.speed;
        WMove();
        WTurnDerection();
        WAttack();

    }
    public void WMove()
    {
        //Debug.Log("WMove");
        if (Vector2.Distance(transform.position, wpc.transform.position) > WrangeDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, wpc.transform.position, wspeed * Time.deltaTime);
       }
    }
    private void WTurnDerection()
    {
        if (transform.position.x > wpc.transform.position.x)
        {
            WSR.flipX = false;
        }
        else
        {
            WSR.flipX = true;
        }

    }
    public virtual void WAttack()
    {
       
    }
}
