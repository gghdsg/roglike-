using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �������
/// </summary>
/// 

public class PlayerController : MonoBehaviour
{
    Rigidbody2D RB;
    public GameObject deathPanel;
    public AudioSource attackaudio;
    public AudioSource failaudio;

    //����ƶ��ٶ�
    public float speed = 5f;

    //�ӵ�
    public GameObject bulletPrefab;

    //public int m;
    public float Timer = 0f;

    //����ֵ
    //������ֵ
    public float health =40f;
    //��ǰ����ֵ
    public float currenthealth;
    public float MyHealth { get { return health; } }
    public float MyCurrentHealth { get { return currenthealth; } }
    //��ҳ���Ĭ��Ϊ�ҷ�
    public Vector2 lookDirection = new Vector2(1, 0);
    public GameObject circle;
    AnimatorController animatorPlay;
    //�޵�ʱ��
    public float pTime = 0.25f;
    public float ptimer;
    private bool isInvicible;//�Ƿ����޵�״̬
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
        //��������������ӵ�
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
        //ʹ����Ƥ����������ͣ��Ļ�������ӵ������˵��˵�Ч��

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
        //�޵м�ʱ============
        if (isInvicible)
        {
            ptimer -= Time.deltaTime;
            if (ptimer < 0)
            {
                isInvicible = false;//��ʱ��ϣ�ȡ���޵�״̬
            }
        }
        SetHealth(currenthealth, health);

    }
    //==========�������ֵ����=========
    //���˹���ʹ����ֵ����
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
            //�������ֵ���ӵ�ʱ����Ҫ��Լ�������ֵ��0֮��
            currenthealth = Mathf.Clamp(currenthealth - num, 0, health);
            Debug.Log(currenthealth + "/" + health);
            animatorPlay.PlayHurt();
            animatorPlay.PlayIdle();
            if (currenthealth <= 0)
            {
                fillImage.fillAmount = 0f;
                animatorPlay.PlayDie();
                Debug.Log("���������");
                deathPanel.SetActive(true);;
                failaudio.Play();
            }
        }
        else
        {
            animatorPlay.PlayDie();
            Debug.Log("���������");
            deathPanel.SetActive(true);
        }
    }
    //����ʹ����ֵ����
    public void increasehealth()
    {
        if (currenthealth < health && currenthealth > 0)
        {
            //�������ֵ���ӵ�ʱ����Ҫ��Լ�������ֵ��0֮��
            currenthealth = Mathf.Clamp(currenthealth + 4, 0, health);
            Debug.Log(currenthealth + "/" + health);
        }

    }
    private void Move()
    {
        //��ҵĳ������������
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
        //========����ƶ�======
         float moveX = Input.GetAxis("Horizontal");
         float moveY = Input.GetAxis("Vertical");
         RB.velocity = speed * new Vector2(moveX * speed, moveY * speed).normalized;
    }
    // ��ʼ�����
    public int gold =0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������ң��������1�������ٽ��
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
