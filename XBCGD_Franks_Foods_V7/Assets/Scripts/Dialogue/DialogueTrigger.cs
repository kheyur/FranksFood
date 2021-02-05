using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    //Handles when the dialogue needs to be shown.

    public Dialogue dialogue;   

    //Incremential manager stuff
    public Text moneyTxt;
    public IncrementialManager incMan;

    public StockManager stocks;

    //CAMERA
    public CameraManager camMan;
    public CameraControllerX camX;
    public CameraControllerY camY;

    public GameObject Camera;
    

    public Queue<string> dialogues;

    //GAMEOBJECTS
    public GameObject medicineBtn;
    public GameObject dogFoodBtn;
    public GameObject glovesBtn;
    public GameObject hazmatBtn;
    public GameObject startHelp;

    public GameObject fisherChar;
    public GameObject spcaChar;
    public GameObject inspChar;
    public GameObject frankChar;


    //SPRITES 
    public Sprite frankImg;
    public Sprite mcImg;
    public Sprite inspImg;
    public Sprite fishImg;
    public Sprite vetImg;
    public Sprite noImg;
    public Image blankImg;

    public GameObject dialogueBox;
    public GameObject finalDialogue;
   

    //TEXTS
    public Text dialogueTxt;
    public Text charNameTxt;

    //BOOLS
    public bool dialogueOn = false;
    public bool isDone = false;

    public int counter;

    private void Start()
    {
        counter = 0;
        stocks.faceMaskAvailable = true;
    }

    //Checks to see if different thresholds are met. When they are, it triggers the specific dialogue.
    public void Update()
    {
       
      //Test
        //if(incMan.totalMoney == 9000)
    //    {
     //       dialogueOn = true;
      //      dialogueBox.SetActive(true);
       ///     counter += 1;
       //     NextBtn();
      //      incMan.totalMoney = 9001;
   //     }

        //1st Threshold
        if(incMan.totalMoney >= 50 && incMan.totalMoney < 100)
        {
            if(counter == 0)
            {
                dialogueOn = true;
                counter += 1;
                NextBtn();

                
                camMan.canMove = false;
                camY.canMove = false;
                camX.canMove = false;
                frankChar.SetActive(true);

                Camera.gameObject.transform.rotation = new Quaternion(0f, -90, 0, 100);
                Camera.transform.position = new Vector3(7.48f, 2.44f, -3.4f);

                dialogueBox.SetActive(true);
            }
           

        }

        //2nd Threshold
        if(incMan.totalMoney >= 250 && incMan.totalMoney < 300)
        {
            if(counter == 11)
            {
                dialogueOn = true;
                counter += 1;
                NextBtn();

                camMan.canMove = false;
                camY.canMove = false;
                camX.canMove = false;

                spcaChar.SetActive(true);

                Camera.gameObject.transform.rotation = new Quaternion(0f, -90, 0, 100);
                Camera.transform.position = new Vector3(7.48f, 2.44f, -3.4f);

                dialogueBox.SetActive(true);
            }
            
        }

        //3rd Threshold
        if (incMan.totalMoney >= 500 && incMan.totalMoney < 550)
        {
            if (counter == 25)
            {
                dialogueOn = true;
                counter += 1;
                NextBtn();

                camMan.canMove = false;
                camY.canMove = false;
                camX.canMove = false;

                Camera.gameObject.transform.rotation = new Quaternion(0f, -90, 0, 100);
                Camera.transform.position = new Vector3(7.48f, 2.44f, -3.4f);

                dialogueBox.SetActive(true);
            }

        }

        //4th Threshold 
        if (incMan.totalMoney >= 750 && incMan.totalMoney < 800)
        {
            if (counter == 49)
            {
                dialogueOn = true;
                counter += 1;
                NextBtn();

                camMan.canMove = false;
                camY.canMove = false;
                camX.canMove = false;

                Camera.gameObject.transform.rotation = new Quaternion(0f, -90, 0, 100);
                Camera.transform.position = new Vector3(7.48f, 2.44f, -3.4f);

                dialogueBox.SetActive(true);
            }

        }

        //Final Threshold
       if(incMan.totalMoney >= 1000)
        {
            if(counter == 75)
            {
                counter += 1;
                NextBtn();
            }
        }


    }

    public void NextBtn()
    {
        //1st Threshold
        if (counter == 1)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "I noticed you've been coughing lately. Stop it. You're scaring customers away";
            counter++;

        }
        else if (counter == 2)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "I can't help it boss! It just doesn't seem to go away. I don't know what to do...";
            counter++;
        }
        else if (counter == 3)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "Well we can't be having that! You're my ONLY employee! I NEED YOU TO KEEP THIS PLACE RUNNING FOR ME!!!";
            counter++;
        }
        else if (counter == 4)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Well I can't afford * Cough * to go to the hospital now, the bills are too high.";
            counter++;
        }
        else if (counter == 5)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Things are getting rough at home, there's no way I could afford any treatment or medication.";
            counter++;
        }
        else if (counter == 6)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "WORRY NOT MY TALL FRIEND! I have just what you need. I just started bringing in some new untested prototype pioneer medication! ";
            counter++;
        }
        else if (counter == 7)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "You can be the first to try! Its the perfect way to see whether or not these babies are ready to hit the market!";
            counter++;
        }
        else if (counter == 8)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Jeez boss, that sounds like a * Cough * terrible idea. There's no way this is legal or safe for me or anyone honestly!";

            counter++;
        }
        else if (counter == 9)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "NO NO NO NO! Worry not my giant companion, it will all be okay! Here, take this! ";
            counter++;
        }
        else if (counter == 10)
        {
            blankImg.sprite = noImg;
            charNameTxt.text = " ";
            dialogueTxt.text = "You can now start selling medicine from the Item Sale menu! ";
            counter++;
        }
        else if (counter == 11)
        {
            camMan.canMove = true;
            camY.canMove = true;
            camX.canMove = true;

            frankChar.SetActive(false);
            medicineBtn.SetActive(true);
            dialogueBox.gameObject.SetActive(false);

            Camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            Camera.gameObject.transform.position = new Vector3(0, 4, -12.7f);
        }
        
        //2nd Threshold
        if(counter == 12)
        {
            blankImg.sprite = vetImg;
            charNameTxt.text = "SPCA Worker";
            dialogueTxt.text = "Oh hello there! Thank god you guys are open! ";
            counter++;
        }
        else if(counter == 13)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Ah yes of course! Welcome to Frank's Foo - SORRY I mean welcome to Frank's PPE's! What can I help you with?";

            counter++;
        }
        else if(counter == 14)
        {
            blankImg.sprite = vetImg;
            charNameTxt.text = "SPCA Worker";
            dialogueTxt.text = "Yes please. I would like to order 3 bags of chicken flavoured dog food, 2 bags of beef jerky fla- ";
            counter++;
        }
        else if (counter == 15)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Dog food? * Cough * I'm sorry, you must be at the wrong place. We only sell PPE's here! I do know a good place that sells do-";

            counter++;
        }
        else if (counter == 16)
        {
            frankChar.SetActive(true);
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "AH YES HELLO THERE DEAR CUSTOMER WE DO INDEED SELL DOG FOOD!";
            counter++;
        }
        else if (counter == 17)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Huh? But- ";

            counter++;
        }
        else if (counter == 18)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "AND GUESS WHAT? IT JUST SO HAPPENS THAT OUR ORDER CAME IN TODAY! WE HAVE EXACTLY WHAT YOU NEED! DON'T WORRY ABOUT ANY OTHER COMPETITORS HAHAHAHA!";
            counter++;
        }
        else if (counter == 19)
        {
            blankImg.sprite = vetImg;
            charNameTxt.text = "SPCA Worker";
            dialogueTxt.text = "Oh goody! How lucky! We're constantly running out of food for the pooches!";
            counter++;
        }
        else if (counter == 20)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "WORRY NOT MY ANIMAL-LOVING FRIEND! HERE YOU GO! WE'LL ALWAYS HAVE SOME STOCK FOR YOU SO DON'T HESITATE TO COME BACK!";
            counter++;
        }
        else if (counter == 21)
        {
            blankImg.sprite = vetImg;
            charNameTxt.text = "SPCA Worker";
            dialogueTxt.text = "Not a chance! I'll see you again soon! I can finally keep all the puppies well fed!";
            counter++;
        }
        else if (counter == 22)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "I'LL BE SEEING YOU SOON! sucker!";
            counter++;
        }
        else if (counter == 23)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "* Cough * Well, here we go again...";

            counter++;
        }
        else if (counter == 24)
        {
            blankImg.sprite = noImg;
            charNameTxt.text = " ";
            dialogueTxt.text = "Congratulations! You can now start selling dog food from the Item Sale menu! Keep earning money through crafting via the desktop in the management room and selling items in the Item Menu.";
            counter++;
        }
        else if (counter == 25)
        {

            camMan.canMove = true;
            camY.canMove = true;
            camX.canMove = true;

            frankChar.SetActive(false);
            spcaChar.SetActive(false);
            dogFoodBtn.SetActive(true);
            dialogueBox.gameObject.SetActive(false);


            Camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            Camera.gameObject.transform.position = new Vector3(0, 4, -12.7f);
        }

        //3RD THRESHOLD
        if(counter == 26)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "I wonder what kind of customers we'll get today. * Cough * Hopefully not anyone as that SPCA guy with the d-";
            counter++;
        }
        else if(counter == 27)
        {
            fisherChar.SetActive(true);
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "AHOY THERE! Young lad, you have to help me! Ever since the pandemic hit with the lockdown I've been out of a job and now I'm struggling to feed my family.";
            counter++;
        }
       else if (counter == 28)
       {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "*Sigh* Never a normal day at this place... But yes, what can I help you with?";
            counter++;
       }
        else if (counter == 29)
        {
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "You see, being jobless has made it impossible for me to support my family every day. Things have been going downhill, but just recently I got a new job offer at the local power plant!";
            counter++;
        }
        else if (counter == 30)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Oh... well that is actually great news! Congratulations!";
            counter++;
        }
        else if (counter == 31)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "I'm not too sure about how that involves me though.";
            counter++;
        }
        else if (counter == 32)
        {
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "You see, the inspector won't let me get the job if I don't have the right equipment. They're saying something about issues with radiaton and something about a recent leak.";
            counter++;
        }
        else if (counter == 33)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Oh my, that does seem like quite the situation Mr. Fisherman.";
            counter++;
        }
        else if (counter == 34)
        {
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "Please, call me Local. Mr. Fisherman was my father.";
            counter++;
        }
        else if (counter == 35)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "You know what? I don't think I will! ";
            counter++;
        }
        else if (counter == 36)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Back to the topic at hand though, * Cough * you still haven't told me what we can help with. ";
            counter++;
        }
        else if (counter == 37)
        {
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "You see, I'm required to purchase protective gloves to wear at work, but all the local shops are either charging too much or have closed down!";
            counter++;
        }
        else if (counter == 38)
        {
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "You see, I hear this place sells PPEs, so I figured I should try and see if I could get a pair from here.";
            counter++;
        }
        else if (counter == 39)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Ah, I'm sorry to have to do this but we - ";
            counter++;
        }
        else if (counter == 40)
        {
            frankChar.SetActive(true);
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "HAVE ALL THE STOCK THAT YOU NEED! GLOVES? WE GOT 'EM!";
            counter++;
        }
        else if (counter == 41)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = " * Cough * Frank. This * Cough * needs to stop.";
            counter++;
        }
        else if (counter == 42)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "WORRY NOT, FRIEND. LET ME KNOW WHAT EXACTLY YOU'RE LOOKING FOR!";
            counter++;
        }
        else if (counter == 43)
        {
            blankImg.sprite = fishImg;
            charNameTxt.text = "Local Fisherman";
            dialogueTxt.text = "I knew it was a good idea to come here! They say that I need to have rubber gloves to work with the material.";
            counter++;
        }
        else if (counter == 44)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "* Cough * Wait that doesn't actually sound that safe to be comple-";
            counter++;
        }
        else if (counter == 45)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "YES LET ME SHOW YOU WHAT WE HAVE IN STOCK RIGHT NOW!";
            counter++;
        }
        else if (counter == 46)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "However, if you're looking for anything specific, contact this number. Tell your friends but just don't let the Inspector hear about this.";
            counter++;
        }
        else if (counter == 47)
        {
            blankImg.sprite = noImg;
            charNameTxt.text = " ";
            dialogueTxt.text = "Congratulations! You can now start selling gloves from the Item Menu!";
            counter++;
        }
        else if (counter == 48)
        {
            blankImg.sprite = noImg;
            charNameTxt.text = " ";
            dialogueTxt.text = "You can also start crafting specific orders for gloves! Find the orders at the Order Manager on your desktop in the management room!";
            counter++;
        }
        else if (counter == 49)
        {
            camMan.canMove = true;
            camY.canMove = true;
            camX.canMove = true;

            frankChar.SetActive(false);
            fisherChar.SetActive(false);

            glovesBtn.SetActive(true);
            stocks.glovesAvailable = true;
            dialogueBox.gameObject.SetActive(false);


            Camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            Camera.gameObject.transform.position = new Vector3(0, 4, -12.7f);
        }

        //4TH THRESHOLD

        if(counter == 50)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "* Cough * * Cough * Sweet Pete, my throat is really killing me, and this cough just hasn't seemed to let up yet.";
           counter++;
        }
        else if (counter == 51)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Frank has me working this store * Cough * 24/7,  I just can't * Cough * catch a break...";
            counter++;
        }
        else if (counter == 52)
        {
            inspChar.SetActive(true);
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "It seems like your streak of bad luck isn't ending anytime soon, young man. ";
            counter++;
        }
        else if (counter == 53)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "Oh wha- Idon'tknowwhatyou're * Cough * talkingaboutwearen'tdoinganythingsuspiciousatall * Cough * ";
            counter++;
        }
        else if (counter == 54)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "Relax, kid. I'm not here on business today so I don't care about any funny business. ";
            counter++;
        }
        else if (counter == 55)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "You know that * Cough * almost makes sense. How does you being * Cough * off-duty prevent you from shuttin-";
            counter++;
        }
        else if(counter == 56)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "That cough is sounding quite serious. You might want to go get that checked out. ";
            counter++;
        }
        else if (counter == 57)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "I just don't have the funds to * Cough * get any medical attention. My main priority * Cough * is just trying to stay afloat.";
            counter++;
        }
        else if (counter == 58)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "But you've been working your butt off every day? You should get out before it's too late... ";
            counter++;
        }
        else if (counter == 59)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "...";
            counter++;
        }
        else if (counter == 60)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "...";
            counter++;
        }
        else if (counter == 61)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "...";
            counter++;
        }
        else if (counter == 62)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "So did you * Cough * come here to give me * Cough * life advice or did you need anything?";
            counter++;
        }
        else if (counter == 63)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "Ah yes, things at the power plant have taken a turn for the worse. Unfortunately, this means that we're required to start implementing hazmat suits in public.";
            counter++;
        }
        else if (counter == 64)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "The plant doesn't allow the workers to take their work hazmat suits home, so everyone has been rushing to buy their own ones.";
            counter++;
        }
        else if (counter == 65)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "I decided to come here to try to get my own one before stocks start running low. Before long, everyone is going to need one, even you.";
            counter++;
        }
        else if (counter == 66)
        {
            blankImg.sprite = mcImg;
            charNameTxt.text = "Player";
            dialogueTxt.text = "* Cough * Oh. Well, we don't normally sell those, * Cough * but I imagine Frank already -";
            counter++;
        }
        else if (counter == 67)
        {
            frankChar.SetActive(true);
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "has several in stock. Fancy seeing you here, Inspector.";
            counter++;
        }
        else if (counter == 68)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "Hello there, Frank. I'm just here for a hazmat suit.";
            counter++;
        }
        else if (counter == 69)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "Of course. We have one just in your size.";
            counter++;
        }
        else if (counter == 70)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "Here you go. Now just pay up and be gone. Thank you for your business.";
            counter++;
        }
        else if (counter == 71)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "Thank you, Frank. Take care.";
            counter++;
        }
        else if (counter == 72)
        {
            blankImg.sprite = inspImg;
            charNameTxt.text = "Inspector";
            dialogueTxt.text = "And give your employee here a break or a higher pay. My next visit wont be a pleasant one.";
            counter++;
        }
        else if (counter == 73)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "You just worry about yourself.";
            counter++;
        }
        else if (counter == 73)
        {
            blankImg.sprite = frankImg;
            charNameTxt.text = "Frank";
            dialogueTxt.text = "Now that she is gone, let us begin on our venture into the world of hazmat suits!";
            counter++;
        }
        else if (counter == 74)
        {
            blankImg.sprite = noImg;
            charNameTxt.text = " ";
            dialogueTxt.text = "Congratulations! You can now start selling hazmat suits from the Item Menu!";
            counter++;
        }
      else if (counter == 75)
      {
            camMan.canMove = true;
            camY.canMove = true;
            camX.canMove = true;

            frankChar.SetActive(false);
            inspChar.SetActive(false);
            glovesBtn.SetActive(true);
            stocks.glovesAvailable = true;
            dialogueBox.gameObject.SetActive(false);

            Camera.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            Camera.gameObject.transform.position = new Vector3(0, 4, -12.7f);
        }

        if(counter == 76)
        {
            finalDialogue.gameObject.SetActive(true);
        }

    }
 
    public void CloseStartMenu()
    {
        startHelp.SetActive(false);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void TriggerDialogue(Dialogue tempDiag)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(tempDiag);
        isDone = true;

    }
}
