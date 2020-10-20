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
    public bool cannotBeObstacle;
    [SerializeField]
    private Sprite imageSprite;
    public bool tileSet;
    public int direction;

    [SerializeField]
    private GameObject placementTiles;
    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private GameObject playerObject;

    void Start()
    {

        StartCoroutine(setAsObstacle());
    }

    private void Update()
    {

    }

    IEnumerator setAsObstacle()
    {
        yield return new WaitForEndOfFrame();
        int num = (int) Random.Range(0,LevelManager.instance.levelDifficulty);

        if(num == 1 && !cannotBeObstacle) { tileIsObstacle = true; }

        if (tileIsObstacle)
        {
            tag = "Obstacle";
            gameObject.layer = 8;
            GetComponent<Image>().color = Color.black;
            buttonCannotBeSet = true;
        }
        else
        {
            setStartViability();
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
           
            //RIGHT
            if (i == 1)
            {
                if (g.transform.position.y == transform.position.y && g.transform.position.x >= transform.position.x)
                {
                    tileImage.color = Color.yellow;
                    g.GetComponent<TileArrows>().buttonCannotBeSet = false;
                }
                else
                {
                    g.GetComponent<TileArrows>().buttonCannotBeSet = true;
                }
            }
            //LEFT
            else if (i == 3)
            {
                if (g.transform.position.y == transform.position.y && g.transform.position.x <= transform.position.x)
                {
                    tileImage.color = Color.yellow;
                    g.GetComponent<TileArrows>().buttonCannotBeSet = false;
                }
                else
                {
                    g.GetComponent<TileArrows>().buttonCannotBeSet = true;
                }
            }

            //UP
            else if (i == 0)
            {
                if (g.transform.position.x == transform.position.x && g.transform.position.y >= transform.position.y)
                {
                    tileImage.color = Color.yellow;
                    g.GetComponent<TileArrows>().buttonCannotBeSet = false;
                }
                else
                {
                    g.GetComponent<TileArrows>().buttonCannotBeSet = true;
                }
            }
            //DOWN
            else if (i == 2)
            {
                if (g.transform.position.x == transform.position.x && g.transform.position.y <= transform.position.y)
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

    void setStartViability()
    {
        float gty = GameManager.instance.startTile.transform.position.y;
        float gtx = GameManager.instance.startTile.transform.position.x;

        if (  gty == transform.position.y  || gtx == transform.position.x )
        {
            GetComponent<Image>().color = Color.yellow;
            buttonCannotBeSet = false;
        }
        else
        {
            buttonCannotBeSet = true;
        }
    }



}

