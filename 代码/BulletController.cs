using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 7f;//子弹移动速度
    private float Timer = 2f;
    public static float fight = 1f;
// Start is called before the first frame update
    void Awake()
{

    rb = GetComponent<Rigidbody2D>();
    Destroy(this.gameObject, 2f);
}

// Update is called once per frame
void Update()
{


}
//子弹移动=========
public void Move(Vector2 moveDirection, float MoveForce)
{
    rb.AddForce(moveDirection * MoveForce);


}
    //与怪物相碰===
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy ec = other.GetComponent<Enemy>();


        if (ec != null)
        {
            if (ec.enemyhealth1 > 0)
            {
                ec.losehealth(fight);
                Debug.Log("怪物受到了伤害");
                Destroy(this.gameObject);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

}
