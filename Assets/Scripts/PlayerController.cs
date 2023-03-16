using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // public float maxSpeed = 2.2f;

    public GameObject cutterHitbox;

    Collider2D cuttterCollider;

    // public CutterHitbox cutterAttack;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;

    // public float idleFriction = 0.9f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cuttterCollider = cutterHitbox.GetComponent<Collider2D>();
    }


    private void FixedUpdate() 
    {
        if(canMove == true && movementInput != Vector2.zero){
            if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);
            // rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput *moveSpeed *Time.deltaTime),maxSpeed);
            // }else {
            //     rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            // }
    // }
            if(!success) 
            {
                success = TryMove(new Vector2(movementInput.x, 0));
            
                if(!success) 
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            } 
            animator.SetBool("isMoving", success);
        } 
        else{
            animator.SetBool("isMoving", false);
        }

     }
    }

    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero){
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

                if(count == 0){

                    Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;
                    
                    rb.MovePosition(rb.position + moveVector);
                    return true;
                
                } else {
                    return false;
                }
        }else {
            return false;
        }
    }
    

    // Update is called once per frame
    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();

        if(movementInput != Vector2.zero){
            animator.SetFloat("XInput", movementInput.x);
            animator.SetFloat("YInput", movementInput.y);
        }
    }

    void OnFire() {
        animator.SetTrigger("cutterAttack");
    }

    public void CutterAttack() {
        LockMovement();

        // if(spriteRenderer.flipX == true) {
        //     cutterAttack.AttackLeft();
        // } else {
        //     cutterAttack.AttackRight();
        // }
    }

    public void EndCutterAttack() {
        UnlockMovement();
        // cutterAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }

    
}

