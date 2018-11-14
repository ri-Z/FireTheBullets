using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float startLife;
    public float currentLife;

    public SpriteRenderer currentLifeSprite;
    public float currentLifeSpriteWidth = 2.1f;
    public float currentLifeSpriteHight = 0.73f;

    void Start()
    {
        currentLife = startLife;
        currentLifeSprite.size = new Vector2(currentLifeSpriteWidth, currentLifeSpriteHight);
    }

    public void Hit(EnemyBullet bullet)
    {
        float damageAmount = bullet.damage / startLife;

        currentLife -= bullet.damage;

        if (currentLife >= 0)
        {
            currentLifeSprite.size = new Vector2(currentLifeSprite.size.x - (currentLifeSpriteWidth * damageAmount), currentLifeSpriteHight);
            GameUIManager.instance.UpdatePlayerLife();
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
