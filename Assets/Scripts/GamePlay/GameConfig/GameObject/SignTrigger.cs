using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSignLine
{
    public string line;
}
[System.Serializable]
public class DialogueSign
{
    public List<DialogueSignLine> lines = new List<DialogueSignLine>();
}
public class SignTrigger : InteractableObject
{
    public DialogueSign dialog;

    public void Awake()
    {

    }

    public void TriggDiaLogue()
    {
        DialogManage.instance.SrartSignDiaglogue(dialog);
    }
    public void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggDiaLogue();
        }
    }
}
