using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private SpriteRenderer sr;
    // [SerializeField] private float cloneDuration;
    [SerializeField] private float colorLosingSpeed;

    private float cloneTimer;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = .8f;

    private Transform closetEnemy;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cloneTimer -= Time.deltaTime;
        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLosingSpeed));
            if (sr.color.a < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void SetUpClone(Transform _tranform, float _duration, bool _canAttack)
    {
        if (_canAttack)
        {
            anim.SetInteger("CloneAttack", UnityEngine.Random.Range(1, 3));
        }
        gameObject.transform.position = _tranform.position;
        cloneTimer = _duration;

        FaceClosetTarget();
    }
    private void AnimationTrigger()
    {
        cloneTimer = -.1f;
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {

                hit.GetComponent<Enemy>().Damage();
            }
        }
    }
    private void FaceClosetTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .8f);
        float closetDistance = Mathf.Infinity;
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(this.transform.position, hit.transform.position);
                if (distanceToEnemy < closetDistance)
                {
                    closetDistance = distanceToEnemy;
                    closetEnemy = hit.transform;
                }
            }
        }
        if (closetEnemy != null)
        {
            if (transform.position.x > closetEnemy.position.x)
                transform.Rotate(0, 180, 0);
        }
    }
}
