using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagerMoving : MonoBehaviour
{
    [SerializeField] private GameObject Bot;
    private Rigidbody BotRigid;
    [SerializeField] private GameObject Target;
    private float TimeCounting = 0;
    private int RandomFigure;
    private float Distance;
    private int MovingPuttern;
    private float CollideCounting = 0;
    private float CollideMoving = 5;



    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Bot.transform.position, Target.transform.position);
        if (CollideMoving == 5)//衝突判定未検出
        {
            if (TimeCounting == 0.0f)//行動パターン決定
            {
                 RandomFigure = RandomCreateFar();
            }

            if (RandomFigure == 0)//反時計回りにウゴく
            {
                MovingPuttern = 0;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 5;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if (RandomFigure == 1)//時計回りに動く
            {
                MovingPuttern = 1;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 5;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(-1 * speed, 0, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if (RandomFigure == 2)//近づく
            {
                MovingPuttern = 2;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 10;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -1 * speed);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if (RandomFigure == 3)//遠ざかる
            {
                MovingPuttern = 3;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 10;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
                gameObject.transform.position += velocity * Time.deltaTime;
            }


            if (TimeCounting >= 4.0f)//行動パターンリセット
            {
                TimeCounting = 0;
            }
        }
        else //衝突判定検出
        {
            CollideCounting += Time.deltaTime;
            if (CollideMoving == 0)
            {
                MovingPuttern = 0;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 5;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if (CollideMoving == 1)
            {
                MovingPuttern = 1;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 5;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(-1 * speed, 0, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if (CollideMoving == 2)
            {
                MovingPuttern = 2;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 1;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -1 * speed);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if (CollideMoving == 3)
            {
                MovingPuttern = 3;//行動パターン記憶
                TimeCounting += Time.deltaTime;
                float speed = 1;
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, speed);
                gameObject.transform.position += velocity * Time.deltaTime;
            }
            if(CollideCounting>=2.0f)
            {
                CollideMoving=1;
            }
            if (CollideCounting >= 4.0f)
            {
                CollideCounting = 0;//衝突タイムカウントりせっと
                CollideMoving = 5;//判定消去
            }


        }

    }
    void OnCollisionEnter(Collision collision)//衝突判定検出
    {
        Debug.Log("衝突判定検出");

        {
            if (MovingPuttern == 1)
            {
                CollideMoving = 0;
            }
            if (MovingPuttern == 0)
            {
                CollideMoving = 1;
            }
            if (MovingPuttern == 3)
            {
                CollideMoving = 2;
            }
            if (MovingPuttern == 2)
            {
                CollideMoving = 3;
            }
        }
    }
    private int RandomCreateFar()
    {
        Debug.Log("Far");
        return Random.Range(3,3);
    }
    private int RandomCreateClose()
    {
        Debug.Log("Close");
        return Random.Range(0, 2);
    }
}
