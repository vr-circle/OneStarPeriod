using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	public class CameraController : MonoBehaviour
	{
		private Vector3 offset;
		private Vector3 targetPosition;

		private float xAngle = -90.0f;
		private float yAngle = 30.0f;
		private float radius = 10.0f;

		[SerializeField]
		private GameObject targetObject;


		void Start()
		{
			InitAngle();
		}
		void Update()
		{
			targetPosition = targetObject.transform.position;
			this.transform.position = targetPosition + offset;
			transform.LookAt(targetPosition);
		}

		private void InitAngle()
		{
			var da = xAngle * Mathf.Deg2Rad;
			var dp = yAngle * Mathf.Deg2Rad;
			this.offset = new Vector3(
				radius * Mathf.Sin(dp) * Mathf.Cos(da),
				radius * Mathf.Cos(dp),
				radius * Mathf.Sin(dp) * Mathf.Sin(da)
			);
		}
	}
}