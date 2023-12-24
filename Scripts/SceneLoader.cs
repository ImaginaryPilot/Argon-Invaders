using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("loadnextscene", 5f);
    }

    void loadnextscene()
    {
        SceneManager.LoadScene(1);
    }
}
