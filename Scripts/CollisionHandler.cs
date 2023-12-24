using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject Explosion;
    void OnTriggerEnter(Collider other)
    {
        DeathSequence();
    }

    void DeathSequence()
    {
        SendMessage("OnDeath");
        Explosion.SetActive(true);
        Invoke("Restart", 1f);
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
