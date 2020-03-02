using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Character
{
	public class PlayerController : MonoBehaviour
	{
		Rigidbody playerRigidbody;
		Plane plane = new Plane();

		[SerializeField]
		float moveSpeed = 10.0f;
		float distance = 0.0f;

		private float inputHorizontal;
		private float inputVertical;

		private bool isLockingOn = false;
		GameObject targetObject;

		void Start()
		{
			playerRigidbody = GetComponent<Rigidbody>();
		}
		private void Update()
		{
			inputHorizontal = Input.GetAxisRaw("Horizontal");
			inputVertical = Input.GetAxisRaw("Vertical");

			if (Input.GetMouseButtonDown(1))//right click
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				RaycastHit hitObject;

				if (Physics.Raycast(ray, out hitObject, 20.0f))
				{
					Debug.Log(hitObject.transform.position);
					if (hitObject.collider.tag == "Enemy")//fix has interface(whether possible to lock on) <-- tag=="Enemy"
					{
						isLockingOn = true;
						targetObject = hitObject.collider.gameObject;
						targetObject.GetComponent<IcanLockedOn>().LockedOn();
					}
					else
					{
						isLockingOn = false;
					}

				}
			}
		}
		void FixedUpdate()
		{
			Vector3 yVelocityTmp = playerRigidbody.velocity;

			playerRigidbody.velocity 
				= new Vector3(
					inputHorizontal * moveSpeed,
					playerRigidbody.velocity.y,
					inputVertical * moveSpeed
				);

			UpdateRotation();
		}

		private void UpdateRotation()
		{
			if (isLockingOn)
			{
				if (targetObject == null)
				{
					isLockingOn = false;

					return;

				}


				Vector3 targetPosition = targetObject.transform.position;

				targetPosition.y = this.transform.position.y;

				transform.LookAt(targetPosition);
			}
			else
			{
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
				plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
				if (plane.Raycast(ray, out distance))
				{
					// 距離を元に交点を算出して、交点の方を向く
					var lookPoint = ray.GetPoint(distance);
					transform.LookAt(lookPoint);
				}
			}
		}



	}
}