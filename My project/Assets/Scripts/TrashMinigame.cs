using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashMinigame : MonoBehaviour
{
    [SerializeField] private GameObject trashCan;
    [SerializeField] private GameObject trashCanCanvas;
    [SerializeField] private GameObject trash;
    [SerializeField] private Text CanCountCanvas;
    public static int trashCanCount;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] private float radius;
    private bool onRadius;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        trashCanCount = 0;
        UpdateCanCount();
    }

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
        if (trashCanCount == 8)
        {
            SceneManager.LoadScene("Praia");
        }
    }

    public void Interact()
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
        trashCan.SetActive(false);
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
