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
        //IsFadeIn = true;
    }

    public void FadeOut()
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
        //IsFadeIn = false;
    }

    public void FadeInEnd()
    {
        IsFadeIn = true;
        Debug.Log("Fade in ended");
    }

    public void FadeOutEnd()
    {
        IsFadeIn = false;
        Debug.Log("Fade out ended");
    }

}
