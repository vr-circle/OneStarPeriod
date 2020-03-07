using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneStarPeriod.Character.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		private Animator animator;

		Rigidbody playerRigidbody;
		Plane plane = new Plane();

		[SerializeField]
		float moveSpeed = 10.0f;
		float distance = 0.0f;

		private float inputHorizontal;
		private float inputVertical;

		void Start()
		{
			animator = this.GetComponent<Animator>();
			playerRigidbody = GetComponent<Rigidbody>();
		}
		private void Update()
		{

			inputHorizontal = Input.GetAxisRaw("Horizontal");
			inputVertical = Input.GetAxisRaw("Vertical");

		}
		void FixedUpdate()
		{

			Vector3 inputDirection = Vector3.Normalize(new Vector3(inputHorizontal, 0, inputVertical));

			playerRigidbody.velocity = inputDirection * moveSpeed + new Vector3(0, playerRigidbody.velocity.y, 0);

			UpdateRotation();

			Vector3 velocity = transform.InverseTransformDirection(this.playerRigidbody.velocity).normalized;
			animator.SetFloat("MoveX", velocity.x);
			animator.SetFloat("MoveZ", velocity.z);
			if (velocity != Vector3.zero)
			{
				animator.SetBool("isMoving", true);
			}
			else
			{
				animator.SetBool("isMoving", false);
			}
		}

		private void UpdateRotation()
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