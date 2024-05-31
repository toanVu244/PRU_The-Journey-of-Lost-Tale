using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapScene : MonoBehaviour
{
    public string nextPlace;
    public static string ObjName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (nextPlace)
            {
                case "Forest":
                    {
                        SceneController.instance.NextScene("Story1_Forest");
                        break;
                    }
                case "Mountain":
                    {
                        SceneController.instance.NextScene("Story1_Mountain");
                        break;
                    }
                case "City":
                    {
                        SceneController.instance.NextScene("Story1_City");
                        break;
                    }
                case "Cave":
                    {
                        SceneController.instance.NextScene("Story1_Cave");
                        break;
                    }
                case "Question":
                    {
                        SceneController.instance.NextScene("QuestionScene");
                        break;
                    }
                default:
                    {
                        SceneController.instance.NextScene(nextPlace);
                        break;
                    }
            }
        }
    }
}
