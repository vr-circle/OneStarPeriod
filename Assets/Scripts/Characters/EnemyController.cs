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
			public class EnemyController : MonoBehaviour
			{
				[SerializeField]
				private GameObject textObject;
				private Text text;


				[SerializeField]
				private List<GameObject> enemys;

				[SerializeField]
				private List<Vector3> spawnPosition;

				[SerializeField]
				private int enemySum = 10;
				[SerializeField]
				private int initEnemyNum;
				private int maxEnemyEntity;
				private int nowEnemyNum = 0;

				private void Start()
				{
					text = textObject.GetComponent<Text>();

					maxEnemyEntity = initEnemyNum;
					while (initEnemyNum > 0)
					{
						SpawnEnemy();
						initEnemyNum--;
					}
				}

				private void Update()
				{
					nowEnemyNum = this.transform.childCount;

					text.text = "残り"+(enemySum + nowEnemyNum).ToString();

					if (enemySum > 0 && nowEnemyNum < maxEnemyEntity)
					{
						SpawnEnemy();
					}

					if (nowEnemyNum == 0)
					{
						FadeManager.FadeOut("ClearScene");
					}
				}


				private void SpawnEnemy()
				{
					Instantiate(enemys[Random.Range(0, enemys.Count)], spawnPosition[Random.Range(0, spawnPosition.Count)], Quaternion.identity, this.transform);

					enemySum--;
				}


			}

		}
	}
}