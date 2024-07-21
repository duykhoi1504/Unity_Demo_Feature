using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update

    protected Rigidbody2D rigi;
    protected Animator ani;

    [Header("Collision Info")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    [SerializeField] protected Transform groundCheck;

    [Space]
    [SerializeField] protected float wallCheckDistance;

    [SerializeField] protected Transform wallCheck;


    [SerializeField] protected bool isOnGround;
    [SerializeField] protected bool isWallDetected;
    [Header("Flip Info")]
    [SerializeField]protected bool facingRight=true;
    protected int facingDir=1;
    protected virtual void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        if(wallCheck==null){
            wallCheck=this.transform;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CollisionChecks();

    }


    protected virtual void CollisionChecks()
    {
        isOnGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * transform.localScale.x, whatIsGround);
        // Debug.Log(isOnGround);
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * transform.localScale.x, wallCheck.position.y));

        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
        //or dung
        //// Debug.DrawRay(transform.position,Vector2.down*groundCheckDistance,Color.red);
    }

    protected virtual void Flip()
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
        // if (rigi.velocity.x > 0)
        //     transform.localScale = Vector3.one;
        // else if (rigi.velocity.x < 0)
        //     transform.localScale = new Vector3(-1, 1, 1);
        //#3
        facingDir=facingDir*-1;
        facingRight=!facingRight;
         transform.localScale = new Vector3(facingDir, 1, 1);
    }
}
