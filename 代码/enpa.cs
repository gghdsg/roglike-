using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enpa : Enemy
{
    public float moveRate = 2.5f;
    private float moveTime;
    public float shotRate = 2.5f;
    private float shotTime;
    public GameObject AutoBullet;

    [SerializeField] private float minX, minY, maxX, maxY;

    protected override void Move()
    {
        base.Move();

        moveTime += Time.deltaTime;
        if (moveTime > moveRate&&transform.position.x<=maxX&& transform.position.x>= minX&& transform.position.y>=minY&& transform.position.y<=maxY)
        {
            transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            moveTime = 0;
        }
    }
    public override void Attack()
    {
        base.Attack();
        shotTime += Time.deltaTime;
        if (shotTime > shotRate)
        {
            Instantiate(AutoBullet, transform.position, Quaternion.identity);
            shotTime = 0;
        }
    }
}
