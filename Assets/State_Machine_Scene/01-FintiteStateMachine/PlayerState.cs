using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;
    protected float xInput,yInput;
    private string aniBoolName;
    protected  float stateTimer;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.aniBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        // Debug.Log("I enter " + aniBoolName);
        player.anim.SetBool(aniBoolName,true);
        rb=player.rb;
    }
    public virtual void Update()
    {
        stateTimer-=Time.deltaTime;
        // Debug.Log("I am in " + aniBoolName);
        xInput=Input.GetAxisRaw("Horizontal");
        yInput=Input.GetAxisRaw("Vertical");

        player.anim.SetFloat("yVelocity",rb.velocity.y);

    }
    public virtual void Exit()
    {
        // Debug.Log("I exit " + aniBoolName);
        player.anim.SetBool(aniBoolName,false);


    }
}
