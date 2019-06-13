﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private string sentence = "default";

    private IEnumerator coroutine;
    protected Queue<string> sentences;
    protected Queue<Speech> speeches;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        speeches = new Queue<Speech>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        speeches.Clear();
        sentences.Clear();

        foreach (Speech speech in dialogue.discution)
        {
            speeches.Enqueue(speech);
            Debug.Log(sentence);
        }

        DisplayNextSpeech();

    }

    public void DisplayNextSpeech()
    {
        Debug.Log("speech lancé");

        Speech speech = speeches.Dequeue();
        nameText.text = speech.name;

        foreach (string sentence in speech.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log(sentence);
        }
       
            DisplayNextSentence();


    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            if (speeches.Count == 0)
            {
                Debug.Log("sentence = 0, speech != 0");
                EndDialogue();
                return;
            }
            else
            {
                Debug.Log("sentence = 0, speech != 0");
                DisplayNextSpeech();
                return;
            }
        }
        Debug.Log(sentence);
        if (sentence != "default"){
            StopCoroutine(coroutine);
        }
        sentence = sentences.Dequeue();
        coroutine = TypeSentence(sentence);
        StartCoroutine(coroutine);
        WaitNextSentence();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

 void EndDialogue()
    {
        Debug.Log("dialogue du manager fini");

        animator.SetBool("IsOpen", false);
    }

    // For the Automatic Dialogue, on the top of the screen, which go on alone


    void WaitNextSentence()
    {
        return;
    }

 
}