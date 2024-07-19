using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     // Start is called before the first frame update
    [SerializeField] float hitPoint = 50f;
    [SerializeField] bool isDead=false;
   [SerializeField] GameObject deathFX;
  [SerializeField] GameObject hitVFX;
  
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void TakeDamage(float damage)
    {
         GameObject impact = Instantiate(hitVFX, this.transform.position, Quaternion.identity);
        Destroy(impact, 2);
        hitPoint -= damage;
          BroadcastMessage("OnDamageTaken");
        if (hitPoint < 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isDead) return;
        isDead = true;
        GameObject impactDead = Instantiate(deathFX, this.transform.position, Quaternion.identity);
        Destroy(impactDead, 2);
         Destroy(gameObject);
    }
}
