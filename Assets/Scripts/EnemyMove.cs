using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    public Transform home_position;
    [SerializeField] private float speed, range;
    
    private float waitToHurt = 1f;
    private bool isTouching =false;
    [SerializeField] private int damage_received;
    private HealthManager healthManager;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthManager = FindObjectOfType<HealthManager>();
    }

     void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) <= range)
        {
            followPlayer();
        }
        else if(Vector2.Distance(target.position, transform.position) >= range)
        {
            goToHome();
        }

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManager.hurtPlayer(damage_received);
                waitToHurt = 2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().hurtPlayer(damage_received);
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
    private void followPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        Vector2 direction = new Vector2(transform.position.x, transform.position.y);
        FindObjectOfType<EnemyAnimation>().setDirection(direction);
    }
    private void goToHome()
    {
        transform.position = Vector2.MoveTowards(transform.position, home_position.position, speed * Time.deltaTime);
        Vector2 direction = new Vector2(transform.position.x, transform.position.y);
        FindObjectOfType<EnemyAnimation>().setDirection(direction);
    }
}
