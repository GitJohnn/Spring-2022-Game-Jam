using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public static FadeController instance;


    private Animator animator;    
    public bool IsFadeIn { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        FadeIn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (IsFadeIn)
            {
                FadeOut();                
            }
            else
            {
                FadeIn();
                
            }            
        }
    }

    public void FadeIn()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        IsFadeIn = true;
    }

    public void FadeOut()
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
        IsFadeIn = false;
    }

}
