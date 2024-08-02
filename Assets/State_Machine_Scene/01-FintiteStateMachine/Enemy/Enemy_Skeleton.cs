using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    #region  States

    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }


    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeletonIdleState(this, stateMachine, "idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "move", this);
       battleState= new SkeletonBattleState(this, stateMachine, "move", this);
       attackState= new SkeletonAttackState(this, stateMachine, "attack", this);

    }

    protected override void Start()
    {
        base.Start();
         stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
