using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace OneStarPeriod
{

	using Character.Enemy;
	public class TutorialDirector : MonoBehaviour
	{
		[SerializeField]
		private GameObject enemy;


		private bool isLeft = true;

		[SerializeField]
		Vector3 left;
		[SerializeField]
		Vector3 right;

		private void Update()
		{
			if (this.transform.childCount == 0)
			{
				this.SpawnEnemy();
			}			
		}

		private void SpawnEnemy()
		{
			if (isLeft)
			{

				GameObject tmpEnemy = Instantiate(enemy, left, Quaternion.identity, this.transform);

				Character.Enemy.NPCMovement tmp = tmpEnemy.GetComponent<Character.Enemy.NPCMovement>();

				tmp.SetMovementPattern(MovementPattern.Idling);

				isLeft = false;
			}
			else
			{

				GameObject tmpEnemy = Instantiate(enemy, right, Quaternion.identity, this.transform);

				Character.Enemy.NPCMovement tmp = tmpEnemy.GetComponent<Character.Enemy.NPCMovement>();

				tmp.SetMovementPattern(MovementPattern.Idling);

				isLeft = true;
			}
		}




	}
}