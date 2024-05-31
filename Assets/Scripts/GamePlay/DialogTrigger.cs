using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
public class DialogTrigger : MonoBehaviour
{
    public Dialogue dialog;

    public GameObject dialogObject;

    private bool playerInRange = false;

    AudioMange audioMange;

    public void Awake()
    {
        audioMange = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMange>();
    }

    public void TriggDiaLogue()
    {
        DialogManage.instance.SrartDiaglogue(dialog);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            playerInRange = false;
        }
    }
    public void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggDiaLogue();
            /*audioMange.PlayTalkSPX(audioMange.dialogSound);*/
        }
    }
    public void Start()
    {
        StartWaiting(result => {
            if (result)
            {
                TriggDiaLogue();            
            }
        });
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
