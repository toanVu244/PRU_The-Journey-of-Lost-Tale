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

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI diagalogArea;

    private Queue<DialogLine> lineQueue;

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

        audioMange = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMange>();
    }

    public void SrartDiaglogue(Dialogue diaglogue)
    {
        dialogObject.SetActive(true);
        isDiaglogActive = true;

        lineQueue.Clear();

        foreach (DialogLine item in diaglogue.lines)
        {
            lineQueue.Enqueue(item);          
        }
        DisplayNextLine();
    }
    public void DisplayNextLine()
    {
        if(lineQueue.Count == 0)
        {                      
            Endiaglogue();
            audioMange.StopSFX();
            LoadGameStage();            
            return;          
        }
        audioMange.StopSFX();
        audioMange.PlayTalkSPX(audioMange.dialogSound);

        DialogLine currentLine = lineQueue.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
            
        StopAllCoroutines();
        StartCoroutine(Typesentence(currentLine));
    }

    public void LoadGameStage()
    {
        string currentString = SceneManager.GetActiveScene().name;
        switch (currentString)
        {
            case "CutScene_1":
                SceneController.instance.NextScene("Story1_Forest");
                break;
            case "CutScene_2":

                break;
            case "CutScene_3":

                break;
            case "CutScene_4":

                break;
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

    void Endiaglogue()
    {
        isDiaglogActive = false;
        dialogObject.SetActive(false);
    }
}
