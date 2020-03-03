using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportMoving : MonoBehaviour
{
    [SerializeField]
    private GameObject Support;

    [SerializeField]
    private GameObject Player;

    private float Distance;

    private Vector3 SupportVerocity;

    private Vector3 PlayerPosition;

    private Vector3 SupportDirection;

    [SerializeField]
    private float SupportSpeed=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Player.transform.position;
        Distance = Vector3.Distance(Support.transform.position, Player.transform.position);
        SupportDirection = PlayerPosition - Support.transform.position;
        SupportVerocity = SupportDirection * SupportSpeed;
        if(Distance>=2.0f)
        {
            this.transform.position += SupportVerocity * Time.deltaTime;
        }
    }
}
