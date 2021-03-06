﻿using System.Collections;
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
				[SerializeField]
				private float maxHp = 10.0f;

				[SerializeField]
				private GameObject destoyEffect;


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
						GameObject tmp = Instantiate(destoyEffect, this.transform.position, this.transform.rotation);
						Destroy(tmp, 1.0f);
						Destroy(this.gameObject);
					}
				}

				private void LateUpdate()
				{
					hpBar.transform.rotation = Camera.main.transform.rotation;
				}

				public void ApplyDamage(float damage)
				{

					hp -= damage;

				}
			}
		}
	}
}
