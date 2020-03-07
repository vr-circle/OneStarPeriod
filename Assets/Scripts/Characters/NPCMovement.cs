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
				Random,
				Idling,
				Approaching,
				Leave,
				AntiClockwise,
				Clockwise,
				Disengage,
			}

			public class NPCMovement : MonoBehaviour
			{
				


				[SerializeField]
				private GameObject targetObject;
				private Rigidbody enemyRigidbody;

				private float chengePatternTime = 3.0f;
				private float movementTimer = 0.0f;

				[SerializeField]
				private MovementPattern initPattern;
				private MovementPattern nowPattern;
				private float speed = 80.0f;

				List<MovementPattern> patterns = new List<MovementPattern>();

				private void Start()
				{
					targetObject = GameObject.FindGameObjectWithTag("Player");


					foreach (MovementPattern pattern in Enum.GetValues(typeof(MovementPattern)))
					{
						patterns.Add(pattern);
					}
					enemyRigidbody = this.GetComponent<Rigidbody>();
				}
				private void FixedUpdate()
				{
					if (targetObject == null)
					{
						initPattern = MovementPattern.Idling;
						return;
					}
					Vector3 lookPosition = new Vector3(targetObject.transform.position.x, this.transform.position.y, targetObject.transform.position.z);
					transform.LookAt(lookPosition);
					switch (initPattern)
					{
						case MovementPattern.Idling:
							break;
						case MovementPattern.Random:
							movementTimer += Time.deltaTime;

							if (movementTimer > chengePatternTime)
							{
								movementTimer = 0;
								initPattern = RandomMovementPattern();
							}

							break;
						case MovementPattern.Approaching:
								speed = 3.0f;
								enemyRigidbody.velocity =
									new Vector3(
										transform.forward.x * speed,
										enemyRigidbody.velocity.y,
										transform.forward.z * speed
									);
							break;
						case MovementPattern.Leave:
								speed = 3.0f;
								enemyRigidbody.velocity =
									new Vector3(
										transform.forward.x * speed * -1,
										enemyRigidbody.velocity.y,
										transform.forward.z * speed * -1
									);
							break;
						case MovementPattern.Clockwise:
							{
								float nowDistance = Vector3.Distance(this.transform.position, targetObject.transform.position);
								speed = 360.0f / nowDistance;
								Vector3 axis = transform.TransformDirection(Vector3.up);
								transform.RotateAround(targetObject.transform.position, axis, speed * Time.deltaTime);
								break;
							}
						case MovementPattern.AntiClockwise:
							{
								float nowDistance = Vector3.Distance(this.transform.position, targetObject.transform.position);
								speed = 360.0f / nowDistance;
								Vector3 axis = transform.TransformDirection(Vector3.down);
								transform.RotateAround(targetObject.transform.position, axis, speed * Time.deltaTime);
								break;
							}
						case MovementPattern.Disengage:
							break;
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



				public void SetMovementPattern(MovementPattern tmp)
				{
					this.initPattern = tmp;
				}

			}

		}
	}
}