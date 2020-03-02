using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLooking : MonoBehaviour
{
	[SerializeField] GameObject Bot;
	[SerializeField] GameObject Target;
	


	void Update()
	{
		//BotRigid.transform.LookAt(Target.transform);

		float speed = 0.1f;

		Vector3 relativePos = Target.transform.position - this.transform.position;

		Quaternion rotation = Quaternion.LookRotation(relativePos);

		transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
	}
}
