using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public bool interactable;
    public GameObject newTarget;
    public int targetCount;
    public bool move;
    public bool moveComplete;
    void Start()
    {
       // newTargetForPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        newTargetForPlayer();
        if (move)
        {
            transform.position = Vector3.Lerp(transform.position, newTarget.transform.position, 0.05f);
            if(Vector2.Distance(transform.position,newTarget.transform.position) <= 0.05f)
            {
                transform.position = newTarget.transform.position;
                
                newTargetForPlayer();
            }
        }
    }

    public void newTargetForPlayer()
    {
        
        newTarget = GameManager.instance.movementNodes[targetCount];
    }
}

