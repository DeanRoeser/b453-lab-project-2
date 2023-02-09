using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool IsDetectingCollision = false;
    public GameObject circle;
    public GameObject anim;
    public Collider2D effectorCollider;
    public bool isActive = false;

    void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButton>().doNotClick == true) return;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        if (GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButton>().doNotClick == true) return;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        StartCoroutine(AllowCollision());
    }

    IEnumerator AllowCollision()
    {
        IsDetectingCollision = true;
        Debug.Log(IsDetectingCollision);
        yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(0.05f);        
        yield return new WaitForFixedUpdate();
        IsDetectingCollision = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsDetectingCollision)
        {
            if (!collision.usedByEffector)
            {
                Debug.Log("Detected Box");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter!");
        if (!collision.usedByEffector)
        {
            Debug.Log("Turn Red " + collision.tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit!");
        if (!collision.usedByEffector)
        {
            Debug.Log("Red Off " + collision.tag);
        }

        if (collision.tag == "Pocket" && isActive == false)
        {
            //isActive = true;
            circle.SetActive(true);
            anim.SetActive(true);
            effectorCollider.enabled = true;
        }
    }
}
