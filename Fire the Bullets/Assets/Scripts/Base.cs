using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public SimpleHealthBar healthBar;

    public float startLife;
    public float currentLife;
    public float maxHealth;

    void Start()
    {
        currentLife = startLife;
        healthBar.UpdateBar(currentLife, maxHealth);
    }

    public void Hit(int damage)
    {
        currentLife -= damage;
        Debug.Log("currentLifeBase" + currentLife);

        healthBar.UpdateBar(currentLife, maxHealth);

        //if (currentLife >= 0)
        //{
        //    //currentLifeSprite.size = new Vector2(currentLifeSprite.size.x - (currentLifeSpriteWidth * damageAmount), currentLifeSpriteHight);
        //}
        //else
        //{
        //    Die();
        //}

        if (currentLife <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
