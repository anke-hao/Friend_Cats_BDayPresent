using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public bool diagonalLeft;
    public bool diagonalRight;
    public float changeTime = 3.0f;
    public float decrement = 0.0001f;
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (speed > 0) {
            speed -= decrement;

        }
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            animator.SetFloat("speed", speed);
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else if (diagonalRight) 
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", direction);
            animator.SetFloat("speed", speed);
            position.x = position.x + Time.deltaTime * speed * direction;
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else if (diagonalLeft) 
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", -direction);
            animator.SetFloat("speed", speed);
            position.x = position.x + Time.deltaTime * speed * direction;
            position.y = position.y + Time.deltaTime * speed * -direction;
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            animator.SetFloat("speed", speed);
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        
        rigidbody2D.MovePosition(position);
    }
}
