using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BeeController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float force = 100;
    public TMP_Text winLose;
    public TMP_Text message;
    public Vector3 initialPosition;
    public Vector3 pausedPosition;
    public bool paused = false;
    public GameObject trail_object;

    void Start()
    {
        winLose.enabled = false;
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {

        if(paused){
            transform.position = pausedPosition;
        }else{
            if(rb2D.velocity.x >= 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if(rb2D.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            spawnTrail();
        }

        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            if(Input.GetKeyDown(KeyCode.L))
                StartCoroutine(NextLevelTimer());
        }
    }

    public void spawnTrail() 
    {
        Instantiate(trail_object, transform.position, transform.rotation);
    }

    public void StartBee()
    {
        paused = false;
        GetComponent<CircleCollider2D>().enabled = true;
        transform.position = initialPosition;
        rb2D.isKinematic = false;
        rb2D.AddForce(transform.right * force);
        clearTrail();


        
    }


    public void clearTrail()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        foreach(GameObject trail in trails)
            GameObject.Destroy(trail);
    }


    public void PauseBee()
    {
        paused = true;
        rb2D.velocity = rb2D.velocity * 0f;
        pausedPosition = transform.position;
    }


    private void SlowBee()
    {
        Debug.Log("SlowBee");
        rb2D.velocity = rb2D.velocity * 0.8f;
    }

    private void FastBee()
    {
        Debug.Log("FastBee");
        rb2D.velocity = rb2D.velocity - rb2D.velocity;
    }

    IEnumerator NextLevelTimer()
    {
        yield return new WaitForSecondsRealtime(3);
        if(SceneManager.sceneCountInBuildSettings -1 == SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bee Trigger Tag = " + collision.tag);
        if (collision.tag == "Smoke")
        {
            SlowBee();
        }

        if(collision.tag == "Fan")
        {
            FastBee();
        }

        if(collision.tag == "Hive")
        {
            Debug.Log("You win!");
            winLose.enabled = true;
            winLose.text = "You Win";
            message.text = "Bee made it home!";
            rb2D.velocity = rb2D.velocity - rb2D.velocity;
            StartCoroutine(NextLevelTimer());
        }

        if(collision.tag == "Frog")
        {
            winLose.enabled = true;
            winLose.text = "You Lose";
            message.text = "Bee didn't make it...";
            rb2D.velocity = rb2D.velocity - rb2D.velocity;
        }
    }
}
