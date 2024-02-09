using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 7f;//�ӵ��ƶ��ٶ�
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
//�ӵ��ƶ�=========
public void Move(Vector2 moveDirection, float MoveForce)
{
    rb.AddForce(moveDirection * MoveForce);


}
    //���������===
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy ec = other.GetComponent<Enemy>();


        if (ec != null)
        {
            if (ec.enemyhealth1 > 0)
            {
                ec.losehealth(fight);
                Debug.Log("�����ܵ����˺�");
                Destroy(this.gameObject);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

}
