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
			private float damage = 0.5f;



			private void Start()
			{
				Destroy(this.gameObject, 3.0f);
			}



			private void OnTriggerEnter(Collider other)
			{

				Debug.Log(other.gameObject.name);

				if(other.tag == "Bullet")
				{
					return;
				}

				Character.IDamageable iDamageable = other.gameObject.GetComponent<Character.IDamageable>();

				if (iDamageable != null)
				{
					Debug.Log("damage!");
					iDamageable.ApplyDamage(damage);
				}


				Destroy(this.gameObject);
			}
		}
	}
}