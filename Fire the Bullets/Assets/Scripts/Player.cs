using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float currentScore = 0;

    public float startLife;
    public float currentLife;

    public SpriteRenderer currentLifeSprite;
    public float startLifeSpriteWidth;
    public float currentLifeSpriteWidth = 2.1f;
    public float currentLifeSpriteHight = 0.73f;

    void Start()
    {
        currentLifeSpriteWidth = startLifeSpriteWidth;
        currentLife = startLife;
        currentLifeSprite.size = new Vector2(currentLifeSpriteWidth, currentLifeSpriteHight);
    }

    public void Hit(EnemyBullet bullet)
    {
        float damageAmount = bullet.damage / startLife;

        currentLife -= bullet.damage;

		if( currentLife <= 0 ){
			currentLife = 0;
			currentLifeSprite.size = new Vector2(0, currentLifeSpriteHight);
			Die();
		}else if (currentLife > 0){
            currentLifeSprite.size = new Vector2(currentLifeSprite.size.x - (startLifeSpriteWidth * damageAmount), currentLifeSpriteHight);
        }

		GameUIManager.instance.UpdatePlayerLife();
    }

    public void healHit(float heal)
    {
        float healAmount = heal / startLife;
        currentLife += heal;

		if( currentLife >= startLife ){
			currentLife = startLife;
			currentLifeSprite.size = new Vector2(startLifeSpriteWidth, currentLifeSpriteHight);
		}else if (currentLife < startLife){
            currentLifeSprite.size = new Vector2(currentLifeSprite.size.x + (startLifeSpriteWidth * healAmount), currentLifeSpriteHight);
        }

		GameUIManager.instance.UpdatePlayerLife();
    }

    public void Die()
    {
		GameManager.instance.GameOver();
    }

	public void addScore(float score){
		currentScore += score;
	}
}
