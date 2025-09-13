using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private BoxCollider2D enemy_BoxCollider;
    public Rigidbody2D rb;
    public int EnemySpeed = 5;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        enemy_BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        rb.velocity = transform.right * EnemySpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().health -= 1;
            Debug.Log(collision.GetComponent<Player>().health);
        }
    }

}
