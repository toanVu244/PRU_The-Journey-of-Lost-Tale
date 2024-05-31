using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [SerializeField] Animator animator;
    public void Awake()
    {
        if(instance = this)
        {
            instance = this;
        }
    }

    public void NextScene(string place)
    {
        animator.Play("ChangeScene");
        SceneManager.LoadSceneAsync(place);
    }
}
