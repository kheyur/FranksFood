using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox;
    public Text nameText;
    public Text sentenceText;

    public Queue<string> sentences;

   // public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        dialogueBox.gameObject.SetActive(true);
        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        sentenceText.text = sentence;
    }

    public void EndDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
  
    }

}
