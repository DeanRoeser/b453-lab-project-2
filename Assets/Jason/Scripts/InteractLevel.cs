using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLevel : MonoBehaviour
{

    private bool interactedWithFlower = false;
    private bool interactedWithCandle = false;
    private bool interactedWithSmoke = false;
    private bool interactedWithFan = false;
    public BoxCollider2D hiveCollider;

    void Start()
    {
        hiveCollider.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Flower")
        {
            interactedWithFlower = true;
            CheckStatus();
        }
        else if (collision.tag == "Fan")
        {
            interactedWithFan = true;
            CheckStatus();
        }
        else if (collision.tag == "Candle")
        {
            interactedWithCandle = true;
            CheckStatus();
        }
        else if (collision.tag == "Smoke")
        {
            interactedWithSmoke = true;
            CheckStatus();
        }
    }

    void CheckStatus()
    {
        if(interactedWithFlower &&
            interactedWithCandle &&
            interactedWithSmoke &&
            interactedWithFan)
        {
            hiveCollider.enabled = true;
        }
    }

}
