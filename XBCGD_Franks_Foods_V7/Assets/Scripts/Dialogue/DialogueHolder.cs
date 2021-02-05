using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    //Container for each dialogue interaction that takes place. Different to Dialogue trigger, which holds an array of sentences spoken by one person. This instead holds the entire conversation

    public GameObject[] dialogues;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //returns the dialogue object in the position passed
    public GameObject ChangeDialogue(int numInQueue)
    {
        for (int i = numInQueue; i < dialogues.Length; i++)
        {
            return dialogues[numInQueue];
            if(numInQueue == 1)
            {
                return dialogues[numInQueue];
            }
            else if(numInQueue == 2)
            {

            }
        }
        return null;
    }
}
