using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{        
    public GameObject HitEffect, GoodEffect, PerfectEffect, MissEffect;
    public KeyCode keyToPress;
    public float assignedTime;

    private SpriteRenderer _renderer;
    private double timeInstantiated;
    private float noteDespawn;
    void Awake()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
        _renderer = GetComponent<SpriteRenderer>();
        noteDespawn = SongManager.Instance.noteDespawnY;
        _renderer.enabled = false;
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
    }

    public void DisableNote()
    {
        gameObject.SetActive(false);

        if (Mathf.Abs(transform.position.y) > 0.25f)
        {
            NoteHitsManager.instance.NormalHit();
            Instantiate(HitEffect, transform.position, Quaternion.identity);
        }
        else if (Mathf.Abs(transform.position.y) > 0.05f)
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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag.Equals("Activator"))
    //    {
    //        canBePressed = true;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Activator") && this.gameObject.activeInHierarchy)
        {
            NoteHitsManager.instance.NoteMissed();
            Instantiate(MissEffect, transform.position, Quaternion.identity);
        }
    }

}
