using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 控制玩家
/// </summary>
/// 

public class PlayerController : MonoBehaviour
{
    Rigidbody2D RB;
    public GameObject deathPanel;
    public AudioSource attackaudio;
    public AudioSource failaudio;

    //玩家移动速度
    public float speed = 5f;

    //子弹
    public GameObject bulletPrefab;

    //public int m;
    public float Timer = 0f;

    //生命值
    //满生命值
    public float health =40f;
    //当前生命值
    public float currenthealth;
    public float MyHealth { get { return health; } }
    public float MyCurrentHealth { get { return currenthealth; } }
    //玩家朝向默认为右方
    public Vector2 lookDirection = new Vector2(1, 0);
    public GameObject circle;
    AnimatorController animatorPlay;
    //无敌时间
    public float pTime = 0.25f;
    public float ptimer;
    private bool isInvicible;//是否处于无敌状态
    private float EcdTime;
    public float EcdRate=2.0f;
    // Start is called before the first frame update

    void Start()
    {
        currenthealth = health;
        RB = GetComponent<Rigidbody2D>();
        animatorPlay = GetComponent<AnimatorController>();
        deathPanel.SetActive(false);
        failaudio.Stop();
        EcdTime = EcdRate;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //点击鼠标左键发射子弹
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Input.mousePosition;
            Vector2 wp = Camera.main.ScreenToWorldPoint(mousepos);
            wp = wp - RB.position;
            //float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);

            GameObject bullet = Instantiate(bulletPrefab, RB.position, Quaternion.identity);
            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null)
            {
                bc.Move(wp, 100);
            }
        }*/
        //使用橡皮擦，产生暂停屏幕内已有子弹并震退敌人的效果

        EcdTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(EcdTime >= EcdRate)
            {
                GameObject circles = Instantiate(circle, RB.position, Quaternion.identity);
                Circle ce = circle.GetComponent<Circle>();
                circles.transform.parent = GameObject.Find("CircleParent").GetComponent<Transform>();
                EcdTime = 0;
            }
        }
        //无敌计时============
        if (isInvicible)
        {
            ptimer -= Time.deltaTime;
            if (ptimer < 0)
            {
                isInvicible = false;//计时完毕，取消无敌状态
            }
        }
        SetHealth(currenthealth, health);

    }
    //==========玩家生命值控制=========
    //敌人攻击使生命值减少
    public void losehealth(float num)
    {
        if (num > 0)
        {
            if (isInvicible == true)
            {
                return;
            }
            isInvicible = true;
            ptimer = pTime;
        }
        if (currenthealth > 0)
        {
            //玩家生命值增加的时候需要被约束在最大值和0之间
            currenthealth = Mathf.Clamp(currenthealth - num, 0, health);
            Debug.Log(currenthealth + "/" + health);
            animatorPlay.PlayHurt();
            animatorPlay.PlayIdle();
            if (currenthealth <= 0)
            {
                fillImage.fillAmount = 0f;
                animatorPlay.PlayDie();
                Debug.Log("玩家已死亡");
                deathPanel.SetActive(true);;
                failaudio.Play();
            }
        }
        else
        {
            animatorPlay.PlayDie();
            Debug.Log("玩家已死亡");
            deathPanel.SetActive(true);
        }
    }
    //道具使生命值增加
    public void increasehealth()
    {
        if (currenthealth < health && currenthealth > 0)
        {
            //玩家生命值增加的时候需要被约束在最大值和0之间
            currenthealth = Mathf.Clamp(currenthealth + 4, 0, health);
            Debug.Log(currenthealth + "/" + health);
        }

    }
    private void Move()
    {
        //玩家的朝向随键盘输入
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (moveHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //========玩家移动======
         float moveX = Input.GetAxis("Horizontal");
         float moveY = Input.GetAxis("Vertical");
         RB.velocity = speed * new Vector2(moveX * speed, moveY * speed).normalized;
    }
    // 初始金币数
    public int gold =0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到金币，金币数加1，并销毁金币
        if (collision.gameObject.CompareTag("Gold"))
        {
            gold++;
            Destroy(collision.gameObject);
        }
    }
    public Image fillImage;
    public void SetMaxHealth(int maxHealth)
    {
        fillImage.fillAmount = 1f;
    }
    public void SetHealth(float health,float maxHealth)
    {
        float fillAmount = (float)health / (float)maxHealth;
        fillImage.fillAmount = fillAmount;
    }
}
