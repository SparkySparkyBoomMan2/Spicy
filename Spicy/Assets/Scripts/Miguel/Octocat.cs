using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octocat : MonoBehaviour
{
    private float time;             // Current time between attacks 
    public float attackWaitTime;    // Wait time before octocat can attack (can be modified in inspector)
    public Transform attackPoint1;  // Attack point for downwards projectile
    public Transform attackPoint2;  // Attack point for downwards right projectile
    public Transform attackPoint3;  // Attack point for downwards left projectile
    public Transform attackPoint4;  // Attack point for left low projectile
    public Transform attackPoint5;  // Attack point for right low projectile
    public Transform attackPoint6;  // Attack point for left high projectile
    public Transform attackPoint7;  // Attack point for right high projectile
    public Transform attackPoint8;  // Attack point for moderately downwards right projectile
    public Transform attackPoint9;  // Attack point for moderately downwards left projectile
    public Transform attackPoint10; // Attack point for slightly downwards right projectile
    public Transform attackPoint11; // Attack point for slightly downwards left projectile
    public GameObject projectile;   // Octocat projectile
    public int health = 30;         // Octocat health
    public SpriteRenderer rend;     // For changing sprite color when damaged
    Color orignal;                  // For keeping original sprite color
    public GameObject defeated;     // Animation object that will play if player defeats the octocat
    IAttack attack = new Attack();  // Used for decorator pattern

    // Start is called before the first frame update
    void Start()
    {
        time = attackWaitTime;      // Set wait time
        orignal = rend.color;       // Get the original color of the sprite
    }

    // Update is called once per frame
    void Update()
    {
        // If else statement for spacing out attacks from octocat
        if (time <= 0)
        {
            Attack();
            if(attack.ReturnAttack() == 4 || attack.ReturnAttack() == 5)
            {
                StartCoroutine(MultiAttack());
            }
            time = attackWaitTime;
        }
        else
            time -= Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If octocat is hit decrease health
        //     Also indicate damage by briefly turning sprite red 
        //     Additionally change octocat attacks based on remaining health
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            rend.color = Color.red;
            Invoke(nameof(ResetColor), 0.5f);
            // Decorator pattern here
            if (health == 28)
            {
                attack = new Attack1(attack);   // Shoot 3 projectiles
            }
            else if (health == 24)
            {
                attack = new Attack2(attack);   // Shoot 5 projectiles
            }
            else if (health == 20)
            {
                attack = new Attack3(attack);   // Shoot 9 projectiles
            }
            else if (health == 16)
            {
                attack = new Attack4(attack);   // Shoot 9 * 3 (27) projectiles
            }
            else if (health == 10)
            {
                attack = new Attack5(attack);   // Shoot 31 projectiles
            }
            // Ocotcat defeated
            //     Deactivate octocat, instantiate animated object 'defeated', and destroy game object
            else if (health <= 0)
            {
                this.gameObject.SetActive(false);
                Instantiate(defeated, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    // Used for invoking sprite color back to it original color
    void ResetColor()
    {
        rend.color = orignal;
    }

    // Instantiates multiple attacks
    public IEnumerator MultiAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Attack();
        yield return new WaitForSeconds(0.2f);
        Attack();
        if(attack.ReturnAttack() == 5)
        {
            yield return new WaitForSeconds(0.7f);
            Instantiate(projectile, attackPoint10.position, attackPoint10.rotation);
            Instantiate(projectile, attackPoint11.position, attackPoint11.rotation);
            yield return new WaitForSeconds(0.2f);
            Instantiate(projectile, attackPoint10.position, attackPoint10.rotation);
            Instantiate(projectile, attackPoint11.position, attackPoint11.rotation);
        }
    }

    // Octocat's attack that changes based on decorator pattern's ReturnAttack() function
    public void Attack()
    {
        if(attack.ReturnAttack() >= 0)
            Instantiate(projectile, attackPoint1.position, attackPoint1.rotation);
        if(attack.ReturnAttack() >= 1)
        {
            Instantiate(projectile, attackPoint2.position, attackPoint2.rotation);
            Instantiate(projectile, attackPoint3.position, attackPoint3.rotation);
        }
        if(attack.ReturnAttack() >= 2)
        {
            Instantiate(projectile, attackPoint4.position, attackPoint4.rotation);
            Instantiate(projectile, attackPoint5.position, attackPoint5.rotation);
        }
        if (attack.ReturnAttack() >=3)
        {
            Instantiate(projectile, attackPoint6.position, attackPoint6.rotation);
            Instantiate(projectile, attackPoint7.position, attackPoint7.rotation);
            Instantiate(projectile, attackPoint8.position, attackPoint8.rotation);
            Instantiate(projectile, attackPoint9.position, attackPoint9.rotation);
        }
    }
}

// Base interface
interface IAttack
{
    int ReturnAttack();
}

// Concrete implementation
class Attack : IAttack
{
    public int ReturnAttack()
    {
        return 0;
    }
}

// Base decorator
class AttackDecorator : IAttack
{
    private IAttack _attack;

    public AttackDecorator(IAttack attack)
    {
        _attack = attack;
    }

    public virtual int ReturnAttack()
    {
        return _attack.ReturnAttack();
    }
}

// Concerte Decorators
class Attack1 : AttackDecorator
{
    public Attack1(IAttack attack) : base(attack) { }

    public override int ReturnAttack()
    {
        return 1;
    }
}
class Attack2 : AttackDecorator
{
    public Attack2(IAttack attack) : base(attack) { }

    public override int ReturnAttack()
    {
        return 2;
    }
}
class Attack3 : AttackDecorator
{
    public Attack3(IAttack attack) : base(attack) { }

    public override int ReturnAttack()
    {
        return 3;
    }
}
class Attack4 : AttackDecorator
{
    public Attack4(IAttack attack) : base(attack) { }

    public override int ReturnAttack()
    {
        return 4;
    }
}
class Attack5 : AttackDecorator
{
    public Attack5(IAttack attack) : base(attack) { }

    public override int ReturnAttack()
    {
        return 5;
    }
}

