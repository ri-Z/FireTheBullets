using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealer : MonoBehaviour{

    private Transform target;

    public float speed = 70f;

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
        Destroy(gameObject);
    }
}
