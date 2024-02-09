using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    public Transform btarget;
    public float brangeDistance;
    public float bmoveSpeed = 0.5f;
    public Rigidbody2D bERB;
    public SpriteRenderer bSR;
    //生命值
    public float Benemyhealth1 = 100f;
    public float Bcurrenthealth1;
    public GameObject bulletPrefab;//子弹预制体
    public int fireCount = 10;//发射的子弹数量
    public float fanFireRate = 4f;//发射扇形弹幕的间隔时间
    public float circleFireRate = 10f;//发射圆形弹幕的间隔时间
    public Transform player;//玩家角色的Transform组件
    public float Jiechudamage = 1.0f;
    // Start is called before the first frame update

    void Start()
    {
       bERB = GetComponent<Rigidbody2D>();
        //协程FanFireCoroutine和CircleFireCoroutine，用于控制扇形弹幕和圆形弹幕的发射频率。
        StartCoroutine(FanFireCoroutine());
        StartCoroutine(CircleFireCoroutine());
        Bcurrenthealth1 = Benemyhealth1;
    }

    // Update is called once per frame
    void Update()
    {
        BMove();
        TurnDerection();
    }
    //朝向玩家角色发射扇形弹幕
    private void FireAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float angleStep = 90f / fireCount;
        float angle = -60f;
        for (int i = 0; i < fireCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector3 bulletDirection = rotation * direction;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * 10f;
            angle += angleStep;
        }
    }
    //发射圆形弹幕
    private void CircleFire()
    {
        float angleStep = 360f / fireCount;
        float angle = 0f;
        for (int i = 0; i < fireCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector3 bulletDirection = rotation * Vector3.up;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * 10f;
            angle += angleStep;
        }
    }
    //每隔一段时间发射一次扇形弹幕
    private IEnumerator FanFireCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fanFireRate);
            FireAtPlayer();
        }
    }
    //每隔一段时间发射一次圆形弹幕。
    private IEnumerator CircleFireCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(circleFireRate);
            CircleFire();
        }
    }
    public virtual void BAttack()
    {

    }

    public void Blosehealth(float Bfightnum)
    {
        if (Bcurrenthealth1 > 0)
        {
            Bcurrenthealth1 = Mathf.Clamp(Bcurrenthealth1 - Bfightnum, 0, Benemyhealth1);
            Debug.Log(Bcurrenthealth1 + "/" + Benemyhealth1);
            if (Bcurrenthealth1 == 0)
            {
                Debug.Log("怪物死亡");
                Destroy(this.gameObject);
                Bdrop();
            }
        }
        else
        {
            Debug.Log("怪物死亡");
            Destroy(this.gameObject);
            Bdrop();
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }*/
    //最小金币数
    public int BgoldMin = 1;
    // 最大金币数
    public int BgoldMax = 3;
    // 金币预制体
    public GameObject BgoldPrefab;
    // 掉落金币的半径
    public float BgoldRadius = 0.5f;
    private void Bdrop()
    {
        // 随机金币数
        int goldAmount = Random.Range(BgoldMin, BgoldMax + 1);
        // 在怪物位置生成金币
        for (int i = 0; i < goldAmount; i++)
        {
            // 在半径范围内随机生成金币位置
            Vector2 randomPos;
            randomPos.x = Random.Range(transform.position.x - BgoldRadius, transform.position.x + BgoldRadius);
            randomPos.y = Random.Range(transform.position.y - BgoldRadius, transform.position.y + BgoldRadius);
            Instantiate(BgoldPrefab, randomPos, Quaternion.identity);
        }
    }
    protected virtual void BMove()
    {
        if (Vector2.Distance(transform.position, btarget.position) > brangeDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, btarget.position, bmoveSpeed * Time.deltaTime);
        }
    }
    private void TurnDerection()
    {
        if (transform.position.x > btarget.position.x)
        {
            bSR.flipX = true;
        }
        else
        {
            bSR.flipX = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (pc.MyCurrentHealth > 0)
            {
                pc.losehealth(Jiechudamage);
                Debug.Log("玩家受到了伤害");
                //Destroy(this.gameObject);
            }
        }
    }
}
