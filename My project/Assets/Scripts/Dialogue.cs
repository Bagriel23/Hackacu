using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechText;
    public string actorName;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] float radius;
    [SerializeField] Button nextSentenceButton;
    private DialogueControl dc;
    private bool onRadius;
    private int timesKeyPressed;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
        timesKeyPressed = 0;
    }
    void FixedUpdate()
    {
        Interact();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onRadius)
        {
            if (timesKeyPressed == 0)
            {
                dc.Speech(profile, speechText, actorName);
                timesKeyPressed++;
            }
            else
            {
                nextSentenceButton.onClick.Invoke();
            }
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
