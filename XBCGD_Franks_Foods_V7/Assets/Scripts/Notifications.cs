using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    public AudioManager audioManagerObj;

    public GameObject dialogueBox;

    public Text dialogueHeader;
    public Text dialogueBody;


    public void DisplayDialogue(string header, string body)
    {
        audioManagerObj.Play("Notification_Bad");
        dialogueBox.SetActive(true);
        dialogueHeader.text = header;
        dialogueBody.text = body;
    }

    public void HideDialogue()
    {
        audioManagerObj.Play("Mouse_Click");
        dialogueBox.SetActive(false);
    }    
}
