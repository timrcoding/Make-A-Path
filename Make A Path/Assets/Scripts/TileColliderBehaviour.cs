using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliderBehaviour : MonoBehaviour
{
    [SerializeField]
    public int neighbourIndex;
    private bool sent;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Tile")
        {
            if (!sent)
            {
                Debug.Log("Tile ");
                neighbourIndex = other.GetComponentInParent<TileBehaviour>().uniqueReference;
                sent = true;
            }
        }
    }

}
