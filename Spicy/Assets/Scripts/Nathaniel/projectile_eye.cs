using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_eye : MonoBehaviour
{
    GameObject target;
    public float speedProjectile;
    Rigidbody2D rigidProjectile;
    Transform projPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        rigidProjectile = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Gun");
        Vector2 moveTowardsPosition = (target.transform.position - transform.position) * speedProjectile;
        rigidProjectile.velocity = new Vector2(moveTowardsPosition.x, moveTowardsPosition.y);
        Destroy(this.gameObject, 2);
    }
}
