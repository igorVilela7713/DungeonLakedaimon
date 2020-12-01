using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;



	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 150)
		{
			GetComponent<Animator>().SetBool("isEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GetComponent<Animator>().SetBool("die", true);
		Destroy(gameObject, 5);
	}

}
