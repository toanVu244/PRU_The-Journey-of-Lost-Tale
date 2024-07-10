using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPos;
    public VectorValue playerStoragePos;

    private void Start()
    {
        this.gameObject.SetActive(false);   
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStoragePos.innitialValue = playerPos;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
