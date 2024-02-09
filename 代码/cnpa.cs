using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnpa : Enemy
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (pc.MyCurrentHealth > 0)
            {
                pc.losehealth(1);
                Debug.Log("玩家受到了伤害");
                //Destroy(this.gameObject);
            }
        }
    }
}
