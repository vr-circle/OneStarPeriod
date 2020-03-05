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


		public void Shake(float duration,float magnitude)
		{
			StartCoroutine(DoShake(duration, magnitude));
		}

		private IEnumerator DoShake(float duration,float magnitude)
		{
			var pos = transform.localPosition;


			var elapsed = 0.0f;

			while (elapsed < duration)
			{
				var x = pos.x + Random.Range(-1.0f, 1.0f) * magnitude;
				var y = pos.y + Random.Range(-1.0f, 1.0f) * magnitude;
				transform.localPosition = new Vector3(x, y, pos.z);

				elapsed += Time.deltaTime;

				yield return null;
			}
		}


	}
}