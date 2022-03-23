using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingGuyAnimator : MonoBehaviour
{
    public float changeAnimationDelay = 0.25f;
    public string currentState;
    private Animator _animator;
    private bool upArrow, downArrow, leftArrow, rightArrow;    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("IdleMove");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.PlayingGame && !GameManager.instance.IsPaused)
        {
            DetectInput();
        }
        
        SetAnimations();
    }

    private void SetAnimations()
    {
        if (upArrow)
        {
            StartCoroutine(ChangeAnimationState("UpArrowMove"));
            //ChangeState("UpArrowMove");
            //if (downArrow)
            //{
            //    ChangeAnimationState("DownUpMove");                
            //}
            //else if (leftArrow)
            //{
            //    ChangeAnimationState("LeftUpMove");
            //}
            //else if (rightArrow)
            //{
            //    ChangeAnimationState("UpRightMove");
            //}
            //else
            //{
            //    ChangeAnimationState("UpArrowMove");
            //}
            return;
        }

        if (downArrow)
        {
            StartCoroutine(ChangeAnimationState("DownArrowMove"));
            //ChangeState("DownArrowMove");
            //if (leftArrow)
            //{
            //    ChangeAnimationState("DownLeftMove");
            //}
            //else if (rightArrow)
            //{
            //    ChangeAnimationState("DownRightMove");
            //}
            //else
            //{
            //    ChangeAnimationState("DownArrowMove");
            //}
            return;
        }

        if (leftArrow)
        {
            StartCoroutine(ChangeAnimationState("LeftArrowMove"));
            //ChangeState("LeftArrowMove");
            //if (rightArrow)
            //{
            //    ChangeAnimationState("LeftRightMove");
            //}
            //else
            //{
            //    ChangeAnimationState("LeftArrowMove");
            //}
            return;
        }

        if (rightArrow)
        {
            StartCoroutine(ChangeAnimationState("RightArrowMove"));
            //ChangeState("RightArrowMove");
            return;
        }

        if(!upArrow && !downArrow && !leftArrow && !rightArrow)
        {
            StartCoroutine(ChangeAnimationState("IdleMove"));
            //ChangeState("IdleMove");
            return;
        }
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //_animator.SetBool("Up", true);
            upArrow = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //_animator.SetBool("Up", false);
            upArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //_animator.SetBool("Down", true);
            downArrow = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //_animator.SetBool("Down", false);
            downArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //_animator.SetBool("Left", true);
            leftArrow = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //_animator.SetBool("Left", false);
            leftArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //_animator.SetBool("Right", true);
            rightArrow = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //_animator.SetBool("Right", false);
            rightArrow = false;
        }
    }

    private IEnumerator ChangeAnimationState(string newState)
    {        
        ChangeState(newState);
        yield return new WaitForSeconds(changeAnimationDelay);
    }

    private void ChangeState(string newState)
    {
        if (currentState.Equals(newState))
            return;

        _animator.Play(newState);
        //Debug.Log("Playing " + newState);
        currentState = newState;
    }

}
