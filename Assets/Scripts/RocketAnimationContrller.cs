using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimationContrller : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void DestroyAnimation()
    {
        animator.SetBool("isEnd", true);
    }
}
