using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int healthpoints = 50;
    [SerializeField] ParticleSystem deathFx;
    [SerializeField] GameObject[] enemnybody;
    


    ScoreBoard scoreBoard;

    void Start()
    {
        Boxcolliding();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void Boxcolliding()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        healthpoints--;
        if (healthpoints <= 0)
        {
            deathFx.Play();
            foreach (GameObject enemnybody in enemnybody)
            {
                enemnybody.SetActive(false);
                Invoke("respawn",10f);
            }
        }
    }

    void respawn()
    {
        foreach (GameObject enemnybody in enemnybody)
        {
            enemnybody.SetActive(true);
        }
    }
}
