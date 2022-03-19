using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{        
    public GameObject HitEffect, GoodEffect, PerfectEffect, MissEffect;
    public KeyCode keyToPress;
    public float hitYPos, goodHitYPos;
    public float AssignedTime { get; set; }

    private SpriteRenderer _renderer;
    private double timeInstantiated;
    private float noteDespawn;
    private bool canBePressed;
    private float initialYPos;
    void Awake()
    {
        initialYPos = transform.position.y;
        timeInstantiated = SongManager.GetAudioSourceTime();
        _renderer = GetComponent<SpriteRenderer>();
        noteDespawn = SongManager.Instance.noteDespawnY;
        _renderer.enabled = false;
        canBePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            _renderer.enabled = true;
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * noteDespawn, t);            
        }

        if (canBePressed && Input.GetKeyDown(keyToPress))
        {
            gameObject.SetActive(false);

            if (Mathf.Abs(transform.position.y) > initialYPos + 0.25f)
            {
                NoteHitsManager.instance.NormalHit();
                Instantiate(HitEffect, transform.position, Quaternion.identity);
            }
            else if (Mathf.Abs(transform.position.y) > initialYPos + 0.05f)
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

    //public void DisableNote()
    //{       

    //}

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
            canBePressed = false;
            NoteHitsManager.instance.NoteMissed();
            Instantiate(MissEffect, transform.position, Quaternion.identity);
        }
    }

}
