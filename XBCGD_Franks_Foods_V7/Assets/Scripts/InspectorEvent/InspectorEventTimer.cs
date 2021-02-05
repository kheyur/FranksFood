using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorEventTimer : MonoBehaviour
{
    public static InspectorEventTimer Instance { get; private set; }  //timer for the inspector event. 

    //UI
    public Button checkItemsBtn;

    //GAMEOBJECTS
    public GameObject easy, medium, hard; //difficulty
    public GameObject location1, location2, location3, location4; //hidden objects easy
    public GameObject location5, location6, location7, location8;//hidden objects medium;
    public GameObject location9, location10, location11, location12;//hidden objects hard


    public Random r; //used for randomising positions
    
    public Text moneyTxt;
    public Text numRem1;
    public int num1;
    public Text numRem2;
    public int num2;
    public Text numRem3;
    public int num3;

    public bool timeUp;
    bool swag; //used for the colour switcher for the inspector panel

    public float timeRemaining;

    public bool inspectorEvent = false;
    public bool eventRunning = false;

    public int difficulty;

    //Event stuff
    public Image inspPanel;
    public Image inspEndScreen;
    public Text outcomeTxt;
    public IncrementialManager incMan;
    public Button closeEndBtn;

    public ProgressTracker timerPT;
    float timerIncrementSize = 1;


    //  ObjectController objCon;
    public GameObject inspHand;

    void Start()
    {
       // StartCoroutine(StartCountdown());
        // objCon = GameObject.Find("ObjectHolder").GetComponent<ObjectController>();
        inspHand = GetComponent<GameObject>();
        difficulty = 1;
        timeRemaining = 3;
    }

    //Runs during the update method. Checks to see the total money - if it hits a threshold then the event will trigger. The higher the total money, the harder the event
    private void Update()
    {
       
        
            if (inspectorEvent == true)
            {
                EventChecker();

            }


            if (incMan.totalMoney == 100)
            {
                inspectorEvent = true;
                difficulty = 1;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 200)
            {
                inspectorEvent = true;
                difficulty = 1;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 350)
            {
                inspectorEvent = true;
                difficulty = 1;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 450)
            {
                inspectorEvent = true;
                difficulty = 2;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 560)
            {
                inspectorEvent = true;
                difficulty = 2;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 650)
            {
                inspectorEvent = true;
                difficulty = 2;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 810)
            {
                inspectorEvent = true;
                difficulty = 3;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
            else if (incMan.totalMoney == 900)
            {
                inspectorEvent = true;
                difficulty = 3;
                incMan.totalMoney += 1;
                eventRunning = false;
            }
          

            if (timeRemaining == 0)
            {
                inspEndScreen.gameObject.SetActive(true);
                outcomeTxt.text = "Failed to avoid the inspector!";
                inspectorEvent = false;
                eventRunning = false;
                StopCoroutine(StartCountdown());
                StopCoroutine(FillRadialTimer());
                timerPT.current = 0;



                if (difficulty == 1)
                {

                    incMan.totalMoney -= 10.0m;
                    moneyTxt.text = incMan.totalMoney.ToString();
                    timeRemaining = 3;

                }
                else if (difficulty == 2)
                {

                    incMan.totalMoney -= 20.0m;
                    moneyTxt.text = incMan.totalMoney.ToString();
                    timeRemaining = 3;
                }
                else if (difficulty == 3)
                {
                    incMan.totalMoney -= 30.0m;
                    moneyTxt.text = incMan.totalMoney.ToString();
                    timeRemaining = 3;
                }

            
        }
      

     

        

    }

    //if the threshold is met, run the inspector event that matches the threshold requirements
    public void EventChecker()
    {
        
        if (inspectorEvent == true)
        {
            inspPanel.gameObject.SetActive(true);
            if (difficulty == 1)
            {
                inspectorEvent = false;
                eventRunning = false;
                int d = Random.Range(0, 3);
                if (d == 0)
                {

                    location1.gameObject.SetActive(true);
                    num1 = 1;
                    num2 = 1;
                    num3 = 1;
                    numRem1.text = num1 +"x";
                    numRem2.text = num2 +"x";
                    numRem3.text = num3 +"x";
                }
                else if (d == 1)
                {
                    location2.gameObject.SetActive(true);
                    num1 = 1;
                    num2 = 2;
                    num3 = 1;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else if (d == 2)
                {
                    location3.gameObject.SetActive(true);
                    num1 = 2;
                    num2 = 1;
                    num3 = 1;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else
                {
                    location4.gameObject.SetActive(true);
                    num1 = 2;
                    num2 = 1;
                    num3 = 1;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
            }
            else if (difficulty == 2)
            {
                inspectorEvent = false;
                eventRunning = false;
                int k = Random.Range(0, 3);
                if (k == 0)
                {
                    location5.gameObject.SetActive(true);
                    num1 = 2;
                    num2 = 2;
                    num3 = 1;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else if (k == 1)
                {
                    location6.gameObject.SetActive(true);
                    num1 = 2;
                    num2 = 3;
                    num3 = 2;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else if (k == 2)
                {
                    location7.gameObject.SetActive(true);
                    num1 = 3;
                    num2 = 2;
                    num3 = 2;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else
                {
                    location8.gameObject.SetActive(true);
                    num1 = 3;
                    num2 = 2;
                    num3 = 3;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }

            }
            else if (difficulty == 3)
            {
                inspectorEvent = false;
                eventRunning = false;
                int j = Random.Range(0, 3);
                if (j == 0)
                {
                    location9.gameObject.SetActive(true);
                    num1 = 4;
                    num2 = 3;
                    num3 = 4;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else if (j == 1)
                {
                    location10.gameObject.SetActive(true);
                    num1 = 4;
                    num2 = 3;
                    num3 = 4;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else if (j == 2)
                {
                    location11.gameObject.SetActive(true);
                    num1 = 4;
                    num2 = 3;
                    num3 = 4;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
                else
                {
                    location12.gameObject.SetActive(true);
                    num1 = 4;
                    num2 = 3;
                    num3 = 4;
                    numRem1.text = num1 + "x";
                    numRem2.text = num2 + "x";
                    numRem3.text = num3 + "x";
                }
            }

         


            StartCoroutine(StartCountdown());
            StartCoroutine(FillRadialTimer());
        }
    }

    public bool BoolChecker(bool running)
    {
     return inspectorEvent = running;
   
    }

    public void CloseInspEnd()
    {
        inspEndScreen.gameObject.SetActive(false);
        inspPanel.gameObject.SetActive(false);

        location1.gameObject.SetActive(false);
        location2.gameObject.SetActive(false);
        location3.gameObject.SetActive(false);
        location4.gameObject.SetActive(false);
        location5.gameObject.SetActive(false);
        location6.gameObject.SetActive(false);
        location7.gameObject.SetActive(false);
        location8.gameObject.SetActive(false);
        location9.gameObject.SetActive(false);
        location10.gameObject.SetActive(false);
        location11.gameObject.SetActive(false);
        location12.gameObject.SetActive(false);
        

    }

    //checks to see if all the items have been destroyed and determines whether the event is, plus the outcome
    public void CheckItems()
    {
       
        if (num1 <= 0 && num2 <= 0 && num3 <= 0)
        {
            eventRunning = false;
            inspEndScreen.gameObject.SetActive(true);
            outcomeTxt.text = "Successfully avoided the inspector";
            inspectorEvent = false;
           
            StopCoroutine(StartCountdown());

            num1 = 0;
            num2 = 0;
            num3 = 0;
        }

      
    }


    public IEnumerator StartCountdown(float countdownValue = 30)
    {
       
        timeRemaining = countdownValue;
        while (timeRemaining > 0)
        {
         
            if(difficulty == 1)
            {
                yield return new WaitForSeconds(1.0f);
                timeRemaining-=2 ;
            }
            else if (difficulty == 2)
            {
                yield return new WaitForSeconds(1.0f);
                timeRemaining-= 3;
            }
            else if(difficulty == 3)
            {
                yield return new WaitForSeconds(1.0f);
                timeRemaining-= 3;
            }
          
          
           
        }
    }


   public  IEnumerator FillRadialTimer()
    {
        while (timerPT.current < timerPT.max) // If the bar is not full
        {
            if(difficulty == 1)
            {
                timerIncrementSize = 2;
                timerPT.current += timerIncrementSize; // Then slowly fill the bar 
                yield return new WaitForSeconds(1.0f); // Adjusting increment size and the wait will affect how fast the bar fills 

            }
            else if(difficulty == 2)
            {
                timerIncrementSize = 3;
                timerPT.current += timerIncrementSize; // Then slowly fill the bar 
                yield return new WaitForSeconds(1.0f); // Adjusting increment size and the wait will affect how fast the bar fills 

            }
            else if(difficulty == 3)
            {
                timerIncrementSize = 3  ;
                timerPT.current += timerIncrementSize; // Then slowly fill the bar 
                yield return new WaitForSeconds(1.0f); // Adjusting increment size and the wait will affect how fast the bar fills 
            }

        }

    }
}
