using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 7.0f;
    [SerializeField] private float jumpPower = 12.0f;
    private bool isContacted;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anima;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        if (isContacted == true)
        {
            Input.GetAxisRaw("Horizontal");
            return;
        }
        //animation direction   
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        //animations
        if (Input.GetButtonUp("Horizontal"))
        {
            anima.SetBool("isWalking", false);
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            anima.SetBool("isWalking", true);
        }
        //jump & and its animation
        if (Input.GetButtonDown("Jump") && !anima.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anima.SetBool("isJumping", true);
        }
        //Detect landing on platform & turn off jumping animation
        if (rigid.velocity.y < 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    anima.SetBool("isJumping", false);
                }
            }
        }
        //stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //movement speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        //max speed
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < (-1 * maxSpeed))
        {
            rigid.velocity = new Vector2((-1 * maxSpeed), rigid.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            InContact(collision.transform.position);
        }
    }
    
    void InContact(Vector2 targetPos)
    {
        isContacted = true;
        //change layer to avoid additional contact while player being pushed
        gameObject.layer = 11;
        //display player got hit by enemy
        spriteRenderer.color = new Color(1, 1, 1, .4f);
        //reaction force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc,1) * 5, ForceMode2D.Impulse);
        //call OutContact() to turn player back to normal state
        Invoke("OutContact", .75f);
    }
    void OutContact()
    {
        isContacted = false;
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
