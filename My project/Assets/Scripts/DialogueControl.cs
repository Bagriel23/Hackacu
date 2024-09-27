using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject dialogueObj;
    [SerializeField] private Image profile;
    [SerializeField] private Text speechText;
    [SerializeField] private Text ActorNameText;

    [Header("Settings")]    
    [SerializeField] private float typingSpeed = 0.05f;
    private string[] sentences;
    private int index;
    private bool isTyping;
    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        ActorNameText.text = actorName;
        StartCoroutine(TypeSentences());
        NextSentence();
    }

    IEnumerator TypeSentences()
    {
        isTyping = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            Debug.Log(speechText.text);
        }
        isTyping = false;
    }

    public void NextSentence()
    {
        Debug.Log(index);
        Debug.Log(sentences[index]);
        if (speechText.text == sentences[index] && !isTyping)
         {
            if (index < sentences.Length - 1)
            {
                index ++;
                speechText.text = "";
                StartCoroutine(TypeSentences());
            }   
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
            }
        }
    }
}