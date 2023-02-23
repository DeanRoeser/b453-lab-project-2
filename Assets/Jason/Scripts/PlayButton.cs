using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [HideInInspector]
    public bool doNotClick = false;

    private void OnMouseUpAsButton()
    {
        GameObject.FindGameObjectWithTag("Bee").GetComponent<BeeController>().StartBee();
        GetComponent<BoxCollider2D>().enabled = false;
        doNotClick = true;
        GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseButton>().showButton();
    }

    public void resetButton()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        doNotClick = false;
    }
}
