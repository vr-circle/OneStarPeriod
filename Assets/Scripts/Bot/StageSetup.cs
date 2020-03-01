using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetup : MonoBehaviour
{
    // Start is called before the first frame update

    private int[] StagePoint = new int[100];
    [SerializeField] private GameObject StageWall;
    private int CurrentNumber;
    private int AxisX;
    private int AxisY;
    private int License;
    private int PointNumber;

    private void Awake()
    {
        for (PointNumber = 0; PointNumber < 50; PointNumber++)
        {
            while (License == 0)
            {
                CurrentNumber = RandomFigure();
                if (StagePoint[CurrentNumber] == 0)
                {
                    License = 1;
                    StagePoint[CurrentNumber] = 1;
                }
            }
            AxisX = SpotX(CurrentNumber);
            AxisY = SpotY(CurrentNumber);
            Instantiate(StageWall, new Vector3(AxisX * 1.0f, 1.0f, AxisY * 1.0f), Quaternion.identity);
            License = 0;
        }
    }
    private int RandomFigure()
    {
        return Random.Range( 0, 100);
    }
    private int SpotX(int SpotFigure)
    {
        return -50+(SpotFigure / 10) * 10;
    }
    private int SpotY(int SpotFigure)
    {
        return -50+(SpotFigure % 10) * 10;
    }
}
