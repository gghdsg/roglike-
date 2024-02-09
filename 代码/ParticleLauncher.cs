using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{   
    //粒子系统
    public ParticleSystem particleSystem;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //按下E释放技能
        if (Input.GetKeyDown(KeyCode.E))
        {
            particleSystem.Play();
        }
    }
}
