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
    //����ֵ
    public float Benemyhealth1 = 100f;
    public float Bcurrenthealth1;
    public GameObject bulletPrefab;//�ӵ�Ԥ����
    public int fireCount = 10;//������ӵ�����
    public float fanFireRate = 4f;//�������ε�Ļ�ļ��ʱ��
    public float circleFireRate = 10f;//����Բ�ε�Ļ�ļ��ʱ��
    public Transform player;//��ҽ�ɫ��Transform���
    public float Jiechudamage = 1.0f;
    // Start is called before the first frame update

    void Start()
    {
       bERB = GetComponent<Rigidbody2D>();
        //Э��FanFireCoroutine��CircleFireCoroutine�����ڿ������ε�Ļ��Բ�ε�Ļ�ķ���Ƶ�ʡ�
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
    //������ҽ�ɫ�������ε�Ļ
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
    //����Բ�ε�Ļ
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
    //ÿ��һ��ʱ�䷢��һ�����ε�Ļ
    private IEnumerator FanFireCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fanFireRate);
            FireAtPlayer();
        }
    }
    //ÿ��һ��ʱ�䷢��һ��Բ�ε�Ļ��
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
                Debug.Log("��������");
                Destroy(this.gameObject);
                Bdrop();
            }
        }
        else
        {
            Debug.Log("��������");
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
    //��С�����
    public int BgoldMin = 1;
    // �������
    public int BgoldMax = 3;
    // ���Ԥ����
    public GameObject BgoldPrefab;
    // �����ҵİ뾶
    public float BgoldRadius = 0.5f;
    private void Bdrop()
    {
        // ��������
        int goldAmount = Random.Range(BgoldMin, BgoldMax + 1);
        // �ڹ���λ�����ɽ��
        for (int i = 0; i < goldAmount; i++)
        {
            // �ڰ뾶��Χ��������ɽ��λ��
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
                Debug.Log("����ܵ����˺�");
                //Destroy(this.gameObject);
            }
        }
    }
}
