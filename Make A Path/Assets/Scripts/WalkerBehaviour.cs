using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;
    private int cols = 9;
    [SerializeField]
    private int startingTile;
    [SerializeField]
    private int xmoves = 8;
    [SerializeField]
    private int ymoves = 7;
    void Start()
    {
        setPath();

    }

    public void setPath()
    {
        for(int i = 0; i < 8; i++)
        {
                moveWalker(true);
                moveWalker(false);
        }
    }

    public void moveWalker(bool horiz)
    {
        transform.position = tiles[startingTile].transform.position;
        int newTile;
        int num;

        if (horiz)
        {
            num = Random.Range(0,xmoves);
            newTile = cols * num + startingTile;
            startingTile = newTile;
            xmoves -= num;
            Vector3 oldPos = transform.position;
            Vector3 newPos = tiles[newTile].transform.position;
            transform.position = newPos;
            searchTiles(oldPos, newPos, true);
        }
        else
        {
            num = Random.Range(0,ymoves);
            newTile = num * 1 + startingTile;
            startingTile = newTile;
            ymoves -= num;
            Vector3 oldPos = transform.position;
            Vector3 newPos = tiles[newTile].transform.position;
            transform.position = newPos;
            searchTiles(oldPos, newPos, false);
        }
            
            
        
    }

    public void searchTiles(Vector3 oldPos,Vector3 newPos,bool horiz)
    {
        foreach(GameObject tile in tiles)
        {
            if (horiz)
            {
                if (tile.transform.position.y == newPos.y)
                {
                    if (tile.transform.position.x >= oldPos.x && tile.transform.position.x <= newPos.x)
                    {
                        //tile.GetComponent<TileArrows>().GetComponent<Image>().color = Color.green;
                        tile.GetComponent<TileArrows>().cannotBeObstacle = true;
                    }
                }
            }
            else
            {
                if (tile.transform.position.x == newPos.x)
                {
                    if (tile.transform.position.y <= oldPos.y && tile.transform.position.y >= newPos.y)
                    {
                        //tile.GetComponent<TileArrows>().GetComponent<Image>().color = Color.green;
                        tile.GetComponent<TileArrows>().cannotBeObstacle = true;
                        
                    }
                }
            }
        }
    }
}
