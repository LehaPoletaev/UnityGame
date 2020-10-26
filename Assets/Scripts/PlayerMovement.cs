using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpead = 1.0f;

   
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpead;
        moveV = Input.GetAxis("Vertical") * moveSpead;
        rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);
       // Debug.Log(direction);
        FindObjectOfType<PlayerAnimation>().setDirection(direction);
    }

}
