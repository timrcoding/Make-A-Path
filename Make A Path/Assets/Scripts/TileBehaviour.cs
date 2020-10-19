using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileBehaviour : MonoBehaviour
{
    //INDEX NUMBER OF TILE
    public int uniqueReference;

    //SHOWS INDEX NUMBER OF TILE
    [SerializeField]
    private TextMeshProUGUI indexNumberText;

    
    //COLLIDERS
    [SerializeField]
    private GameObject[] colliders;

    //SHOWS INDEX NUMBER OF NEIGHBOURS
    [SerializeField]
    public List<int> neighbourIndexes;

    void Start()
    {
        StartCoroutine(setNeigbours());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator setNeigbours()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        foreach(GameObject g in colliders)
        {
            TileColliderBehaviour tcb = g.GetComponent<TileColliderBehaviour>();
            neighbourIndexes.Add(tcb.neighbourIndex);
        }
        indexNumberText.text = uniqueReference.ToString();
    }
}
