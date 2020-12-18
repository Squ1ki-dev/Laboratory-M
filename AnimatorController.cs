using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    int isBackwardsHash;
    int isRightStrafeHash;
    int isLeftStrafeHash;
    int isJumpingRunHash;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isBackwardsHash = Animator.StringToHash("isBackwards");
        isRightStrafeHash = Animator.StringToHash("isRightStrafe");
        isLeftStrafeHash = Animator.StringToHash("isLeftStrafe");
        isJumpingRunHash = Animator.StringToHash("isJumpingRun");;
    }

    void FixedUpdate()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isBackwards = animator.GetBool(isBackwardsHash);
        bool isRightStrafe = animator.GetBool(isRightStrafeHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool backwardPressed = Input.GetKey("s");
        bool rightPresed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");

        if(!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if(isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if(!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if(isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        if(!isBackwards && backwardPressed)
        {
            animator.SetBool(isBackwardsHash, true);
        }

        if(isBackwards && !backwardPressed)
        {
            animator.SetBool(isBackwardsHash, false);
        }
    }
}
