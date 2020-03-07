using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	namespace Weapon
	{
		public class Bullet : MonoBehaviour
		{
			[SerializeField]
			private float damage;

			private void Start()
			{
				Destroy(this.gameObject, 10.0f);
			}

			private void OnTriggerEnter(Collider other)
			{
				if(other.tag == "Bullet")
				{
					return;
				}

				Character.IDamageable iDamageable = other.gameObject.GetComponent<Character.IDamageable>();

				if (iDamageable != null)
				{
					iDamageable.ApplyDamage(damage);
				}

				Destroy(this.gameObject);
			}
		}
	}
}