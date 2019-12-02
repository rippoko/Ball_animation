using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimaiton1 : MonoBehaviour
{
    float radius = 0.5f;
    
    [SerializeField]
    float gravity;

    enum BallState
    {
        UP,
        DOWN,
    }

    BallState curState;

    Vector3 curVec = Vector3.zero;
    Vector3 nextPos;
    
    void Start()
    {
        nextPos = transform.position;
        curState = BallState.DOWN;
    }
    
    void Update()
    {
        curVec += Vector3.down * gravity;
        nextPos += curVec;
        
        switch (curState)
        {
            case BallState.UP:
                if (curVec.y < 0f)
                {
                    curState = BallState.DOWN;
                }
                
                break;
            case BallState.DOWN:

                if (nextPos.y < radius)
                {
                    nextPos = Vector3.Reflect(nextPos-radius*Vector3.up,Vector3.up) + radius*Vector3.up;
                    curVec = Vector3.Reflect(curVec, Vector3.up);
                    curState = BallState.UP;
                }

                break;
        }


        transform.position = nextPos;


    }
}
