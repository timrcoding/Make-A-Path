using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject tileSelected;
    public GameObject placedTile;
    public GameObject player;
    public Sprite[] arrows;
    public GameObject startTile;
    public GameObject finishTile;
    [SerializeField]
    private bool tilesCanBeSet;
    [SerializeField]
    private bool playStarted;
    public List<GameObject> movementNodes;
    public int nodeCount;

    public int obstacleLikelihood;
    
    //SHOWS WHICH TILE WAS PREVIOUSLY SELECTED

    void Start()
    {
        instance = this;
        tilesCanBeSet = true;
        StartCoroutine(startRound());

    }

    private void Update()
    {
        if (Counter.instance.startTimer)
        {
            setTile();
            if (Input.GetKeyDown(KeyCode.E) && !playStarted)
            {
                playStarted = true;
                tilesCanBeSet = false;
                movementNodes.Add(finishTile);
                player.GetComponent<PlayerBehaviour>().move = true;

            }
        }
    }

    void setTile()
    {
        if (tileSelected != null && tilesCanBeSet)
        {
            TileArrows tile = tileSelected.GetComponent<TileArrows>();
            if (!tile.buttonCannotBeSet)
            {


                if (Input.GetKeyDown(KeyCode.W))
                {

                    tile.setTop();
                    movementNodes.Add(tileSelected);
                    placedTile = tileSelected;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    tile.setRight();
                    movementNodes.Add(tileSelected);
                    placedTile = tileSelected;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    tile.setDown();
                    movementNodes.Add(tileSelected);
                    placedTile = tileSelected;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    tile.setLeft();
                    movementNodes.Add(tileSelected);
                    placedTile = tileSelected;
                }
            }
        }
        }

    public bool pathToFinish()
    {
        
        if (finishTile.transform.position.x == movementNodes[movementNodes.Count-2].transform.position.x || finishTile.transform.position.y == movementNodes[movementNodes.Count - 2].transform.position.y)
        {
            Debug.Log("CHECK PASSED");
            return true;
            
        }
        else
        {
            Debug.Log("CHECK NOT PASSED");
            return false;
        }
    }

    public void resetRound()
    {
        Debug.Log("ROUND RESET");
        playStarted = false;
        tilesCanBeSet = true;
        player.GetComponent<PlayerBehaviour>().move = false;
        player.GetComponent<PlayerBehaviour>().targetCount = 0;
        player.transform.position = startTile.transform.position;
        movementNodes.Remove(finishTile);

    }

    IEnumerator startRound()
    {
        for(int i = 3; i > 0; i--)
        {
            
            Counter.instance.setText(i);
            yield return new WaitForSeconds(1);
        }
        Counter.instance.startTimer = true;
    }

    public void roundFinished()
    {
        Counter.instance.startTimer = false;
    }
}
