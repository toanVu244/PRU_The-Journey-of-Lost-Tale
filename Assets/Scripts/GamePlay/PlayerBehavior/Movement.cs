using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private Vector3 direction;

    public VectorValue playerStartPos;
    public bool isDialogActive = false;
    public bool isQuestionActive = false;

    public void Start()
    {
        transform.position = playerStartPos.innitialValue;
    }

    public void Update()
    {
        if (isDialogActive || isQuestionActive)
        {
            return;
        }
        else
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            direction = new Vector3(horizontal, vertical, 0);
            AnimatorMoving(direction);
        }
    }

    public void FixedUpdate()
    {
        if (isDialogActive || isQuestionActive)        
            return;        
        else
        transform.position += direction * speed * Time.deltaTime;
    }
    public void AnimatorMoving(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
