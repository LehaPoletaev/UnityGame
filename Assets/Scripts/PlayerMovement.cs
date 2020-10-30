using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpead = 1.0f;

    private bool isAttacking=false;
    private float attackcounter = .20f;
    private float attacktime = .20f;
   
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpead;
        moveV = Input.GetAxis("Vertical") * moveSpead;
        rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);
        // 
        if (isAttacking)
        {
            attackcounter -= Time.deltaTime;
            if (attackcounter <= 0)
            {
                isAttacking = false;
            }        
        }
        if (Input.GetKeyDown(KeyCode.Space))//&&(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.RightArrow)))
        {
          
            Debug.Log(direction);
            isAttacking = true;
            attackcounter = attacktime;
        }
         FindObjectOfType<PlayerAnimation>().setDirection(direction,isAttacking);
        }
      
      

        
    }
 


