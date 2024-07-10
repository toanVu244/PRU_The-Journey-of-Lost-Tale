using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DialogCharacter
{
    public Sprite icon;
    public string name;
}
[System.Serializable]
public class DialogLine
{
    public DialogCharacter character;
    [TextArea(3,10)]
    public string line;
}
[System.Serializable]
public class Dialogue
{
    public List<DialogLine> lines = new List<DialogLine>();
}
public enum QuestProgress { Stage1, Stage2, Stage3 };
public class DialogTrigger : InteractableObject
{
    public Dialogue dialog;
    public Dialogue questDialog;
    public bool haveQuest;
    public PlayerInventory playerInventory;
    public InventoryItem requiredItem;
    public QuestProgress CurrentQuestProgress;
    public int CurrentChapter;
    public BoxCollider2D physic;

    public void TriggDiaLogue()
    {
        DialogManage.instance.SrartDiaglogue(dialog);
    }

    public void TriggQuestDialogue()
    {
        DialogManage.instance.SrartDiaglogue(questDialog);
    }
    public void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (haveQuest)
            {
                GiveQuest();
            }
            else
            {
                TriggDiaLogue();
            }
        }
        if (playerInRange && Input.GetKeyDown(KeyCode.Space) && haveQuest)
        {
            if (playerInventory.currentInventory.Contains(requiredItem))
            {
                requiredItem.Use();
                CurrentQuestProgress = QuestProgress.Stage2;
                GiveQuest();
            }
        }
        if (npcInRange)
        {
            TriggDiaLogue();
        }
    }

    public void GiveQuest()
    {
        if(CurrentChapter == 1)
        {
            if (this.gameObject.name == "ThachSanh" && CurrentQuestProgress == QuestProgress.Stage1)
            {
                TriggQuestDialogue();
            }
            else if (this.gameObject.name == "ThachSanh" && CurrentQuestProgress == QuestProgress.Stage2)
            {
                StartWaiting(result =>
                {
                    if (result)
                    {
                        TriggDiaLogue();
                        CurrentQuestProgress = QuestProgress.Stage3;
                        GiveQuest();
                    }
                });                     
            }
            else if(this.gameObject.name == "ThachSanh" && CurrentQuestProgress == QuestProgress.Stage3)
            {
                StartWaiting(result =>
                {
                    if (result)
                    {
                        DialogManage.instance.StartCombatAfterDialogue();
                    }
                });
            }
            else if(this.gameObject.name == "ThanRung" && CurrentQuestProgress == QuestProgress.Stage1)
            {
                TriggDiaLogue();             
                CurrentQuestProgress = QuestProgress.Stage2;
                GiveQuest();
            }else if(this.gameObject.name == "ThanRung" && CurrentQuestProgress == QuestProgress.Stage2)
            {
                StartWaiting(result =>
                {
                    if (result)
                    {
                        DialogManage.instance.StartQuestionAfterDialogue();
                    }
                });
            }
        }
        else if (CurrentChapter == 2)
        {
            if (this.gameObject.name == "ThachSanh" && CurrentQuestProgress == QuestProgress.Stage1)
            {
                TriggQuestDialogue();
            }
            else if (this.gameObject.name == "ThachSanh" && CurrentQuestProgress == QuestProgress.Stage2)
            {
                StartWaiting(result =>
                {
                    if (result)
                    {
                        TriggDiaLogue();
                        CurrentQuestProgress = QuestProgress.Stage3;
                        GiveQuest();
                    }
                });
            }
            else if (this.gameObject.name == "ThachSanh" && CurrentQuestProgress == QuestProgress.Stage3)
            {
                StartWaiting(result =>
                {
                    if (result)
                    {
                        SceneManager.LoadScene("Strory1_Cave");
                    }
                });
            }
            else if (this.gameObject.name == "ThanRung" && CurrentQuestProgress == QuestProgress.Stage1)
            {
                TriggDiaLogue();
                CurrentQuestProgress = QuestProgress.Stage2;
                GiveQuest();
            }
            else if (this.gameObject.name == "ThanRung" && CurrentQuestProgress == QuestProgress.Stage2)
            {
                StartWaiting(result =>
                {
                    if (result)
                    {
                        DialogManage.instance.StartQuestionAfterDialogue();
                    }
                });
            }
        }
    }

    public void Start()
    {
        string currentString = SceneManager.GetActiveScene().name;
        if (currentString.Contains("CutScene_1"))
        {
            StartWaiting(result =>
            {
                if (result)
                {
                    TriggDiaLogue();
                }
            });
        }
    }

    public void StartWaiting(System.Action<bool> callback)
    {
        StartCoroutine(WaitAndReturnTrue(callback));
    }
    private IEnumerator WaitAndReturnTrue(System.Action<bool> callback)
    {
        yield return new WaitForSeconds(5f);
        callback(true);
    }
}
