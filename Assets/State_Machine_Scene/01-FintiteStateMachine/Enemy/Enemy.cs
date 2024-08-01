using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity01
{
    public EnemyStateMachine stateMachine { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();

        // Vector2 movement = transform.position;
        //  xInput = Input.GetAxisRaw("Horizontal");
        // float yInput = Input.GetAxisRaw("Vertical");
        // Vector2 input = new Vector2(xInput, yInput);


        // var movement1 = transform.up * move * input.y + transform.right * move * input.x;
        // rb.velocity = movement1;
        // transform.position+=new Vector3(xInput,yInput,0)*move;
        // rb.velocity=new Vector2(xInput,yInput).normalized*move;
        // Debug.Log(new Vector2(xInput,yInput).normalized);
        // Debug.Log("manitie :" + new Vector2(1, 1).normalized.magnitude);
        // Debug.Log(transform.up);
    }
}
