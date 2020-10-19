using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileArrows : MonoBehaviour
{
    [SerializeField]
    public bool buttonCannotBeSet;
    [SerializeField]
    private Sprite imageSprite;
    public bool tileSet;

    [SerializeField]
    private GameObject placementTiles;

    [SerializeField]
    private GameObject playerObject;

    void Start()
    {
        setAsObstacle();
    }

    private void Update()
    {
        
    }

    void setAsObstacle()
    {
        if (buttonCannotBeSet)
        {
            GetComponent<Image>().color = Color.black;
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
        detectPossiblePlacements();
        GetComponent<Image>().sprite = GameManager.instance.arrows[0];
        tileSet = true;
    }
    public void setRight()
    {
        detectPossiblePlacements();
        GetComponent<Image>().sprite = GameManager.instance.arrows[1];
        tileSet = true;
    }
    public void setDown()
    {
        detectPossiblePlacements();
        GetComponent<Image>().sprite = GameManager.instance.arrows[2];
        tileSet = true;
    }
    public void setLeft()
    {
        detectPossiblePlacements();
        GetComponent<Image>().sprite = GameManager.instance.arrows[3];
        tileSet = true;
    }

    public void detectPossiblePlacements()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject g in tiles)
        {
            Image tileImage = g.GetComponent<Image>();
            tileImage.color = Color.white;
            Transform tileTransform = g.transform;
            if(tileTransform.position.x == transform.position.x || tileTransform.position.y == transform.position.y)
            {
                tileImage.color = Color.yellow;
            }
        }
    }

    }

