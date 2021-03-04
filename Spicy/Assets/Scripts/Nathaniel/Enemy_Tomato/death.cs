using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    Animator animator;

    public void Die() //kills tomato enemy
    {
        animator.SetBool("isDead", false); //turns on explode animation
        Destroy(gameObject, 1.04f);
    }

}
