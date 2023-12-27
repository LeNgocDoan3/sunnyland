using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float playerStrength; 
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Animator anim;
    public float jumpForce;
    private BoxCollider2D coll;
    public LayerMask jumpableGround;

    private enum MovementState {idle, run, fall, jump, climp, hurt,duck}
    public AudioSource jump;
    private float driX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        driX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(driX * playerStrength/2, rb.velocity.y);
       
       if(Input.GetButtonDown("Jump")&& IsGrouded())
       {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

       } 
        UpdateAnimationUpdate();
       
          
    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if(driX > 0f)
       {
        state = MovementState.run;
        sprite.flipX = false;
       }
       else if(driX < 0f) 
       {
        state = MovementState.run;
        sprite.flipX =true;
       }
       else
       {
        state = MovementState.idle;
       }
       if(rb.velocity.y >1f)
       {
        state = MovementState.jump;
       }
       else if (rb.velocity.y< -.1f)
       {
        state = MovementState.fall;
       }
       
       anim.SetInteger("state",(int)state);
    }
    private bool IsGrouded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f, Vector2.down,1f, jumpableGround);
    }
  
}
