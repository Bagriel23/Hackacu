using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechText;
    public string actorName;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] float radius;
    private DialogueControl dc;
    private bool onRadius;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }
    void FixedUpdate()
    {
        Interact();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onRadius)
        {
            dc.Speech(profile, speechText, actorName);
        }
    }
    
    public void  Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
