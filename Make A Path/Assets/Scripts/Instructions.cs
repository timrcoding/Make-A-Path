using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField]
    private GameObject instructions;
    private bool instructionsOn;

    public void setInstructions()
    {
        instructionsOn = !instructionsOn;

        if (instructionsOn)
        {
            instructions.SetActive(true);
        }
        else
        {
            instructions.SetActive(false);
        }
    }
}
