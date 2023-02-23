using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        hideButton();
        GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButton>().resetButton();
        GameObject.FindGameObjectWithTag("Bee").GetComponent<BeeController>().PauseBee();
    }

    public void hideButton()
    {
        //pauseButton.SetActive(false);
        pauseButton.transform.position = new Vector3(-26.2545f, -2.1078f, 0f);
    }

    public void showButton() 
    {
        //pauseButton.SetActive(true);
        pauseButton.transform.position = new Vector3(-16.2545f, -2.1078f, 0f);
    }
}
