using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneStarPeriod
{
	public class CameraController : MonoBehaviour
	{
		public Vector3 offset;//offsetは追従するオブジェクトの中心をとらえるための調整、今回は特に指定なし

		private float xSensitivity = 1.0f;  //左右のカメラの感度を調整
		private float ySensitivity = 1.0f;  //上下のカメラの感度を調整
		private float xAngle = 45.0f;       //初期の左右の角度,カメラ
		private float yAngle = 30.0f;       //初期の上下の角度,カメラ
		private float minyAngle = 3.0f;     //カメラで上から見下げるときの角度に制限
		private float maxyAngle = 110.0f;   //カメラで下から見上げるときの角度に制限
		private float radius = 10.0f;       //追従するオブジェクトからカメラまでの距離を設定
		[SerializeField]
		private GameObject targetObject;    //追従するオブジェクト、ここではplayer
		void Start()
		{
			//	targetObject = this.transform.parent.gameObject;
		}
		void LateUpdate()
		{
			//UpdateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));    //マウスの移動距離を引数に
			UpdateAngle(0, 0);                                                  //マウスの移動距離を引数に
			var lookPos = targetObject.transform.position + offset;             //焦点をoffsetで調整して設定
			TransformUpdate(lookPos);                                           //焦点を引数に
			transform.LookAt(lookPos);                                          //焦点をlookPosに設定する
		}
		void UpdateAngle(float x, float y)
		{
			x = xAngle - x * xSensitivity;
			xAngle = Mathf.Repeat(x, 360);
			y = yAngle + y * ySensitivity;
			yAngle = Mathf.Clamp(y, minyAngle, maxyAngle);
		}
		void TransformUpdate(Vector3 lookPos)
		{
			var da = xAngle * Mathf.Deg2Rad;
			var dp = yAngle * Mathf.Deg2Rad;
			transform.position = new Vector3(
				lookPos.x + radius * Mathf.Sin(dp) * Mathf.Cos(da),
				lookPos.y + radius * Mathf.Cos(dp),
				lookPos.z + radius * Mathf.Sin(dp) * Mathf.Sin(da));
		}
	}
}