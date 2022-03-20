using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public Animator animator;
    public bool IsFadeIn { get; set; } = false;

    public void FadeIn()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
    }

    public void FadeOut()
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }

    public void FadeInEnd()
    {
        IsFadeIn = true;
    }

    public void FadeOutEnd()
    {
        IsFadeIn = false;
    }

}
