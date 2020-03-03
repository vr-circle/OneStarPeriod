using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// TODO:
///		変数名の改善
///		使われていない変数の削除
///		intFlagをenumに変更し可読性の向上
///		ステータスをinterfaceで実装する？
///		bot:supporter,enemyの動きを改善する
///		playerの弾丸を多少の上下にも対応できるようにするか
///		
///		StageSelectSceneが現在消えているため復元する
/// </summary>

namespace Character
{
	namespace Bot
	{
		public enum MovePattern
		{
			AntiClockwise = 0,
			Clockwise = 1,
			Approaching = 2,
			Leave = 3,
		}


		public class BotMoving : MonoBehaviour
		{
			private GameObject targetObject;

			private MovePattern nowMovePattern;



			
			private void Update()
			{
				Move();
			}




			private void Move()
			{




			}
			
			//BotLookingで近くにいたObjectをOnTriggerEnterで検知してtargetを更新する
			public void UpdateTarget(GameObject targetObject)
			{
				this.targetObject = targetObject;
			}

					   			 


			private void MoveClockwise()
			{

			}
			private void MoveAntiClockwise()
			{

			}
			private void MoveApproaching()
			{

			}
			private void MoveLeave()
			{

			}





			////[SerializeField]
			////private GameObject Bot;
			//private Rigidbody BotRigid;
			//[SerializeField]
			//private GameObject targetObject;
			//private float timeCount = 0;
			//private int randomFigure;
			//private float distance;
			//private MovePattern movePattern;
			//private float collideCount = 0;
			//private int collideMoving = 5;




			//void Update()
			//{
			//	distance = Vector3.Distance(this.transform.position, targetObject.transform.position);

			//	if (collideMoving == 5)//衝突判定未検出
			//	{
			//		timeCount += Time.deltaTime;
			//		float speed;
			//		Vector3 direction = this.transform.forward;
			//		switch (randomFigure)
			//		{
			//			case 0:
			//				{
			//					movePattern = MovePattern.AntiClockwise;
			//					speed = 5;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//			case 1:
			//				{
			//					movePattern = MovePattern.Clockwise;
			//					speed = 5;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(-1 * speed, 0, 0);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//			case 2:
			//				{
			//					movePattern = MovePattern.Approaching;
			//					speed = 1;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -1 * speed);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//			case 3:
			//				{

			//					movePattern = MovePattern.GoAway;
			//					speed = 1.0f;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//		}

			//		if (timeCount >= 4.0f)//行動パターンリセット
			//		{
			//			timeCount = 0.0f;

			//			if (distance >= 3.0f)
			//			{
			//				randomFigure = RandomCreateFar();

			//			}
			//			else
			//			{
			//				randomFigure = RandomCreateClose();
			//			}

			//		}
			//	}
			//	else //衝突判定検出
			//	{
			//		collideCount += Time.deltaTime;
			//		timeCount += Time.deltaTime;

			//		switch (collideMoving)
			//		{
			//			case 0:
			//				{
			//					movePattern = MovePattern.AntiClockwise;//行動パターン記憶
			//					float speed = 5;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//			case 1:
			//				{
			//					movePattern = MovePattern.Clockwise;
			//					float speed = 5;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(-1 * speed, 0, 0);
			//					gameObject.transform.position += velocity * Time.deltaTime;

			//					break;
			//				}

			//			case 2:
			//				{
			//					movePattern = MovePattern.Approaching;
			//					float speed = 1;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -1 * speed);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//			case 3:
			//				{
			//					movePattern = MovePattern.GoAway;
			//					float speed = 1;
			//					Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
			//					gameObject.transform.position += velocity * Time.deltaTime;
			//					break;
			//				}
			//		}

			//		if (collideCount >= 2.0f)
			//		{
			//			collideCount = 0;//time count reset
			//			collideMoving = 5;//判定消去
			//		}


			//	}

			//}
			//void OnCollisionEnter(Collision collision)//衝突判定検出
			//{
			//	//Debug.Log("衝突判定検出");
			//	if (collision.gameObject.tag != "Bullet")
			//	{
			//		switch (movePattern)
			//		{
			//			case MovePattern.AntiClockwise:
			//				collideMoving = 1;
			//				break;
			//			case MovePattern.Clockwise:
			//				collideMoving = 0;
			//				break;
			//			case MovePattern.Approaching:
			//				collideMoving = 3;
			//				break;
			//			case MovePattern.GoAway:
			//				collideMoving = 2;
			//				break;
			//			default:
			//				break;
			//		}
			//	}
			//}
			//private int RandomCreateFar()
			//{
			//	Debug.Log("Far");
			//	return Random.Range(0, 3);
			//}
			//private int RandomCreateClose()
			//{
			//	Debug.Log("Close");
			//	return Random.Range(0, 2);
			//}


		}
	}
}