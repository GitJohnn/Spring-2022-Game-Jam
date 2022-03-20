using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeanTweenTest : MonoBehaviour
{
    public TextMeshProUGUI testText;
    public LeanTweenType easeType;
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        Debug.Log("Text test");
    //        TextTest();
    //    }
    //}

    public void TextTest()
    {
        LeanTween.scale(testText.gameObject, new Vector2(1, 1) * 2, 0.1f).setEase(easeType).setOnComplete(()=> {
            LeanTween.scale(testText.gameObject, new Vector2(1, 1), 0.1f).setEase(easeType);
        });
    }
}
