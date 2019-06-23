using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamenAnimateC : MonoBehaviour {

    public static Animator animator;
    // Use this for initialization

    void Start()
    {
        animator = GetComponent<Animator>();


    }
    public void startAnimation()
    {
        animator.Play("RamenMoving");
    }
}
