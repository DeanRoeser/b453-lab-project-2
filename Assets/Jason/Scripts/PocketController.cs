using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PocketController : MonoBehaviour
{
    public int numberOfItems;
    public GameObject itemType;
    public TextMeshProUGUI remainingItemsText;

    void Start()
    {
        SpawnNextItem();
    }

    private void SpawnNextItem()
    {
        if(numberOfItems <= 0)
        {
            remainingItemsText.text = "";
            return;
        }

        remainingItemsText.text = numberOfItems.ToString();
        numberOfItems--;

        Instantiate(itemType, this.transform.position, Quaternion.identity);
        itemType.transform.Find("Circle").gameObject.SetActive(false);
        itemType.transform.Find("Anim").gameObject.SetActive(false);
        itemType.GetComponent<CircleCollider2D>().enabled = false; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.usedByEffector && !collision.GetComponent<DragObject>().isActive)
        {
            SpawnNextItem();
            collision.GetComponent<DragObject>().isActive = true;
        }
            
    }
}
