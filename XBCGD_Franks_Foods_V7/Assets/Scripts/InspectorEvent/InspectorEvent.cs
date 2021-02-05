using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorEvent : MonoBehaviour
{
    //Will spawn in the objects when the event begins. Will only trigger once the event button is clicked.

    public static InspectorEvent Instance { get; private set; }  //timer for the inspector event. 

   

    //FLOATS
    float timerCount = 5;

    //BOOLS
    bool swag; //used for colorator

    //GAMEOBJECTS
    public List<GameObject> objects; //holds the contraband stuff
  //  public GameObject canvas;
    public GameObject timer;
    public Image inspPanel;

    // Start is called before the first frame update
    void Start()
    {
     
     
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.GetComponent<InspectorEventTimer>().inspectorEvent == true)
        {
           ObjectsHandler();
       
        }

        timerCount -= Time.deltaTime;

        if(timerCount == 2)
        {
            timerCount = 5;
            if (swag == true)
            {
                swag = false;
                PanelColorator(swag);
            }
            else
            {
                swag = true;
                PanelColorator(swag);
            }
            
        }
    }

    public void ObjectsHandler()
    {

      //  int score = canvas.GetComponent<UIManager>().score;

        foreach (GameObject j in objects)
        {
            Instantiate(j.transform);
            j.gameObject.SetActive(true);
        }

     /*   if(score == 40)
        {
            TimeComplete(true);
        } */
    }

    public void PanelColorator(bool switchCol)
    {
        if(switchCol == true)
        {
            inspPanel = GameObject.Find("InspectorPanel").GetComponent<Image>();
            inspPanel.color = Color.red;
            swag = false;
        }
        else
        {
            inspPanel = GameObject.Find("InspectorPanel").GetComponent<Image>();
            inspPanel.color = Color.gray;
            swag = true;
        }
      
    }
}
