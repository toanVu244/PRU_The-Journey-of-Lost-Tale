using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class NPCInteractable : MonoBehaviour
{
    public Animator animator;   
    private void Start()
    {
        animator.SetBool("isLeft", true);
        animator.SetBool("isRight", true);
    }
}
