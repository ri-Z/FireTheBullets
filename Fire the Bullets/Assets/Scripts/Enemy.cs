using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float initialLife;
    public float currentLife;

    void Start()
    {
        currentLife = initialLife;
    }

    public void Hit(float damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
