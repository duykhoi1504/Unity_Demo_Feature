using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    Rigidbody2D rigi;
    Animator ani;
    Vector3 movement;
    [SerializeField] bool isMoving;
    float moveX, hp, timeCount;
    private bool isFacingRight = true;

    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float speed = 4f;

    [SerializeField] private bool isFlip = true;


    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isOnGround;

    [Header("Dash Info")]
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer;

    [Header("Attack Info")]
    [SerializeField] private float comboTime = .3f;
    [SerializeField] private float comboTimeWindow;
    [SerializeField] private bool isAttacking;
    [SerializeField] private int comboCounter;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        checkInput();
        CollisionChecks();
        Flip();


        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeWindow -= Time.deltaTime;



        AnimationController();

    }

    private void CollisionChecks()
    {
        isOnGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        Debug.Log(isOnGround);
    }


    public void AttackingOver()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter >= 2)
        {
            comboCounter = 0;
        }

    }
    void checkInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            Jumping();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
           PrefabManager.Instance.UseAbility(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           PrefabManager.Instance.UseAbility(1);
        }

    }

    private void StartAttackEvent()
    {
        if(!isOnGround)return;
        if (comboTimeWindow < 0)
        {
            comboCounter = 0;
        }
        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    void DashAbility()
    {
        if (dashCooldownTimer < 0 && !isAttacking)
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }
    void Moving()
    {
        if(isAttacking){
            rigi.velocity=new Vector2(0,0);
        }
        else if (dashTime > 0)
        {
            rigi.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        }
        else
        {
            rigi.velocity = new Vector2(moveX * speed, rigi.velocity.y);
        }
    }
    void AnimationController()
    {
        //#1
        // if(moveX!=0){
        //     ani.SetBool("isMoving",true);
        // }else{
        //     ani.SetBool("isMoving",false);

        // }
        //#2
        // if(rigi.velocity.x!=0){
        //     isMoving=true;
        // }else{
        //     isMoving=false;
        // }
        //#3
        isMoving = rigi.velocity.x != 0;
        ani.SetFloat("yVelocity", rigi.velocity.y);
        ani.SetBool("isMoving", isMoving);
        ani.SetBool("isOnGround", isOnGround);
        ani.SetBool("isDashing", dashTime > 0);
        ani.SetBool("isAttacking", isAttacking);
        ani.SetInteger("comboCounter", comboCounter);

    }
    void Jumping()
    {

        // isOnGround = false;
        // rigi.AddForce(new Vector2(0, jumpForce));
        rigi.velocity = new Vector2(rigi.velocity.x, jumpForce);

    }
    // private void OnCollisionEnter2D(Collision2D other) {
    //     isOnGround=true;
    // }

    void Flip()
    {
        //#1
        // if ((isFacingRight && moveX < 0 )|| (!isFacingRight && moveX > 0))
        // {
        //     isFacingRight = !isFacingRight;
        //     Vector3 size = transform.localScale;
        //     size.x = size.x * -1;
        //     transform.localScale = size;

        // }
        //#2
        if (moveX > 0)
            transform.localScale = Vector3.one;
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    private void OnDrawGizmos()
    {
        // Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
        //or dung
        //// Debug.DrawRay(transform.position,Vector2.down*groundCheckDistance,Color.red);
    }

}
