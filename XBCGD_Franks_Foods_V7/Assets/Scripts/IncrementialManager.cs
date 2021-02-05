using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IncrementialManager : MonoBehaviour
{
    public AudioManager audioManagerObj;
    public Notifications notificationsObj;

    public GameObject incMenu;

    public Text totaMoneyTxt;
    
    public decimal totalMoney;

    // Hand Sanitiser Variables

    // Hand Sanitiser Variables

    public ProgressTracker handSanitiser;
    public ProgressTracker handSanitiserLevel;
    public ProgressTracker handSanitiserLevelCont;

    public Text handSanitiserTierTxt;
    public Text handSanitiserUpgradeBtnTxt;

    public Button handSanitiserBtn;
    public Button handSanitiserUpgradeBtn;

    int[] handSanitiserLevelCap = { 5, 10, 15, 20 };
    float[] handSanitiserIncrementSize = { 0.5f, 0.83f, 1.25f, 1.67f };

    decimal[] handSanitiserUpgradeCosts = { 0.15m, 0.3m, 0.45m };
    decimal handSanitiserProfit = 0.25m;

    int handSanitiserTier = 0;

    bool handSanitiserMaxTier = false;


    // Face Mask Variables

    public ProgressTracker faceMask;
    public ProgressTracker faceMaskLevel;
    public ProgressTracker faceMaskLevelCont;

    public Text faceMaskTierTxt;
    public Text faceMaskUpgradeBtnTxt;

    public Button faceMaskBtn;
    public Button faceMaskUpgradeBtn;

    int[] faceMaskLevelCap = { 5, 10, 15, 20 };
    float[] faceMaskIncrementSize = { 0.5f, 0.83f, 1.25f, 1.67f };

    decimal[] faceMaskUpgradeCosts = { 0.55m, 0.95m, 1.15m };
    decimal faceMaskProfit = 0.35m;

    int faceMaskTier = 0;

    bool faceMaskMaxTier = false;

    // Medicine Variables

    public ProgressTracker medicine;
    public ProgressTracker medicineLevel;
    public ProgressTracker medicineLevelCont;

    public Text medicineTierTxt;
    public Text medicineUpgradeBtnTxt;

    public Button medicineBtn;
    public Button medicineUpgradeBtn;

    int[] medicineLevelCap = { 5, 10, 15, 20 };
    float[] medicineIncrementSize = { 0.5f, 0.83f, 1.25f, 1.67f };

    decimal[] medicineUpgradeCosts = { 1.00m, 1.75m, 2.55m };
    decimal medicineProfit = 0.50m;

    int medicineTier = 0;

    bool medicineMaxTier = false;

    // Dog Food Variables

    public ProgressTracker dogFood;
    public ProgressTracker dogFoodLevel;
    public ProgressTracker dogFoodLevelCont;

    public Text dogFoodTierTxt;
    public Text dogFoodupgradeBtnTxt;

    public Button dogFoodBtn;
    public Button dogFoodUpgradeBtn;

    int[] dogFoodLevelCap = { 5, 10, 15, 20 };
    float[] dogFoodIncrementSize = { 0.5f, 0.83f, 1.25f, 1.67f };

    decimal[] dogFoodUpgradeCosts = { 3.00m, 3.50m, 4.00m };
    decimal dogFoodProfit = 0.75m;

    int dogFoodTier = 0;

    bool dogFoodMaxTier = false;

    // Gloves Variables

    public ProgressTracker gloves;
    public ProgressTracker glovesLevel;
    public ProgressTracker glovesLevelCont;

    public Text glovesTierTxt;
    public Text glovesupgradeBtnTxt;

    public Button glovesBtn;
    public Button glovesUpgradeBtn;

    int[] glovesLevelCap = { 5, 10, 15, 20 };
    float[] glovesIncrementSize = { 0.5f, 0.83f, 1.25f, 1.67f };

    decimal[] glovesUpgradeCosts = { 6.00m, 8.00m, 10.00m };
    decimal glovesProfit = 1.00m;

    int glovesTier = 0;

    bool glovesMaxTier = false;

    // Hazmat Suit Variables

    public ProgressTracker hazmatSuit;
    public ProgressTracker hazmatSuitLevel;
    public ProgressTracker hazmatSuitLevelCont;

    public Text hazmatSuitTierTxt;
    public Text hazmatSuitupgradeBtnTxt;

    public Button hazmatSuitBtn;
    public Button hazmatSuitUpgradeBtn;

    int[] hazmatSuitLevelCap = { 5, 10, 15, 20 };
    float[] hazmatSuitIncrementSize = { 0.5f, 0.83f, 1.25f, 1.67f };

    decimal[] hazmatSuitUpgradeCosts = { 12.00m, 15.00m, 20.00m };
    decimal hazmatSuitProfit = 1.5m;

    int hazmatSuitTier = 0;

    bool hazmatSuitMaxTier = false;

    private void Start()
    {
        handSanitiserUpgradeBtnTxt.text = "Upgrade $" + handSanitiserUpgradeCosts[handSanitiserTier];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            totalMoney += 50;
            totaMoneyTxt.text = "$"  + totalMoney;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            totalMoney += 450;
            totaMoneyTxt.text = "$" + totalMoney;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            totalMoney += 750;
            totaMoneyTxt.text = "$" + totalMoney;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            totalMoney = 0;
            totaMoneyTxt.text = "$" + totalMoney;
        }
    }


    // HAND SANITISER

    public void HandSanitiser() // On button click 
    {
        // Play Audio
        handSanitiserBtn.enabled = false; // Disable button to prevent spam clicking
        StartCoroutine(FillRadialBarHandSanitiser()); // Starts coroutine that fills the radial bar
    }

    IEnumerator FillRadialBarHandSanitiser()
    {
        while(handSanitiser.current < handSanitiser.max) // If the bar is not full
        {
            handSanitiser.current += handSanitiserIncrementSize[handSanitiserTier]; // Then slowly fill the bar 
            yield return new WaitForSeconds(0.025f); // Adjusting increment size and the wait will affect how fast the bar fills 
        }

        totalMoney += handSanitiserProfit; // Updates Total money after radial bar was filled        

        totaMoneyTxt.text = "$" + totalMoney; // Displays total Money 

        handSanitiserBtn.enabled = true; // Allows the button to be clicked again 
        handSanitiser.current = 0; // Resets the bar to empty        
    }
    
    public void HandSanitiserUpgrade() 
    {
        if (totalMoney >= handSanitiserUpgradeCosts[handSanitiserTier]) // If you have money for upgrade 
        {
            // Play Success Audio
            totalMoney -= handSanitiserUpgradeCosts[handSanitiserTier]; // Then subtract upgrade cost from total money

            totaMoneyTxt.text = "$" + totalMoney; // Display new total

            handSanitiserLevel.current++; // Increase handsanitisers level by 1

            if (handSanitiserLevel.current == handSanitiserLevelCap[handSanitiserTier]) // If you hit the level cap
            {
                handSanitiserLevel.min = handSanitiserLevelCap[handSanitiserTier]; // reset the bar
                handSanitiserLevel.max = handSanitiserLevelCap[handSanitiserTier + 1]; // upgrade the items tier
                handSanitiserTier++;

                if (handSanitiserTier == 3) // if at max tier
                {
                    audioManagerObj.Play("Max_Tier");
                    handSanitiserMaxTier = true;
                    handSanitiserTierTxt.text = "Max";
                    
                    StartCoroutine(AutomatedHandSanitiser()); // generate constant income 

                    handSanitiserUpgradeBtn.gameObject.SetActive(false);
                    handSanitiserLevelCont.gameObject.SetActive(false);
                }
                else
                {
                    handSanitiserUpgradeBtnTxt.text = "Upgrade $" + handSanitiserUpgradeCosts[handSanitiserTier];
                    handSanitiserTierTxt.text = (handSanitiserTier + 1).ToString();
                    handSanitiserProfit += 0.05m; // tier up, so give more money for making this item
                }                
            }
        }
        else
        {
            notificationsObj.DisplayDialogue("Insufficient Funds","That upgrade costs S" + handSanitiserUpgradeCosts[handSanitiserTier] + ". You'll need $" + (handSanitiserUpgradeCosts[handSanitiserTier] - totalMoney) + " more before you can afford it");
            
        }
    }

    IEnumerator AutomatedHandSanitiser()
    {
        while (handSanitiserMaxTier == true )
        {
            handSanitiserUpgradeBtn.gameObject.SetActive(false);
            handSanitiserBtn.enabled = false;
            totalMoney = totalMoney + handSanitiserProfit;
            totaMoneyTxt.text = "$" + totalMoney ;
            yield return new WaitForSeconds(1f);
        }        
    }
    

    // FACE MASK 

    public void FaceMask() // On button click 
    {
        // Play Audio
        faceMaskBtn.enabled = false; // Disable button to prevent spam clicking
        StartCoroutine(FillRadialBarFaceMask()); // Starts coroutine that fills the radial bar
    }

    IEnumerator FillRadialBarFaceMask()
    {
        while (faceMask.current < faceMask.max) // If the bar is not full
        {
            faceMask.current += faceMaskIncrementSize[faceMaskTier]; // Then slowly fill the bar 
            yield return new WaitForSeconds(0.025f); // Adjusting increment size and the wait will affect how fast the bar fills 
        }

        totalMoney += faceMaskProfit; // Updates Total money after radial bar was filled        

        totaMoneyTxt.text = "$" + totalMoney; // Displays total Money 

        faceMaskBtn.enabled = true; // Allows the button to be clicked again 
        faceMask.current = 0; // Resets the bar to empty        
    }

    public void FaceMaskUpgrade()
    {
        if (totalMoney >= faceMaskUpgradeCosts[faceMaskTier]) // If you have money for upgrade 
        {
            // Play Success Audio
            totalMoney -= faceMaskUpgradeCosts[faceMaskTier]; // Then subtract upgrade cost from total money

            totaMoneyTxt.text = "$" + totalMoney; // Display new total

            faceMaskLevel.current++; // Increase handsanitisers level by 1

            if (faceMaskLevel.current == faceMaskLevelCap[faceMaskTier]) // If you hit the level cap
            {
                faceMaskLevel.min = faceMaskLevelCap[faceMaskTier]; // reset the bar
                faceMaskLevel.max = faceMaskLevelCap[faceMaskTier + 1]; // upgrade the items tier
                faceMaskTier++;

                if (faceMaskTier == 3) // if at max tier
                {
                    audioManagerObj.Play("Max_Tier");
                    faceMaskMaxTier = true;
                    faceMaskTierTxt.text = "Max";

                    StartCoroutine(AutomatedFaceMask()); // generate constant income 

                    faceMaskUpgradeBtn.gameObject.SetActive(false);
                    faceMaskLevelCont.gameObject.SetActive(false);
                }
                else
                {
                    faceMaskUpgradeBtnTxt.text = "Upgrade $" + faceMaskUpgradeCosts[faceMaskTier];
                    faceMaskTierTxt.text = (faceMaskTier + 1).ToString();
                    faceMaskProfit += 0.05m; // tier up, so give more money for making this item
                }
            }
        }
        else
        {
            notificationsObj.DisplayDialogue("Insufficient Funds", "That upgrade costs S" + faceMaskUpgradeCosts[faceMaskTier] + ". You'll need $" + (faceMaskUpgradeCosts[faceMaskTier] - totalMoney) + " more before you can afford it");

        }
    }

    IEnumerator AutomatedFaceMask()
    {
        while (faceMaskMaxTier == true)
        {
            faceMaskUpgradeBtn.gameObject.SetActive(false);
            faceMaskBtn.enabled = false;
            totalMoney = totalMoney + faceMaskProfit;
            totaMoneyTxt.text = "$" + totalMoney;
            yield return new WaitForSeconds(1f);
        }
    }

    // MEDICINE

    public void Medicine() // On button click 
    {
        // Play Audio
        medicineBtn.enabled = false; // Disable button to prevent spam clicking
        StartCoroutine(FillRadialBarMedicine()); // Starts coroutine that fills the radial bar
    }

    IEnumerator FillRadialBarMedicine()
    {
        while (medicine.current < medicine.max) // If the bar is not full
        {
            medicine.current += medicineIncrementSize[medicineTier]; // Then slowly fill the bar 
            yield return new WaitForSeconds(0.025f); // Adjusting increment size and the wait will affect how fast the bar fills 
        }

        totalMoney += medicineProfit; // Updates Total money after radial bar was filled        

        totaMoneyTxt.text = "$" + totalMoney; // Displays total Money 

        medicineBtn.enabled = true; // Allows the button to be clicked again 
        medicine.current = 0; // Resets the bar to empty        
    }

    public void MedicineUpgrade()
    {
        if (totalMoney >= medicineUpgradeCosts[medicineTier]) // If you have money for upgrade 
        {
            // Play Success Audio
            totalMoney -= medicineUpgradeCosts[medicineTier]; // Then subtract upgrade cost from total money

            totaMoneyTxt.text = "$" + totalMoney; // Display new total

            medicineLevel.current++; // Increase handsanitisers level by 1

            if (medicineLevel.current == medicineLevelCap[medicineTier]) // If you hit the level cap
            {
                medicineLevel.min = medicineLevelCap[medicineTier]; // reset the bar
                medicineLevel.max = medicineLevelCap[medicineTier + 1]; // upgrade the items tier
                medicineTier++;

                if (medicineTier == 3) // if at max tier
                {
                    audioManagerObj.Play("Max_Tier");
                    medicineMaxTier = true;
                    medicineTierTxt.text = "Max";

                    StartCoroutine(AutomatedMedicine()); // generate constant income 

                    medicineUpgradeBtn.gameObject.SetActive(false);
                    medicineLevelCont.gameObject.SetActive(false);
                }
                else
                {
                    medicineUpgradeBtnTxt.text = "Upgrade $" + medicineUpgradeCosts[medicineTier];
                    medicineTierTxt.text = (medicineTier + 1).ToString();
                    medicineProfit += 0.05m; // tier up, so give more money for making this item
                }
            }
        }
        else
        {
            notificationsObj.DisplayDialogue("Insufficient Funds", "That upgrade costs S" + medicineUpgradeCosts[medicineTier] + ". You'll need $" + (medicineUpgradeCosts[medicineTier] - totalMoney) + " more before you can afford it");

        }
    }

    IEnumerator AutomatedMedicine()
    {
        while (medicineMaxTier == true)
        {
            medicineUpgradeBtn.gameObject.SetActive(false);
            medicineBtn.enabled = false;
            totalMoney = totalMoney + medicineProfit;
            totaMoneyTxt.text = "$" + totalMoney;
            yield return new WaitForSeconds(1f);
        }
    }

    // DOG FOOD 

    public void DogFood() // On button click 
    {
        // Play Audio
        dogFoodBtn.enabled = false; // Disable button to prevent spam clicking
        StartCoroutine(FillRadialBarDogFood()); // Starts coroutine that fills the radial bar
    }

    IEnumerator FillRadialBarDogFood()
    {
        while (dogFood.current < dogFood.max) // If the bar is not full
        {
            dogFood.current += dogFoodIncrementSize[dogFoodTier]; // Then slowly fill the bar 
            yield return new WaitForSeconds(0.025f); // Adjusting increment size and the wait will affect how fast the bar fills 
        }

        totalMoney += dogFoodProfit; // Updates Total money after radial bar was filled        

        totaMoneyTxt.text = "$" + totalMoney; // Displays total Money 

        dogFoodBtn.enabled = true; // Allows the button to be clicked again 
        dogFood.current = 0; // Resets the bar to empty        
    }

    public void DogFoodUpgrade()
    {
        if (totalMoney >= dogFoodUpgradeCosts[dogFoodTier]) // If you have money for upgrade 
        {
            // Play Success Audio
            totalMoney -= dogFoodUpgradeCosts[dogFoodTier]; // Then subtract upgrade cost from total money

            totaMoneyTxt.text = "$" + totalMoney; // Display new total

            dogFoodLevel.current++; // Increase dogFoods level by 1

            if (dogFoodLevel.current == dogFoodLevelCap[dogFoodTier]) // If you hit the level cap
            {
                dogFoodLevel.min = dogFoodLevelCap[dogFoodTier]; // reset the bar
                dogFoodLevel.max = dogFoodLevelCap[dogFoodTier + 1]; // upgrade the items tier
                dogFoodTier++;

                if (dogFoodTier == 3) // if at max tier
                {
                    audioManagerObj.Play("Max_Tier");
                    dogFoodMaxTier = true;
                    dogFoodTierTxt.text = "Max";

                    StartCoroutine(AutomatedDogFood()); // generate constant income 

                    dogFoodUpgradeBtn.gameObject.SetActive(false);
                    dogFoodLevelCont.gameObject.SetActive(false);
                }
                else
                {
                    dogFoodupgradeBtnTxt.text = "Upgrade $" + dogFoodUpgradeCosts[dogFoodTier];
                    dogFoodTierTxt.text = (dogFoodTier + 1).ToString();
                    dogFoodProfit += 0.05m; // tier up, so give more money for making this item
                }
            }
        }
        else
        {
            notificationsObj.DisplayDialogue("Insufficient Funds", "That upgrade costs S" + dogFoodUpgradeCosts[dogFoodTier] + ". You'll need $" + (dogFoodUpgradeCosts[dogFoodTier] - totalMoney) + " more before you can afford it");

        }
    }

    IEnumerator AutomatedDogFood()
    {
        while (dogFoodMaxTier == true)
        {
            dogFoodUpgradeBtn.gameObject.SetActive(false);
            dogFoodBtn.enabled = false;
            totalMoney = totalMoney + dogFoodProfit;
            totaMoneyTxt.text = "$" + totalMoney;
            yield return new WaitForSeconds(1f);
        }
    }

    // GLOVES

    public void Gloves() // On button click 
    {
        // Play Audio
        glovesBtn.enabled = false; // Disable button to prevent spam clicking
        StartCoroutine(FillRadialBarGloves()); // Starts coroutine that fills the radial bar
    }

    IEnumerator FillRadialBarGloves()
    {
        while (gloves.current < gloves.max) // If the bar is not full
        {
            gloves.current += glovesIncrementSize[glovesTier]; // Then slowly fill the bar 
            yield return new WaitForSeconds(0.025f); // Adjusting increment size and the wait will affect how fast the bar fills 
        }

        totalMoney += glovesProfit; // Updates Total money after radial bar was filled        

        totaMoneyTxt.text = "$" + totalMoney; // Displays total Money 

        glovesBtn.enabled = true; // Allows the button to be clicked again 
        gloves.current = 0; // Resets the bar to empty        
    }

    public void GlovesUpgrade()
    {
        if (totalMoney >= glovesUpgradeCosts[glovesTier]) // If you have money for upgrade 
        {
            // Play Success Audio
            totalMoney -= glovesUpgradeCosts[glovesTier]; // Then subtract upgrade cost from total money

            totaMoneyTxt.text = "$" + totalMoney; // Display new total

            glovesLevel.current++; // Increase glovess level by 1

            if (glovesLevel.current == glovesLevelCap[glovesTier]) // If you hit the level cap
            {
                glovesLevel.min = glovesLevelCap[glovesTier]; // reset the bar
                glovesLevel.max = glovesLevelCap[glovesTier + 1]; // upgrade the items tier
                glovesTier++;

                if (glovesTier == 3) // if at max tier
                {
                    audioManagerObj.Play("Max_Tier");
                    glovesMaxTier = true;
                    glovesTierTxt.text = "Max";

                    StartCoroutine(AutomatedGloves()); // generate constant income 

                    glovesUpgradeBtn.gameObject.SetActive(false);
                    glovesLevelCont.gameObject.SetActive(false);
                }
                else
                {
                    glovesupgradeBtnTxt.text = "Upgrade $" + glovesUpgradeCosts[glovesTier];
                    glovesTierTxt.text = (glovesTier + 1).ToString();
                    glovesProfit += 0.05m; // tier up, so give more money for making this item
                }
            }
        }
        else
        {
            notificationsObj.DisplayDialogue("Insufficient Funds", "That upgrade costs S" + glovesUpgradeCosts[glovesTier] + ". You'll need $" + (glovesUpgradeCosts[glovesTier] - totalMoney) + " more before you can afford it");

        }
    }

    IEnumerator AutomatedGloves()
    {
        while (glovesMaxTier == true)
        {
            glovesUpgradeBtn.gameObject.SetActive(false);
            glovesBtn.enabled = false;
            totalMoney = totalMoney + glovesProfit;
            totaMoneyTxt.text = "$" + totalMoney;
            yield return new WaitForSeconds(1f);
        }
    }

    // HAZMAT SUIT

    public void HazmatSuit() // On button click 
    {
        // Play Audio
        hazmatSuitBtn.enabled = false; // Disable button to prevent spam clicking
        StartCoroutine(FillRadialBarHazmatSuit()); // Starts coroutine that fills the radial bar
    }

    IEnumerator FillRadialBarHazmatSuit()
    {
        while (hazmatSuit.current < hazmatSuit.max) // If the bar is not full
        {
            hazmatSuit.current += hazmatSuitIncrementSize[hazmatSuitTier]; // Then slowly fill the bar 
            yield return new WaitForSeconds(0.025f); // Adjusting increment size and the wait will affect how fast the bar fills 
        }

        totalMoney += hazmatSuitProfit; // Updates Total money after radial bar was filled        

        totaMoneyTxt.text = "$" + totalMoney; // Displays total Money 

        hazmatSuitBtn.enabled = true; // Allows the button to be clicked again 
        hazmatSuit.current = 0; // Resets the bar to empty        
    }

    public void HazmatSuitUpgrade()
    {
        if (totalMoney >= hazmatSuitUpgradeCosts[hazmatSuitTier]) // If you have money for upgrade 
        {
            // Play Success Audio
            totalMoney -= hazmatSuitUpgradeCosts[hazmatSuitTier]; // Then subtract upgrade cost from total money

            totaMoneyTxt.text = "$" + totalMoney; // Display new total

            hazmatSuitLevel.current++; // Increase hazmatSuits level by 1

            if (hazmatSuitLevel.current == hazmatSuitLevelCap[hazmatSuitTier]) // If you hit the level cap
            {
                hazmatSuitLevel.min = hazmatSuitLevelCap[hazmatSuitTier]; // reset the bar
                hazmatSuitLevel.max = hazmatSuitLevelCap[hazmatSuitTier + 1]; // upgrade the items tier
                hazmatSuitTier++;

                if (hazmatSuitTier == 3) // if at max tier
                {
                    audioManagerObj.Play("Max_Tier");
                    hazmatSuitMaxTier = true;
                    hazmatSuitTierTxt.text = "Max";

                    StartCoroutine(AutomatedHazmatSuit()); // generate constant income 

                    hazmatSuitUpgradeBtn.gameObject.SetActive(false);
                    hazmatSuitLevelCont.gameObject.SetActive(false);
                }
                else
                {
                    hazmatSuitupgradeBtnTxt.text = "Upgrade $" + hazmatSuitUpgradeCosts[hazmatSuitTier];
                    hazmatSuitTierTxt.text = (hazmatSuitTier + 1).ToString();
                    hazmatSuitProfit += 0.05m; // tier up, so give more money for making this item
                }
            }
        }
        else
        {
            notificationsObj.DisplayDialogue("Insufficient Funds", "That upgrade costs S" + hazmatSuitUpgradeCosts[hazmatSuitTier] + ". You'll need $" + (hazmatSuitUpgradeCosts[hazmatSuitTier] - totalMoney) + " more before you can afford it");

        }
    }

    IEnumerator AutomatedHazmatSuit()
    {
        while (hazmatSuitMaxTier == true)
        {
            hazmatSuitUpgradeBtn.gameObject.SetActive(false);
            hazmatSuitBtn.enabled = false;
            totalMoney = totalMoney + hazmatSuitProfit;
            totaMoneyTxt.text = "$" + totalMoney;
            yield return new WaitForSeconds(1f);
        }
    }

    public void CloseIncBtn()
    {
        incMenu.SetActive(false);
    }
}
