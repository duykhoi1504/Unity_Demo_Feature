using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    // public enum State
    // {
    //     Idle,
    //     Move
    // }
    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    [Header("Dash Info")]
    [SerializeField] private float dashCoolDown;
    [SerializeField] private float dashUsageTimer;
    public float dashSpeed = 25f;
    public float dashDuration = .5f;
    public float dashDir { get; private set; }


    [Header("Collison info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;


    public int faceingDir { get; private set; } = 1;
    public bool facingRight = true;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region StateMachine
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallState { get; private set; }

    public PlayerDashState dashState { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }


    #endregion

    private void Awake()
    {

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");


    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);

    }

    // float timer;
    // float coolDown;
    private void Update()
    {
        stateMachine.currentState.Update();
        CheckForDashInput();
        // timer-=Time.deltaTime;

        // if (timer <= 0 && Input.GetKey(KeyCode.LeftShift)){
        //     timer=coolDown;
        // }
        Debug.Log(IsWallDetected());
    }
    private void CheckForDashInput()
    {
        if(IsWallDetected())
        {
            return; 
        }
            
        dashUsageTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCoolDown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
            {
                dashDir = faceingDir;
            }
            stateMachine.ChangeState(dashState);
        }
    }
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * faceingDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    private void Flip()
    {
        faceingDir = faceingDir * -1;
        facingRight = !facingRight;
        //this.transform.localScale = new Vector2(faceingDir, 1);
        this.transform.Rotate(0, 180, 0);
    }
    private void FlipController(float _xVelocity)
    {
        if (_xVelocity > 0 && !facingRight)
            Flip();
        else if (_xVelocity < 0 && facingRight)
            Flip();
    }
}
