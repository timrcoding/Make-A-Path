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
            if (GameManager.instance.pathToFinish())
            {
                transform.position = Vector3.Lerp(transform.position, newTarget.transform.position, 0.2f);
                
                if (Vector2.Distance(transform.position, newTarget.transform.position) <= 0.05f)
                {
                    
                    transform.position = newTarget.transform.position;
                    incrementTarget();
                    newTargetForPlayer();
                }
            }
            else
            {
                move = false;
                
                GameManager.instance.resetRound();
                targetCount = 0;
            }
            
        }
        
    }

    public void newTargetForPlayer()
    {
            newTarget = GameManager.instance.movementNodes[targetCount];
        
    }

    public void incrementTarget()
    {
        if (targetCount < GameManager.instance.movementNodes.Count-1)
        {
            targetCount++;
            AudioManager.instance.playClip("Servo", 1);
        }
        else if (checkForFinish())
        {
            Debug.Log("LEVEL COMPLETED");
        }
        
    }

    public bool checkForFinish()
    {
        if (targetCount >= GameManager.instance.movementNodes.Count - 1)
        {
            return true;
        }
        else { return false; }
    }

    
}

