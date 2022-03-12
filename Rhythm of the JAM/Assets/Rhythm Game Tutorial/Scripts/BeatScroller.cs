using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f; //beats per minute turns to beats per second    
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            transform.position += Vector3.down * (beatTempo * Time.deltaTime);
        }
    }
}
