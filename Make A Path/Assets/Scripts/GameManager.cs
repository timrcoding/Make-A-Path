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
    public List<GameObject> movementNodes;
    public int nodeCount;
    
    //SHOWS WHICH TILE WAS PREVIOUSLY SELECTED

    void Start()
    {
        instance = this;
       
    }

    private void Update()
    {
        setTile();
        if (Input.GetKeyDown(KeyCode.E)){
            player.GetComponent<PlayerBehaviour>().move = true;
        }
    }

    void setTile()
    {
        if (tileSelected != null)
        {
            TileArrows tile = tileSelected.GetComponent<TileArrows>();
            

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
