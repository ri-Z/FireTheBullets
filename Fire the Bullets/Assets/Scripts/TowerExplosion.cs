using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExplosion : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void hitTarget()
    {
        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode(){
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders2D)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy){
        Destroy(enemy.gameObject);
        //enemy.gameObject.
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
