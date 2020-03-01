using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
	public class Bullet : MonoBehaviour
	{

		private float damage = 0.5f;



		private void Start()
		{
			Destroy(this.gameObject, 3.0f);
		}



		private void OnCollisionEnter(Collision other)
		{
			Character.IDamageable iDamageable = other.gameObject.GetComponent<Character.IDamageable>();

			if (iDamageable != null)
			{
				iDamageable.ApplyDamage(damage);
			}


			Destroy(this.gameObject);
		}
	}
}
