using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{   
    //����ϵͳ
    public ParticleSystem particleSystem;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //����E�ͷż���
        if (Input.GetKeyDown(KeyCode.E))
        {
            particleSystem.Play();
        }
    }
}
