using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Enemy
		{
			public class NPCStatus : MonoBehaviour,IDamageable
			{
				private float hp;
				private float maxHp = 30.0f;

				private GameObject hpBar;
				private Slider slider;

				private void Start()
				{
					hp = maxHp;
					hpBar = this.gameObject.transform.Find("HPBar").gameObject;
					slider = hpBar.transform.Find("Slider").gameObject.GetComponent<Slider>();
				}

				private void Update()
				{
					slider.value = hp / maxHp;
					if (hp <= 0)
					{
						Destroy(this.gameObject);
					}
				}

				private void LateUpdate()
				{
					//UIが常にカメラの向きに向くようにする	
					hpBar.transform.rotation = Camera.main.transform.rotation;
				}

				public void ApplyDamage(float damage)
				{

					hp -= damage;

				}

				public void LockedOn()
				{
					//これいらない気がする
				}
			}
		}
	}
}
