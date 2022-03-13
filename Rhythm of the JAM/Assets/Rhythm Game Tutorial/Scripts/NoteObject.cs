using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject HitEffect, GoodEffect, PerfectEffect, MissEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                if(Mathf.Abs(transform.position.y) > 0.25f)
                {
                    NoteHitsManager.instance.NormalHit();
                    Instantiate(HitEffect, transform.position, Quaternion.identity);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    NoteHitsManager.instance.GoodHit();
                    Instantiate(GoodEffect, transform.position, Quaternion.identity);
                }
                else
                {
                    NoteHitsManager.instance.PerfectHit();
                    Instantiate(PerfectEffect, transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Activator") && this.gameObject.activeInHierarchy)
        {
            NoteHitsManager.instance.NoteMissed();
            Instantiate(MissEffect, transform.position, Quaternion.identity);
            canBePressed = false;
        }
    }
}
