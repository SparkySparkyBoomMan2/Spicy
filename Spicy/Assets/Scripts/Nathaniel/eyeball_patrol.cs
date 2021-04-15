using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeball_patrol : MonoBehaviour
{
    public float flySpeed = 1f;
    public float rangeAttack;
    public float rateOfFire = 1f;
    private float nextFire;
    private float distanceFromPlayer;

    [HideInInspector]
    public bool isPatrol;
    private bool isFlip;

    public Rigidbody2D rg2d;
    public Transform isObjectCheck;
    public LayerMask wallLayer;
    public LayerMask enemyLayer;
    public Collider2D bodyCollider;
    private Transform player;

    public GameObject projectile;
    public GameObject projectileParent;

    // Start is called before the first frame update
    void Start()
    {
        isPatrol = true;
        player = GameObject.FindGameObjectWithTag("Gun").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrol)
        {
            Patrol();
        }
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);//calcs distance between eyeball guy and player
        
        Debug.Log("Distant from player " + distanceFromPlayer);

        if(distanceFromPlayer <= rangeAttack)
        {
            Debug.Log("Is within player range");
            if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0) //flips to player direction
            {
                Flip();
            }
            isPatrol = false;
            //rg2d.velocity = Vector2.zero;
            Attack();
        }
        else
        {
            isPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        if (isPatrol)
        {
            isFlip = Physics2D.OverlapCircle(isObjectCheck.position, 0.1f, wallLayer); 
        }
    }

    //controls eyeball patrol movement
    void Patrol()
    {
        if (isFlip || bodyCollider.IsTouchingLayers(wallLayer) || bodyCollider.IsTouchingLayers(enemyLayer))
        {
            Flip();
        }
        rg2d.velocity = new Vector2(flySpeed * Time.fixedDeltaTime, rg2d.velocity.y);
    }

    //flips patrolling 
    void Flip()
    {
        isPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        flySpeed *= -1;
        isPatrol = true;
    }

    //fire eyeball at player location with controlling rate of fire
    void Attack()
    {
        //attack player
        if (nextFire < Time.time)
        {
            Instantiate(projectile, projectileParent.transform.position, Quaternion.identity);
            nextFire = Time.time + rateOfFire;
        }

    }

    //create sight zone for enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }

    //to be called by gun script
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
