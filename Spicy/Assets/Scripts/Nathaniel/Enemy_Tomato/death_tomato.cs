using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Tomato : MonoBehaviour
{
    public Animator anim;

    //for bullet_default to call and Tomoato Enemy dies
    public void Die() 
    {
        Debug.Log("Tomato Hit by Bullet");
        anim.SetBool("isDead", false); //turns on explode animation
        Destroy(gameObject, 1.04f);
        Debug.Log("Tomato Destroyed");
    }


    //for damage against player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collide with Enemy");
            DamagePlayer(collision);
            Debug.Log("Damage Player called");
        }
    }
    void DamagePlayer(Collision2D other)
    {
 /*       insert game objects death_tomato enemy = other.gameObject.GetComponent<death_tomato>();

        if (enemy != null)
        {
            Debug.Log(enemy.name);
            enemy.Die();
        }*/
    }

}
