using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anima;

    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();
        //call Direction() since this object has been appeared
        Invoke("Direction", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //moving && animations
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        if (rigid.velocity.normalized.x != 0)
        {
            anima.SetBool("isWalking", true);
        }
        else
        {
            anima.SetBool("isWalking", false);
        }
    }

    //deciding direction
    void Direction()
    {
        //decide left, stop, right
        nextMove = Random.Range(-1, 2);
        //flip the sprites when it facing right side
        if (nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == 1;
        }
        //makes the enemy's direction deciding more randomly
        float nextDirectionTime = Random.Range(2f, 5f);
        //repeat this method itself
        Invoke("Direction", nextDirectionTime);
    }
}
