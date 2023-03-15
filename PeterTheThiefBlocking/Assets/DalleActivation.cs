using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalleActivation : MonoBehaviour
{
    public Animator animator;
    public Animator porteAnim;
    public bool isColliding;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Caisse"))
        {
            isColliding = true;
            animator.SetBool("Collision", isColliding);
            porteAnim.SetBool("porte", isColliding);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Caisse"))
        {
            isColliding = false;
            animator.SetBool("Collision", isColliding);
            porteAnim.SetBool("porte", isColliding);
        }
    }
}