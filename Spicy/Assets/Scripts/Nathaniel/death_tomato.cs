using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_tomato : MonoBehaviour
{
    public Animator animator;

    //for bullet_default to call and Tomoato Enemy dies
    public void Die() 
    {
        Debug.Log("Tomato Hit by Bullet");
        animator.SetBool("isDead", false); //turns on explode animation
        Destroy(gameObject, 1.04f);
        Debug.Log("Tomato Destroyed");
    }


    //for damage against player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collide with Enemy");
            DamagePlayer(collision);
            Debug.Log("Damage Player called");
        }
    }
    //Handles killing player
    void DamagePlayer(Collision2D other)
    {
        Death_Player player = other.gameObject.GetComponent<Death_Player>();

        if (player != null)
        {
            Debug.Log(player.name);
            player.DiePlayer();
        }
    }

}
