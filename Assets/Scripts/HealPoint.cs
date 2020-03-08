using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod
{
	namespace Character
	{
		public class HealPoint : MonoBehaviour
		{
			[SerializeField]
			private float existTime;
			[SerializeField]
			private float healPoint = 100.0f;

			private float deltaTime;
			private int nowTime;


			private void Update()
			{
				this.gameObject.transform.Rotate(new Vector3(0, 5, 0));
				deltaTime += Time.deltaTime;
				nowTime = (int)deltaTime;
				if (nowTime > existTime)
				{
					GetComponent<MeshRenderer>().enabled = true;
					GetComponent<BoxCollider>().enabled = true;
				}
			}

			void OnCollisionEnter(Collision collision)
			{
				IDamageable idamageable = collision.gameObject.GetComponent<IDamageable>();

				if (idamageable != null)
				{
					idamageable.ApplyDamage(-healPoint);
					Destroy(this.gameObject);
				}
			}

		}
	}
}
