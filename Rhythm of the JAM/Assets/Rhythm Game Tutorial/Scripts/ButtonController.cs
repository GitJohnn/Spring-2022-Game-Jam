using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    private Color defaultColor;
    public Color pressedColor;

    public KeyCode KeyToPress;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = Color.white;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            if (!GameManager.instance.IsPaused && SongManager.Instance.InProgress)
            {
                theSR.color = pressedColor;
            }
        }

        if (Input.GetKeyUp(KeyToPress))
        {
            theSR.color = defaultColor;
        }
    }
}
