using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashMinigame : MonoBehaviour
{
    //[SerializeField] private GameObject trashCan;
    [SerializeField] private GameObject trashCanCanvas;
    [SerializeField] private Text CanCountCanvas;
    private static int trashCanCount;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] private float radius;
    private bool onRadius;

    // Start is called before the first frame update
    void Start()
    {
        trashCanCount = 0;
        UpdateCanCount();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Interact();
    }
    void Update()
    {
        if (onRadius && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
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
    private void PickUp()
    {
            if (trashCanCount == 0)
            {
                trashCanCanvas.SetActive(true);
            }
        trashCanCount ++;
        UpdateCanCount();
        gameObject.SetActive(false);
        Debug.Log(trashCanCount);
    }

    private void UpdateCanCount()
    {
        CanCountCanvas.text = " x" + trashCanCount;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
