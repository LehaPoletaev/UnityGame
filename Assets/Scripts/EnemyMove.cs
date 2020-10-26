using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    [SerializeField]  private float speed,range;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

     void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) <= range)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            Vector2 direction = new Vector2(transform.position.x, transform.position.y);
            FindObjectOfType<EnemyAnimation>().setDirection(direction);
        }
    }
}
