using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public CircleCollider2D cd;
    // private Player player;
 
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        anim=GetComponentInChildren<Animator>();
        // player=PlayerManager.instance.player;

    }
    public void SetUpSword(Vector2 _dir,float _gravityScale){
        rb.velocity = _dir;
      
        rb.gravityScale = _gravityScale;
    }
}
