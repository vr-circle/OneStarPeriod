using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Player
		{
			public class PlayerStatus : MonoBehaviour, IDamageable
			{
				private float hp;
				private float maxHp = 50;
				private float mp;
				private float maxMp = 50;


				[SerializeField]
				private GameObject hpBar;
				[SerializeField]
				private GameObject mpBar;

				private Slider hpSlider;
				private Slider mpSlider;


				void Start()
				{
					hp = maxHp;
					mp = maxMp;

					hpSlider = hpBar.GetComponent<Slider>();
					mpSlider = mpBar.GetComponent<Slider>();
				}

				void Update()
				{
					hpSlider.value = hp / maxHp;
					mpSlider.value = mp / maxMp;
				}

				public void ApplyDamage(float damage)
				{
					this.hp -= damage;
				}

			}
		}
	}
}