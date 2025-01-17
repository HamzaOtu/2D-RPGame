using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int moving = Animator.StringToHash("Moving");
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    public void SetMoveBoolTransition(bool value)
    {
        animator.SetBool(moving, value);
    }

    public void SetMoveAnimation(Vector2 dir)
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }

    public void ResetPlayer()
    {
        SetMoveAnimation(Vector2.down);
        animator.SetTrigger(revive);
    }
}
