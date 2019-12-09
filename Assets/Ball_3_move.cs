using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_3_move : MonoBehaviour
{
    private float ini_y = 4f;
    private float floor_y = 0.5f;
    private float ball_y;
    private float ball_v;
    private float ball_t;
    private float ball_g;
    private float turn_t = 30;

    private float ani_g;

    private int ball_s = 1;

    private float ball_pow, turn_pow;

    void Start()
    {
        ball_g = (float)((ini_y - floor_y) / (turn_t * turn_t * 0.5));
    }

    void Update()
    {
        ball_t += ball_s;

        turn_pow = (float)System.Math.Abs(System.Math.Pow(turn_t, 3));
        ball_pow = (float)System.Math.Abs(System.Math.Pow(ball_t, 3));

        ani_g = (float)(ball_g / (float)System.Math.Sqrt(turn_pow)) * (float)System.Math.Sqrt(ball_pow);
 
        if (ball_t > turn_t || ball_t < 0) ball_s *= -1;

        ball_y = (float)(ini_y - (0.5f * ani_g * ball_t * ball_t));

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, (float)ball_y, pos.z);
    }
}