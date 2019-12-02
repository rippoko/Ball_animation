using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimaiton2 : MonoBehaviour
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
        curVec = Vector3.down * 0.001f;
    }
    
    void Update()
    {
//        curVec += Vector3.down * gravity;
        
        


        switch (curState)
        {
            case BallState.UP:
                curVec *= 0.85f;
                nextPos += curVec;
                
                SetScale();
                
                if (curVec.y < 0.001f)
                {
                    curVec = Vector3.down * 0.001f;
                    curState = BallState.DOWN;
                }
                
                
                break;
            case BallState.DOWN:

                curVec *= 1.2f;
                nextPos += curVec;
                
                SetScale();
                
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

    void SetScale()
    {
        float height = Mathf.Abs(curVec.y) * 1f + 0.8f;
        float width = (0.3f - Mathf.Abs(curVec.y))*0.6f + 0.8f;

        transform.localScale = new Vector3(width,height,width);
        //radius = height;
    }
    
}


