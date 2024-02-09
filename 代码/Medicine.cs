using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (pc.currenthealth < pc.health && pc.currenthealth > 0)
            {
                pc.increasehealth();
                Debug.Log("玩家恢复一定血量");
                Destroy(gameObject);
            }
                
        }
    }
}
