using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public Transform target;
    public Rigidbody2D ERB;
    public float rangeDistance;
    public SpriteRenderer SR;
    //生命值
    public float enemyhealth1 = 5f;
    public float currenthealth1;

    // Start is called before the first frame update
    public virtual void Awake()
    {

    }
    void Start()
    {
        //BoseAttack();
        ERB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Move();
        TurnDerection();
        //BoseAttack();
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, target.position) > rangeDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void TurnDerection()
    {
        if (transform.position.x > target.position.x)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }

    }
    public virtual void Attack()
    {

    }
    //public virtual void BoseAttack()
    //{

    //}

    public void losehealth(float fightnum)
    {
        if (currenthealth1 > 0)
        {
            currenthealth1 = Mathf.Clamp(enemyhealth1 - fightnum, 0, enemyhealth1);
            Debug.Log(currenthealth1 + "/" + enemyhealth1);
            if (currenthealth1 == 0)
            {
                Debug.Log("怪物死亡");
                Destroy(gameObject);
                drop();
            }
        }
        else
        {
            Debug.Log("怪物死亡");
            Destroy(this.gameObject);
            drop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
           
        }
    }
    // 最小金币数
    public int goldMin = 1;
    // 最大金币数
    public int goldMax = 3;
    // 金币预制体
    public GameObject goldPrefab;
    // 掉落金币的半径
    public float goldRadius = 0.5f;
    private void drop()
    {
        // 随机金币数
        int goldAmount = Random.Range(goldMin, goldMax + 1);
        // 在怪物位置生成金币
        for (int i = 0; i < goldAmount; i++)
        {
            // 在半径范围内随机生成金币位置
            Vector2 randomPos;
            randomPos.x = Random.Range(transform.position.x- goldRadius, transform.position.x+ goldRadius);
            randomPos.y = Random.Range(transform.position.y - goldRadius, transform.position.y + goldRadius);
            Instantiate(goldPrefab, randomPos, Quaternion.identity);
        }
    }
}
