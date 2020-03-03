using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod
{
	namespace Character
	{
		namespace Bot
		{

			public class BotLooking : MonoBehaviour
			{
				private GameObject targetObject;
				private BotMoving botMoving;

				private void Start()
				{
					botMoving = GetComponent<BotMoving>();
				}


				void Update()
				{
					if (targetObject == null)
					{
						return;
					}
					float speed = 0.1f;

					Vector3 relativePosition = targetObject.transform.position - this.transform.position;


					Quaternion rotation = Quaternion.LookRotation(relativePosition);


					transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
				}



				private void OnTriggerEnter(Collider other)
				{
					if (other.tag == "Player")
					{
						targetObject = other.gameObject;
						botMoving.UpdateTarget(targetObject);
						Debug.Log("detection");
					}
				}
			}
		}
	}
}