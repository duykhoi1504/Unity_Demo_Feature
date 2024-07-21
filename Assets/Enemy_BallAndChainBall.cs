using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BallAndChainBall : Entity
{
    // Start is called before the first frame update
    [SerializeField] bool isAttacking;
    [Header("Move Info")]
    [SerializeField]  float moveSpeed;
    [Header("Player Detection Info")]
    [SerializeField] protected float playerCheckDistance;
    [SerializeField] protected LayerMask whatIsPlayer;
    private RaycastHit2D isPlayerDetected;

    protected override void Start()
    {
        base.Start();


    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (isPlayerDetected)
        {
            if (isPlayerDetected.distance > 1)
            {
                
                rigi.velocity = new Vector2(moveSpeed * 1.5f * facingDir , rigi.velocity.y);
                Debug.Log("i see a player");
                isAttacking = false;
            }
            else
            {
                Debug.Log("Attack" + isPlayerDetected.collider.gameObject.name);
                isAttacking = true;
            }
        }

        if (!isOnGround || isWallDetected)
        {
            Flip();
        }

        Movement();
    }

    private void Movement()
    {
        if (!isAttacking)
        {
            rigi.velocity = new Vector2(moveSpeed * facingDir, rigi.velocity.y);
        }   
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();
        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);
        // Debug.DrawRay(transform.position, Vector2.right * playerCheckDistance * facingDir, Color.green);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x+playerCheckDistance*facingDir,transform.position.y) );
    }
}
