using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Rigidbody2D RB;
    public Vector2 wp;
    public GameObject bulletPrefab;
    private float CooldownTime;
    public float CooldownRate = 0.5f;
    public AudioSource attackaudio;
    // Start is called before the first frame update
    void Start()
    {
        CooldownTime = CooldownRate;
    }

    // Update is called once per frame
    void Update()
    {
        //点击鼠标左键发射子弹
        CooldownTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && CooldownTime > CooldownRate)
        {
            Vector2 mousepos = Input.mousePosition;
            wp = Camera.main.ScreenToWorldPoint(mousepos);
            wp = (wp - RB.position).normalized;
            //float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
            CooldownTime = 0;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            BulletController bc = bullet.GetComponent<BulletController>();
            attackaudio.Play();
            if (bc != null)
            {
                bc.Move(wp, 100);
            }
        }
    }
}
