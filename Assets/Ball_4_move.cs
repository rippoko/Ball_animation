using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_4_move : MonoBehaviour
{
    //pos
    private float ini_y = 4f;
    private float floor_y = 0.5f;
    private float ball_y;
    private float ball_v;
    private float ball_g;

    private float ani_g;

    private int ball_s = 1;

    private float ball_pow, turn_pow;

    //scale
    private float scale_x, scale_y;

    //both
    private float turn_t = 60;
    private float ball_t;
    private float scalex_t1_a, scalex_t2_a;
    private float scaley_t1_a, scaley_t2_a;
    private bool turn2 = false;

    void Start()
    {
        ball_g = (float)((ini_y - floor_y) / (turn_t * turn_t * 0.5));
        scalex_t1_a = (float)((0.5 - 1.2) / System.Math.Pow((turn_t * 5 / 6), 2));
        scalex_t2_a = (float)((1.2 - 0.5) / System.Math.Pow((turn_t * 1 / 6), 2));
        scaley_t1_a = (float)((1.5 - 0.8) / System.Math.Pow((turn_t * 5 / 6), 2));
        scaley_t2_a = (float)((0.8 - 1.5) / System.Math.Pow((turn_t * 1 / 6), 2));
    }

    void Update()
    {
        ball_scale();
        ball_pos();
    }

    void ball_pos()
    {
        ball_t += ball_s;

        turn_pow = (float)System.Math.Abs(System.Math.Pow(turn_t, 3));
        ball_pow = (float)System.Math.Abs(System.Math.Pow(ball_t, 3));

        ani_g = (float)(ball_g / (float)System.Math.Sqrt(turn_pow)) * (float)System.Math.Sqrt(ball_pow);

        if (ball_t > turn_t || ball_t < 0) ball_s *= -1;

        if (turn2 && scale_y/2 < 0.5)
        {
            ball_y = (float)((ini_y - (0.5f * ani_g * ball_t * ball_t)) - ((1 - scale_y)/2));
        }
        else
        {
            ball_y = (float)(ini_y - (0.5f * ani_g * ball_t * ball_t));
        }

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, (float)ball_y, pos.z);
    }

    void ball_scale()
    {
        if ( ball_t <= turn_t * 5 / 6  )
        {
            scale_x = (float)((scalex_t1_a * System.Math.Pow(ball_t, 2)) + 1.2);
            scale_y = (float)((scaley_t1_a * System.Math.Pow(ball_t, 2)) + 0.8);
            turn2 = false;
        }
        else
        {
            scale_x = (float)((scalex_t2_a * System.Math.Pow((ball_t - (turn_t * 5 / 6)), 2)) + 0.5);
            scale_y = (float)((scaley_t2_a * System.Math.Pow((ball_t - (turn_t * 5 / 6)), 2)) + 1.5);
            turn2 = true;
        }

        Vector3 scale = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = new Vector3((float)scale_x, (float)scale_y, scale.z);
    }
}