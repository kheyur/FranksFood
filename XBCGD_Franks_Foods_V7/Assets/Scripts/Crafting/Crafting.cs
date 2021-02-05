using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public StockManager stockManagerObj;

    public IncrementialManager incrementialManagerObj;

    public GameObject playerOrder;
    public GameObject orderUI;
    public GameObject orderManagerUI;
    public GameObject playerOrderUI;
    public GameObject closePlayerOrderBtn;
    public GameObject creditsUi;
    

    public Text orderTxt;
    public Text profitTxt;
    public Text subheaderTxt;
    public Text resultsTxt;

    

    // Shared variables
    string orderID;

    int playerOrderTracker = 0;
    int score = 0;

    decimal orderCost = 0.00m;

    public bool craftingHandSanitiser = false;
    public bool craftingFaceMask = false;
    public bool craftingGloves = false;

    public bool currentlyCrafting = false;

    public string[] requestComponentOrder = new string[3];
    public string[] playerComponentOrder  = new string[3];

    // Hand Sanitiser 
    public GameObject[] bottles;
    public GameObject[] scents;
    public GameObject[] coloursHS;

    public string[] handSanitiserBottleOptions = { "Pump"   , "Spray"      , "Squeeze" };
    public string[] handSanitiserScentOptions  = { "Apple"  , "Watermelon" , "Lemon"   };
    public string[] handSanitiserColourOptions = { "Yellow" , "Green"      , "Red"     };    

    // Face Mask
    public GameObject[] straps;
    public GameObject[] filters;
    public GameObject[] coloursFM;

    public string[] faceMaskStrapOptions  = { "Basic"  , "Elastic", "Rubber" };
    public string[] faceMaskFilterOptions = { "Double" ,  "Single", "None"   };
    public string[] faceMaskColourOptions = { "Black"  ,    "Blue", "White"  };

    // Gloves
    public GameObject[] materials;
    public GameObject[] sizes;
    public GameObject[] coloursG;

    public string[] gloveMaterialOptions = { "Cotton" , "Plastic" , "Rubber" };
    public string[] gloveSizeOptions     = { "Large"  , "Medium"  , "Small"  };
    public string[] gloveColourOptions   = { "Cyan"   , "Lime"    , "Yellow" };

    private void Start()
    {

    }


    // Offers the player an order to craft and allows them to decline or accept it 
    public void OfferOrder()
    {
        int rng = 0;

        // if FM and G not avail then make HS
        if (stockManagerObj.faceMaskAvailable == false )
        {
            craftingHandSanitiser = true;
            craftingFaceMask = false;
            craftingGloves = false;

            subheaderTxt.text = " Order for Hand Sanitiser ";
        }

        // if FM avail and G not avail then rand F and HS
        if (stockManagerObj.faceMaskAvailable == true && stockManagerObj.glovesAvailable == false)
        {
            rng = Random.Range(0, 2);

            if (rng == 0)
            {
                craftingHandSanitiser = true;
                craftingFaceMask = false;
                craftingGloves = false;

                subheaderTxt.text = " Order for Hand Sanitiser ";
            }
            else if (rng == 1)
            {
                craftingHandSanitiser = false;
                craftingFaceMask = true;
                craftingGloves = false;

                subheaderTxt.text = " Order for a Face Mask ";
            }
        }

        // Fm and G avaial then random F G and HS 
        if (stockManagerObj.faceMaskAvailable == true && stockManagerObj.glovesAvailable == true)
        {
            rng = Random.Range(0, 2);

            if (rng == 0)
            {
                craftingHandSanitiser = true;
                craftingFaceMask = false;
                craftingGloves = false;

                subheaderTxt.text = " Order for Hand Sanitiser ";
            }
            else if (rng == 1)
            {
                craftingHandSanitiser = false;
                craftingFaceMask = true;
                craftingGloves = false;

                subheaderTxt.text = " Order for a Face Mask ";
            }
            else if (rng == 2)
            {
                craftingHandSanitiser = false;
                craftingFaceMask = false;
                craftingGloves = true;

                subheaderTxt.text = " Order for Gloves ";
            }
        }     

        GenerateOrderId();
        orderUI.SetActive(true);
        profitTxt.text = "$ " + orderCost;
    }    

    // Controls the sequence of components 
    public void GenerateOrderId()
    {
        int pos1 = Random.Range(0, 3);

        int pos2 = Random.Range(0, 3);

        if (pos2 == pos1)
        {
            while (pos2 == pos1)
            {
                pos2 = Random.Range(0, 3);
            }
        }

        int pos3 = Random.Range(0, 3);

        if (pos3 == pos1 || pos3 == pos2)
        {
            while (pos3 == pos1 || pos3 == pos2)
            {
                pos3 = Random.Range(0, 3);
            }
        }

        orderID = pos1 + "" + pos2 + "" + pos3;

        if (craftingHandSanitiser == true)
        {
            GenerateOrder(orderID, handSanitiserBottleOptions, handSanitiserScentOptions, handSanitiserColourOptions);
        }
        else if (craftingFaceMask  == true)
        {
            GenerateOrder(orderID, faceMaskStrapOptions, faceMaskFilterOptions, faceMaskColourOptions);
        }
        else
        {
            GenerateOrder(orderID, gloveMaterialOptions, gloveSizeOptions, gloveColourOptions);
        }        
    }    

    public void GenerateOrder(string orderID, string[] first, string[] second, string[] third)
    {
        int rng1 = Random.Range(0, 3);
        string temp1 = first[rng1];

        for (int i = 0; i < orderID.Length; i++)
        {
            if (orderID[i] == '0')
            {
                requestComponentOrder[i] = temp1;
            }
        }

        int rng2 = Random.Range(0, 3);
        string temp2 = second[rng2];

        for (int i = 0; i < orderID.Length; i++)
        {
            if (orderID[i] == '1')
            {
                requestComponentOrder[i] = temp2;
            }
        }

        int rng3 = Random.Range(0, 3);
        string temp3 = third[rng3];

        for (int i = 0; i < orderID.Length; i++)
        {
            if (orderID[i] == '2')
            {
                requestComponentOrder[i] = temp3;
            }
        }

        if (craftingHandSanitiser == true)
        {
            orderCost = stockManagerObj.HandSanitiserPrice(rng1, rng2, rng3);


            StructureOrderHandSanitiser(handSanitiserBottleOptions, handSanitiserScentOptions, handSanitiserColourOptions);

        }
        else if (craftingFaceMask == true)
        {
            orderCost = stockManagerObj.FaceMaskPrice(rng1, rng2, rng3);


            StructureOrderFaceMask(faceMaskStrapOptions, faceMaskFilterOptions, faceMaskColourOptions);

        }
        else if (craftingGloves == true)
        {
            orderCost = stockManagerObj.GlovesPrice(rng1, rng2, rng3);


            StructureOrderGloves(gloveMaterialOptions, gloveSizeOptions, gloveColourOptions);

        }


      
    }

    public void PlayerOrder(string componentName)
    {
        for (int i = 0; i < 3; i++)
        {
            if (playerComponentOrder[i] == componentName)
            {
                Debug.Log("Cant pick the same component twice");
                break;
            }
        }

        if (playerOrderTracker < 3)
        {
            playerComponentOrder[playerOrderTracker] = componentName;
            for (int i = 0; i < 3; i++)
            {
                // For HandSanitisers
                if (componentName == bottles[i].name)
                {
                    bottles[i].SetActive(true);
                    break;
                }
                if (componentName == coloursHS[i].name)
                {
                    coloursHS[i].SetActive(true);
                    break;
                }
                if (componentName == scents[i].name)
                {
                    scents[i].SetActive(true);
                    break;
                }

                // For Gloves
                if (componentName == materials[i].name)
                {
                    materials[i].SetActive(true);
                    break;
                }
                if (componentName == sizes[i].name)
                {
                    sizes[i].SetActive(true);
                    break;
                }
                if (componentName == coloursG[i].name)
                {
                    coloursG[i].SetActive(true);
                    break;
                }

                // For Face Mask
                if (componentName == straps[i].name)
                {
                    straps[i].SetActive(true);
                    break;
                }
                if (componentName == filters[i].name)
                {
                    filters[i].SetActive(true);
                    break;
                }
                if (componentName == coloursFM[i].name)
                {
                    coloursFM[i].SetActive(true);
                    break;
                }                
}
            playerOrderTracker++;
        }

        if (playerOrderTracker == 3)
        {
            CompareOrders();
        }
    }

    public void CompareOrders()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // If the selected component exists in the sequence, then inc score 
                if (playerComponentOrder[i] == requestComponentOrder[j])
                {
                    score++;
                    // If the component in the player's Sequence matches that of the Order sequence, then inc score
                    if (i == j)
                    {
                        score++;
                    }
                }
            }
        }       

        Debug.Log("Score: " + score);
        CalcProfit();

        closePlayerOrderBtn.SetActive(true);
        Reset();
    }

    public void CloseOrderBtn()
    {
        playerOrder.SetActive(false);
    }

    public void Reset()
    {
        orderID = "";

        playerOrderTracker = 0;
        score = 0;
        orderCost = 0.00m;

        craftingHandSanitiser = false;
        craftingFaceMask = false;
        craftingGloves = false;

        currentlyCrafting = false;
        
        for (int i = 0; i < 3; i++)
        {
            requestComponentOrder[i] = "";
            requestComponentOrder[i] = "";
        }
    }

    // Open Close Menus
    public void OpenOrdermanagerUI()
    {
        orderManagerUI.SetActive(true);
    }

    public void CloseOrdermanagerUI()
    {
        orderManagerUI.SetActive(false);
    }

    // Accept or Decline
    public void OrderAccepted()
    {
        currentlyCrafting = true;
        playerOrderUI.SetActive(true);
        closePlayerOrderBtn.SetActive(false);
        orderUI.SetActive(false);
    }

    public void OrderDeclined()
    {
        orderUI.SetActive(false);
    }

    public void HidePlayerOrder()
    {
        playerOrder.SetActive(false);
        resultsTxt.text = "Still Crafting";

        // hide currently active icons
        for (int i = 0; i < 3; i++)
        {
            bottles[i].SetActive(false);
            scents[i].SetActive(false);
            coloursHS[i].SetActive(false);
            materials[i].SetActive(false);
            filters[i].SetActive(false);
            coloursFM[i].SetActive(false);
            materials[i].SetActive(false);
            sizes[i].SetActive(false);
            coloursG[i].SetActive(false);
        }
    }

    public void CalcProfit()
    {
      

        decimal profit = orderCost - (6 - score) * (0.20m * orderCost);

        if (profit > 0)
        {
            resultsTxt.text = "Profit of $" + profit;
            incrementialManagerObj.totalMoney += profit;
        }
        else if (profit < 0)
        {
            resultsTxt.text = "In the Red. Lost $" + profit * (-1);
            incrementialManagerObj.totalMoney -= profit;
        }
        else
        {
            resultsTxt.text = "Broke Even. No Profit";
        }
    }

    public void StructureOrderHandSanitiser(string[] bottles, string[] scents, string[] colours)
    {
        int bottlePos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == bottles[i])
            {
                bottlePos = 0;
                Debug.Log("Bottle first ");
                break;
            }
            if (requestComponentOrder[1] == bottles[i])
            {
                bottlePos = 1;
                Debug.Log("Bottle second ");
                break;
            }
            if (requestComponentOrder[2] == bottles[i])
            {
                bottlePos = 2;
                Debug.Log("Bottle third ");
                break;
            }
        }

        int scentPos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == scents[i])
            {
                scentPos = 0;
                Debug.Log("Scent first ");
                break;
            }
            if (requestComponentOrder[1] == scents[i])
            {
                scentPos = 1;
                Debug.Log("Scent second ");
                break;
            }
            if (requestComponentOrder[2] == scents[i])
            {
                scentPos = 2;
                Debug.Log("Scent third ");
                break;
            }
        }

        int colourPos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == colours[i])
            {
                colourPos = 0;
                Debug.Log("Colour first ");
                break;
            }
            if (requestComponentOrder[1] == colours[i])
            {
                colourPos = 1;
                Debug.Log("Colour second ");
                break;
            }
            if (requestComponentOrder[2] == colours[i])
            {
                colourPos = 2;
                Debug.Log("Colour third ");
                break;
            }
        }

        string output = "";

        //p/sp/sq

        if (requestComponentOrder[bottlePos] == "Pump")
        {
            output = "I find it a bit hard to use Spray and Squeeze bottles. " + "/n";
        }
        else if (requestComponentOrder[bottlePos] == "Spray")
        {
            output = "I find it a bit hard to use Pump and Squeeze bottles. " + "/n";
        }
        else if (requestComponentOrder[bottlePos] == "Squeeze")
        {
            output = "My 3 year old finds it hard to press down on the bottle " + "/n";
        }

        //a/w/l

        if (requestComponentOrder[scentPos] == "Apple")
        {
            output += "I allergic to watermelon and lemon. " + "/n";
        }
        else if (requestComponentOrder[scentPos] == "Watermelon")
        {
            output += "I really dont like the smell of apples and lemon.  " + "/n";
        }
        else if (requestComponentOrder[scentPos] == "Lemon")
        {
            output += "I love the smell of citrus.  " + "/n";
        }

        //y/g/r

        if (requestComponentOrder[colourPos] == "Yellow")
        {
            output += "Please dont make it green or red! " + "/n";
        }
        else if (requestComponentOrder[colourPos] == "Green")
        {
            output += "Please dont make it yellow or red!   " + "/n";
        }
        else if (requestComponentOrder[colourPos] == "Red")
        {
            output += "Please dont make it yellow or green!   " + "/n";
        }

        orderTxt.text = output;

    }

    public void StructureOrderFaceMask(string[] straps, string[] filters, string[] colours)
    {
        int strapPos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == straps[i])
            {
                strapPos = 0;
                break;
            }
            if (requestComponentOrder[1] == straps[i])
            {
                strapPos = 1;
                break;
            }
            if (requestComponentOrder[2] == straps[i])
            {
                strapPos = 2;
                break;
            }
        }

        int filterPos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == filters[i])
            {
                filterPos = 0;
                break;
            }
            if (requestComponentOrder[1] == filters[i])
            {
                filterPos = 1;
                break;
            }
            if (requestComponentOrder[2] == filters[i])
            {
                filterPos = 2;
                break;
            }
        }

        int colourPos = 0;

        for (int i = 0; i < 3; i++)
        {
            if (requestComponentOrder[0] == colours[i])
            {
                colourPos = 0;
                break;
            }
            if (requestComponentOrder[1] == colours[i])
            {
                colourPos = 1;
                break;
            }
            if (requestComponentOrder[2] == colours[i])
            {
                colourPos = 2;
                break;
            }
        }

        string output = "";

        if (requestComponentOrder[strapPos] == "Basic")
        {
            output = "Keep the strap nice and simple. " + "/n";
        }
        else if (requestComponentOrder[strapPos] == "Elastic")
        {
            output = "My head is pretty big, the strap needs to be stretchy! " + "/n";
        }
        else if (requestComponentOrder[strapPos] == "Rubber")
        {
            output = "I need a strap with a little more grip. " + "/n";
        }

        //a/w/l

        if (requestComponentOrder[filterPos] == "Double")
        {
            output += "Its a little hard to breath. More filters would be nice. " + "/n";
        }
        else if (requestComponentOrder[filterPos] == "Single")
        {
            output += "For filters 2 is a crowd and None is a little sad. " + "/n";
        }
        else if (requestComponentOrder[filterPos] == "None")
        {
            output += "I can breath fine without 1 or 2 filters. " + "/n";
        }

        //y/g/r

        if (requestComponentOrder[colourPos] == "Black")
        {
            output += "Hows about a colour that wont stain easy. " + "/n";
        }
        else if (requestComponentOrder[colourPos] == "Blue")
        {
            output += "As for colour, anythign that isnt black or white. " + "/n";
        }
        else if (requestComponentOrder[colourPos] == "White")
        {
            output += "i dont want the colour to be very dark. " + "/n";
        }

        Debug.Log(output);

    }

    public void StructureOrderGloves(string[] materials, string[] sizes, string[] colours)
    {
        int materialPos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == materials[i])
            {
                materialPos = 0;
                break;
            }
            if (requestComponentOrder[1] == materials[i])
            {
                materialPos = 1;
                break;
            }
            if (requestComponentOrder[2] == materials[i])
            {
                materialPos = 2;
                break;
            }
        }

        int sizePos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == sizes[i])
            {
                sizePos = 0;
                break;
            }
            if (requestComponentOrder[1] == sizes[i])
            {
                sizePos = 1;
                break;
            }
            if (requestComponentOrder[2] == sizes[i])
            {
                sizePos = 2;
                break;
            }
        }

        int colourPos = 0;

        for (int i = 0; i < 3; i++)
        {
            //checks if the comp in pos 1 is in the bottle array 
            if (requestComponentOrder[0] == colours[i])
            {
                colourPos = 0;
                break;
            }
            if (requestComponentOrder[1] == colours[i])
            {
                colourPos = 1;
                break;
            }
            if (requestComponentOrder[2] == colours[i])
            {
                colourPos = 2;
                break;
            }
        }

        string output = "";

        //p/sp/sq

        if (requestComponentOrder[materialPos] == "Cotton")
        {
            output = "Cotton gloves would help me stay warm. " + "/n";
        }
        else if (requestComponentOrder[materialPos] == "Plastic")
        {
            output = "Rubber would be nice. But i prefer Plastic. " + "/n";
        }
        else if (requestComponentOrder[materialPos] == "Rubber")
        {
            output = "An anti-slip material would be nice. " + "/n";
        }

        //a/w/l

        if (requestComponentOrder[sizePos] == "Large")
        {
            output += "Give me your biggest! " + "/n";
        }
        else if (requestComponentOrder[sizePos] == "Medium")
        {
            output += "Im not sure about size, give me a Medium? " + "/n";
        }
        else if (requestComponentOrder[sizePos] == "Small")
        {
            output += "I need these for my 4 year old. " + "/n";
        }

        //y/g/r

        if (requestComponentOrder[colourPos] == "Cyan")
        {
            output += "Please dont make then Lime or Yellow" + "/n";
        }
        else if (requestComponentOrder[colourPos] == "Lime")
        {
            output += "Something Greenish would be nice " + "/n";
        }
        else if (requestComponentOrder[colourPos] == "Yellow")
        {
            output += "Can you make them look like kitchen gloves " + "/n";
        }

        Debug.Log(output);

    }

    public void OpenCreditsBtn()
    {
        creditsUi.SetActive(true);
    }

    public void CloseCreditsBtn()
    {
        creditsUi.SetActive(false);
    }

   
}

