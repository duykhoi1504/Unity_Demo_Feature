using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    [SerializeField] private float returnSpeed;
    public Animator anim;
    public Rigidbody2D rb;
    public CircleCollider2D cd;
    [SerializeField]private bool canRotate = true;
     [SerializeField]private bool isReturning;

    private Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        anim = GetComponentInChildren<Animator>();
        // player=PlayerManager.instance.player;
        anim.SetBool("Rotation", true);

    }
    public void SetUpSword(Vector2 _dir, float _gravityScale, Player _player)
    {
        player = _player;
        rb.velocity = _dir;

        rb.gravityScale = _gravityScale;
    }
    public void ReturnSword()
    {
        rb.isKinematic = false;
        transform.parent = null;
        isReturning = true;
    }
    private void Update()
    {
        if (canRotate)
        {
            // anim.SetBool("Rotation", false);
            transform.right = rb.velocity;
        }
        if (isReturning)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, returnSpeed * Time.deltaTime);
            if (Vector2.Distance(this.transform.position, player.transform.position) < 2f)
            {
                player.ClearTheSword();
            }
        }
        // if (rb.isKinematic == true)
        // {
        //     transform.position = Vector2.MoveTowards(this.transform.position, PlayerManager.instance.player.transform.position, .1f);
        //     anim.SetBool("Rotation", true);
        //     if (Vector2.Distance(this.transform.position, PlayerManager.instance.player.transform.position) < 2f)
        //     {
        //         Destroy(this.gameObject);
        //     }
        // }
    }
    private void OnTriggerEnter2D(Collider2D collison)
    {
        anim.SetBool("Rotation", false);
        canRotate = false;
        cd.enabled = false;
        // rb.bodyType = RigidbodyType2D.Static;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        this.transform.parent = collison.transform;
    }
}
