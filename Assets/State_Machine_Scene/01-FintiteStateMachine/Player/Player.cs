using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity01
{
    [Header("Attack details")]
    public float counterAttackDuration=.2f;
    public Vector2[] attackMovement;
    public bool isBusy { get; private set; }
    // public enum State
    // {
    //     Idle,
    //     Move
    // }
    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    [Header("Dash Info")]
    // [SerializeField] private float dashCoolDown;
    // [SerializeField] private float dashUsageTimer;
    public float dashSpeed = 25f;
    public float dashDuration = .5f;
    public float dashDir { get; private set; }

    public SkillManager skill;
    public GameObject sword;



    #region StateMachine
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerCounterAttackState counterAttack { get; private set; }
    public PlayerAimSwordState aimSword { get; private set; }
    public PlayerCatchSwordState catchSword { get; private set; }




    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        aimSword = new PlayerAimSwordState(this, stateMachine, "AimSword");
        catchSword = new PlayerCatchSwordState(this, stateMachine, "CatchSword");




    }
     protected override void Start()
    {
        base.Start();
        skill=SkillManager.instance;
        stateMachine.Initialize(idleState);
        

    }

    // float timer;
    // float coolDown;
     protected override void Update()
    {
         base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();
        // timer-=Time.deltaTime;

        // if (timer <= 0 && Input.GetKey(KeyCode.LeftShift)){
        //     timer=coolDown;
        // }
        // Debug.Log(IsWallDetected());
    }
    public void AssignNewSword(GameObject _newSword){
        sword=_newSword;
    }
    public void ClearTheSword(){
        Destroy(sword);
    }
    public IEnumerator BusyFor(float seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(seconds);
        isBusy = false;
    }
    public void AimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    private void CheckForDashInput()
    {
        if (IsWallDetected())
        {
            return; 
        }

        // dashUsageTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill())
        {
            // dashUsageTimer = dashCoolDown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
            {
                dashDir = faceingDir;
            }
            stateMachine.ChangeState(dashState);
        }
    }






}
