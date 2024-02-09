using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.SetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("LookUp", true);
        }
        else
        {
            animator.SetBool("LookUp", false);
        }
    }
    public void PlayHurt()
    {
        animator.SetTrigger("hurt");
    }
    public void PlayDie()
    {
        animator.SetTrigger("die");
    }
    public void PlayIdle()
    {
        animator.SetTrigger("idle");
    }
}
