using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	namespace Character
	{
		namespace Enemy
		{
			public enum MovementPattern
			{
				Idling,
				Approaching,
				Leave,
				AntiClockwise,
				Clockwise,
				Disengage,
			}


			public class EnemyMovement : MonoBehaviour
			{
				//animatorもここで制御する
				[SerializeField]
				private GameObject targetObject;
				private Rigidbody enemyRigidbody;

				private float chengePatternTime = 3.0f;
				private float movementTimer = 0.0f;

				private MovementPattern nowPattern = MovementPattern.Clockwise;
				private float speed = 80.0f;
				private float minDistance = 3.0f;
				private float maxDistance = 10.0f;




				List<MovementPattern> patterns = new List<MovementPattern>();

				private void Start()
				{
					foreach (MovementPattern pattern in Enum.GetValues(typeof(MovementPattern)))
					{
						patterns.Add(pattern);

					}
					enemyRigidbody = this.GetComponent<Rigidbody>();
				}
				private void Update()
				{
					movementTimer += Time.deltaTime;
					if (targetObject == null)
					{
						nowPattern = MovementPattern.Idling;
					}
					else
					{
						if (movementTimer > chengePatternTime)
						{
							movementTimer = 0;
							nowPattern = RandomMovementPattern();
						}
						transform.LookAt(targetObject.transform.position);
						float nowDistance = Vector3.Distance(this.transform.position, targetObject.transform.position);
						switch (nowPattern)
						{
							case MovementPattern.Idling:
								break;
							case MovementPattern.Approaching:
								if (nowDistance < minDistance)
								{
									movementTimer = chengePatternTime;
								}
								else
								{
									speed = 3.0f;
									enemyRigidbody.velocity =
										new Vector3(
											transform.forward.x * speed,
											enemyRigidbody.velocity.y,
											transform.forward.z * speed
										);
								}
								break;
							case MovementPattern.Leave:
								if (nowDistance > maxDistance)
								{
									movementTimer = chengePatternTime;
								}
								else
								{
									speed = 3.0f;
									enemyRigidbody.velocity =
										new Vector3(
											transform.forward.x * speed * -1,
											enemyRigidbody.velocity.y,
											transform.forward.z * speed * -1
										);
								}
								break;
							case MovementPattern.Clockwise:
								{
									speed = 360.0f / nowDistance;
									Vector3 axis = transform.TransformDirection(Vector3.up);
									transform.RotateAround(targetObject.transform.position, axis, speed * Time.deltaTime);
									break;
								}
							case MovementPattern.AntiClockwise:
								{
									speed = 360.0f / nowDistance;
									Vector3 axis = transform.TransformDirection(Vector3.down);
									transform.RotateAround(targetObject.transform.position, axis, speed * Time.deltaTime);
									break;
								}
							case MovementPattern.Disengage:
								break;
						}
					}
				}

				private void OnTriggerEnter(Collider other)
				{
					if (other.tag == "Player")//味方にも？
					{
						targetObject = other.gameObject;
					}

				}


				private MovementPattern RandomMovementPattern()
				{
					int index = UnityEngine.Random.Range(0, patterns.Count);
					return patterns[index];
				}

			}





		}



	}
}