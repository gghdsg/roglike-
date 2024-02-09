using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    Rigidbody2D circle;
    public float LifeTime=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        circle = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDestroy()
    {
        Destroy(this.circle);
    }
}
