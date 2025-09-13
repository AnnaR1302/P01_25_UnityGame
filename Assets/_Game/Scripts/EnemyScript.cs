using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    private BoxCollider2D enemy_BoxCollider;
    public Rigidbody2D rb;
    public GameObject TurnEnemyA;
    public GameObject TurnEnemyB;
    private Animator anim;
    private Transform currentPoint;
    public int EnemySpeed = 5;
    public Player pHealth;
    public float damage;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        enemy_BoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        currentPoint = TurnEnemyB.transform;
        anim.SetBool("isRunning", true);
    }

    private void Update()
    {
        rb.velocity = transform.right * EnemySpeed;
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == TurnEnemyB.transform)
        {
            rb.velocity = new Vector2(EnemySpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-EnemySpeed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == TurnEnemyB.transform)
        {
            flip();
            currentPoint = TurnEnemyA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == TurnEnemyA.transform)
        {
            flip();
            currentPoint = TurnEnemyB.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().health -= damage;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(TurnEnemyA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(TurnEnemyB.transform.position, 0.5f);
        Gizmos.DrawLine(TurnEnemyA.transform.position, TurnEnemyB.transform.position);
    }

}
