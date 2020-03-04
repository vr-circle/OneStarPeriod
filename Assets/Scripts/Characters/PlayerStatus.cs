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
				private float maxHp = 50.0f;
				private float mp;
				private float maxMp = 50.0f;
				private float mpRecoverySpeed = 0.05f;

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
					if (hp <= 0.0f)
					{
						//GameOverSceneに遷移させる
					}

					hpSlider.value = hp / maxHp;
					mpSlider.value = mp / maxMp;
					mp += mpRecoverySpeed;
				}

				public void ApplyDamage(float damage)
				{
					this.hp -= damage;
				}

				public float GetMp()
				{
					return this.mp;
				}
				public void DecreaseMp(float mp)
				{
					this.mp -= mp;
				}



			}
		}
	}
}