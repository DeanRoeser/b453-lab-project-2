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
    }
}
