using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagerMoving : MonoBehaviour
{
	[SerializeField]
	private GameObject Bot;

	private Rigidbody BotRigid;

	[SerializeField]
	private GameObject Target;

	private float timeCount = 0.0f;

	private float distance;
	private int randomFigure;
	private int movingPuttern;
	private int collideMoving = 5;
	private float collideCount = 0.0f;



	void Update()
	{
		distance = Vector3.Distance(Bot.transform.position, Target.transform.position);
		
		if (collideMoving == 5.0f)//衝突判定未検出
		{
			if (timeCount == 0.0f)//行動パターン決定
			{
				randomFigure = RandomCreateFar();
			}

			if (randomFigure == 0)//反時計回りにウゴく
			{
				movingPuttern = 0;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 5;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (randomFigure == 1)//時計回りに動く
			{
				movingPuttern = 1;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 5;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(-1 * speed, 0, 0);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (randomFigure == 2)//近づく
			{
				movingPuttern = 2;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 10;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -1 * speed);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (randomFigure == 3)//遠ざかる
			{
				movingPuttern = 3;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 10;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
				gameObject.transform.position += velocity * Time.deltaTime;
			}


			if (timeCount >= 4.0f)//行動パターンリセット
			{
				timeCount = 0;
			}
		}
		else //衝突判定検出
		{
			collideCount += Time.deltaTime;
			if (collideMoving == 0)
			{
				movingPuttern = 0;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 5;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (collideMoving == 1)
			{
				movingPuttern = 1;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 5;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(-1 * speed, 0, 0);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (collideMoving == 2)
			{
				movingPuttern = 2;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 1;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -1 * speed);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (collideMoving == 3)
			{
				movingPuttern = 3;//行動パターン記憶
				timeCount += Time.deltaTime;
				float speed = 1;
				Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
				gameObject.transform.position += velocity * Time.deltaTime;
			}
			if (collideCount >= 2.0f)
			{
				collideMoving = 1;
			}
			if (collideCount >= 4.0f)
			{
				collideCount = 0;//衝突タイムカウントりせっと
				collideMoving = 5;//判定消去
			}


		}

	}
	void OnCollisionEnter(Collision collision)//衝突判定検出
	{
		switch(movingPuttern)
		{
			case 0:
				collideMoving = 1;
				return;
			case 1:
				collideMoving = 0;
				return;
			case 2:
				collideMoving = 3;
				return;
			case 3:
				collideMoving = 2;
				return;
		}
	}
	private int RandomCreateFar()
	{
		Debug.Log("Far");
		return Random.Range(3, 3);//3?
	}
	private int RandomCreateClose()
	{
		Debug.Log("Close");
		return Random.Range(0, 2);
	}
}
