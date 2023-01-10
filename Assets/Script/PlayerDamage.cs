using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage; 
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if(collision.collider.gameObject.transform.tag == "WeakPoint")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage*2);
        }
    }
}
