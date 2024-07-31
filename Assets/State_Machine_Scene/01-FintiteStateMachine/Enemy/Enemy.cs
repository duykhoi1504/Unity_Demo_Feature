using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float move;
    Rigidbody2D rb;
     public IdleState idleState;
     public MoveState moveState;
public float xInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         idleState=new IdleState(this);
         moveState=new MoveState(this);
 EnemyStateMachine.Instance.initState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
       
        EnemyStateMachine.Instance.currentState.Update();
        
        Vector2 movement = transform.position;
         xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(xInput, yInput);

        
        // var movement1 = transform.up * move * input.y + transform.right * move * input.x;
        // rb.velocity = movement1;
        // transform.position+=new Vector3(xInput,yInput,0)*move;
        // rb.velocity=new Vector2(xInput,yInput).normalized*move;
        // Debug.Log(new Vector2(xInput,yInput).normalized);
        // Debug.Log("manitie :" + new Vector2(1, 1).normalized.magnitude);
        // Debug.Log(transform.up);
    }
}
