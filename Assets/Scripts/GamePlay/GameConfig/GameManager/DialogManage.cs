using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogManage : MonoBehaviour
{
    public static DialogManage instance;
    public GameObject dialogObject;
    public bool CutScene;
    public bool movementAllowed;
    public GameObject battle;
    public GameObject movement;
    public GameObject question;
    private CameraFollow cam;
    public Vector3 cameraChange;
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI diagalogArea;  
    private Queue<DialogLine> lineQueue;
    private Queue<DialogueSignLine> signLineQueue;
    public bool isDiaglogActive = false;
    public float typingSpeed;

    AudioMange audioMange;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        lineQueue = new Queue<DialogLine>();
        signLineQueue = new Queue<DialogueSignLine>();
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    public void SrartDiaglogue(Dialogue diaglogue)
    {
        dialogObject.SetActive(true);
        isDiaglogActive = true;
        FindObjectOfType<Movement>().isDialogActive = true;
        lineQueue.Clear();

        foreach (DialogLine item in diaglogue.lines)
        {
            lineQueue.Enqueue(item);          
        }
        DisplayNextLine();
    }

    public void SrartSignDiaglogue(DialogueSign diaglogue)
    {
        dialogObject.SetActive(true);
        isDiaglogActive = true;
        signLineQueue.Clear();

        foreach (DialogueSignLine item in diaglogue.lines)
        {
            signLineQueue.Enqueue(item);
        }
        DisplayNextSignLine();
    }

    public void DisplayNextLine()
    {
        if(lineQueue.Count == 0)
        {
            Endiaglogue();
            if (CutScene)
            {
                LoadGameStage();
            }                 
            return;          
        }

        DialogLine currentLine = lineQueue.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
            
        StopAllCoroutines();
        StartCoroutine(Typesentence(currentLine));
    }

    public void DisplayNextSignLine()
    {
        if (signLineQueue.Count == 0)
        {
            Endiaglogue();
            return;
        }

        DialogueSignLine currentLine = signLineQueue.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypesentenceSign(currentLine));
    }

    public void LoadGameStage()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("CutScene_1"))
        {
            SceneManager.LoadScene("CutScene_2");
        }else if (currentScene.Equals("CutScene_2"))
        {
            SceneManager.LoadScene("CutScene_3");
        }
        else if (currentScene.Equals("CutScene_3"))
        {
            SceneManager.LoadScene("Story1_Forest");
        }
        else if (currentScene.Equals("CutScene_4"))
        {
            SceneManager.LoadScene("CutScene_5");
        }
    }


    IEnumerator Typesentence(DialogLine lines)
    {
        diagalogArea.text = "";
        foreach (char item in lines.line.ToCharArray())
        {
            diagalogArea.text += item;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator TypesentenceSign(DialogueSignLine lines)
    {
        diagalogArea.text = "";
        foreach (char item in lines.line.ToCharArray())
        {
            diagalogArea.text += item;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Endiaglogue()
    {
        isDiaglogActive = false;
        dialogObject.SetActive(false);
        FindObjectOfType<Movement>().isDialogActive = false;
    }

    public void StartCombatAfterDialogue()
    {
        if (!isDiaglogActive) 
        {       
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            battle.SetActive(true);
            if (battle.activeSelf)
            {
                audioMange = GameObject.FindWithTag("Audio").GetComponent<AudioMange>();
                audioMange.ChangeCBBackground();
            }
        }
    }

    public void StartQuestionAfterDialogue()
    {
        if (!isDiaglogActive)
        {
            question.SetActive(true);
            FindObjectOfType<Movement>().isDialogActive = false;
        }
    }

    public void StartWaiting(System.Action<bool> callback)
    {
        StartCoroutine(WaitAndReturnTrue(callback));
    }
    private IEnumerator WaitAndReturnTrue(System.Action<bool> callback)
    {
        yield return new WaitForSeconds(4f);
        callback(true);
    }
}
