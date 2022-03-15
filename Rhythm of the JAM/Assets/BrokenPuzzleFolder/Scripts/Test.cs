using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float currentTime = 0;
    int timerate = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("First run");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > timerate)
        {
            currentTime = 0;
            Debug.Log("3 seconds have passed");
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}
