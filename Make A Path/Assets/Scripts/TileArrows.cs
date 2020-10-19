using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileArrows : MonoBehaviour
{
    [SerializeField]
    public bool buttonCannotBeSet;
    [SerializeField]
    public bool tileIsObstacle;
    [SerializeField]
    private Sprite imageSprite;
    public bool tileSet;
    public int direction;

    [SerializeField]
    private GameObject placementTiles;

    [SerializeField]
    private GameObject playerObject;

    void Start()
    {
        setAsObstacle();
    }

    void setAsObstacle()
    {
        if (tileIsObstacle)
        {
            tag = "Obstacle";
            GetComponent<Image>().color = Color.black;
            buttonCannotBeSet = true;
        }
    }

    public void buttonHoveredOver()
    {

        GameManager.instance.tileSelected = gameObject;
    }

    public void buttonNotHoveredOver()
    {

        GameManager.instance.tileSelected = null;

    }

    public void setTop()
    {
        direction = 0;
        detectPossiblePlacements(direction);
        GetComponent<Image>().sprite = GameManager.instance.arrows[0];
        tileSet = true;
        
    }
    public void setRight()
    {
        direction = 1;
        detectPossiblePlacements(direction);
        GetComponent<Image>().sprite = GameManager.instance.arrows[1];
        tileSet = true;
        
    }
    public void setDown()
    {
        direction = 2;
        detectPossiblePlacements(direction);
        GetComponent<Image>().sprite = GameManager.instance.arrows[2];
        tileSet = true;
        
    }
    public void setLeft()
    {
        direction = 3;
        detectPossiblePlacements(direction);
        GetComponent<Image>().sprite = GameManager.instance.arrows[3];
        tileSet = true;
        
    }

    public void detectPossiblePlacements(int i)
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach(GameObject g in tiles)
        {
            Image tileImage = g.GetComponent<Image>();
            bool tileObstacle = g.GetComponent<TileArrows>().tileIsObstacle;
            //CLEAR COLOURS BEFORE SETTING
            if (!tileObstacle)
            {
                tileImage.color = Color.white;
            }
            else
            {
                tileImage.color = Color.black;
            }
            //CHECK OBSTACLES BY COLOR
            
            
            if (i == 1)
            {
                if (g.transform.position.y == transform.position.y && g.transform.position.x < transform.position.x)
                {
                    tileImage.color = Color.yellow;
                    g.GetComponent<TileArrows>().buttonCannotBeSet = false;
                }
                else
                {
                    g.GetComponent<TileArrows>().buttonCannotBeSet = true;
                }
            }
            else
            {
                if (g.transform.position.x == transform.position.x )
                {
                    tileImage.color = Color.yellow;
                    g.GetComponent<TileArrows>().buttonCannotBeSet = false;
                }
                else
                {
                    g.GetComponent<TileArrows>().buttonCannotBeSet = true;
                }
            }
        }
    }

    public void closestVObstacle(GameObject tile, GameObject[] obstacles)
    {
        List<Transform> obstaclesOnSameYAxis = new List<Transform>();

        for(int i = 0; i < obstacles.Length; i++) 
        {
            if(obstacles[i].transform.position.y == tile.transform.position.y)
            {
                obstaclesOnSameYAxis.Add(obstacles[i].transform);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tileIsObstacle)
        {
            if(other.tag == "Player")
            {
                GameManager.instance.resetRound();
                Debug.Log("P1 DESTROYED");
            }
        }
    }

}

