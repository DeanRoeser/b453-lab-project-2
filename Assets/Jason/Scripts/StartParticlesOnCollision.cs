using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticlesOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Bee")
            GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bee")
            GetComponent<ParticleSystem>().Play();
    }
}
