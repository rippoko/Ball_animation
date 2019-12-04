using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_3_move : MonoBehaviour
{
    /*private float ball_y;
    private int time_count;*/

    private float ini_y = 4f;
    private float floor_y = 0.5f;
    private float ball_y;
    private float ball_v;
    private float ball_t;
    private float ball_g;
    private float turn_t = 30;

    private float ani_g;

    private int ball_s = 1;

    void Start()
    {
        ball_g = (float)((ini_y - floor_y) / (turn_t * turn_t * 0.5));
    }

    void Update()
    {
        /*time_count--;
        if( time_count < -30 )
        {
            time_count = 30;
        }
        ball_y = time_count * time_count * -0.00388f + 4;*/

        ball_t += ball_s;

        ani_g = (float)(ball_g / (float)System.Math.Sqrt(System.Math.Pow(turn_t, 3))) * (float)System.Math.Sqrt(System.Math.Pow(ball_t, 3));
        //ani_g = (ball_g / (turn_t * turn_t)) * ball_t * ball_t;
        //ani_g = ball_g / (ini_y - floor_y) * ball_y;

        //Debug.Log(System.Math.Sqrt(System.Math.Pow(turn_t, 3)));

        if (ball_t > turn_t || ball_t < 0) ball_s *= -1;

        ball_y = (float)(ini_y - (0.5f * ani_g * ball_t * ball_t));

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, (float)ball_y, pos.z);
    }
}