using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockManager : MonoBehaviour
{
    // Gameobjects 
    public GameObject handSanitiserBtn;
    public GameObject handSanitiserTile;

    public GameObject faceMaskBtn;
    public GameObject faceMaskTile;

    public GameObject glovesBtn;
    public GameObject glovesTile;

    public GameObject window;

    public GameObject[] handSanitiserComponents;
    public GameObject[] faceMaskComponents;
    public GameObject[] gloveComponents;

 

    // Controls whether FM and G are available to craft 
    public bool faceMaskAvailable = false;
    public bool glovesAvailable = false;


    //  //  // HANDSANITISER    //  //  //

    // Handsanitiser Bottle
    public Text pumpBottlePriceText;
    public Text sprayBottlePriceText;
    public Text squeezeBottlePriceText;

    // Handsanitiser Colour
    public Text yellowPriceText;
    public Text greenPriceText;
    public Text redPriceText;

    // Handsanitiser Scent
    public Text applePriceText;
    public Text watermelonPriceText;
    public Text lemonPriceText;

    // Handsanitiser Prices 
    public decimal[] bottlePrices = { 6.00m, 6.00m, 6.00m };
    public decimal[] colourPrices = { 6.00m, 6.00m, 6.00m };
    public decimal[] scentPrices = { 6.00m, 6.00m, 6.00m };

    //  //  // FACE MASK    //  //  //

    // Face Mask Strap
    public Text basicStrapPriceText;
    public Text elasticStrapPriceText;
    public Text rubberStrapPriceText;

    // Face Mask Filter
    public Text doubleFilterPriceText;
    public Text singleFilterPriceText;
    public Text noneFilterPriceText;

    // Face Mask Colour 
    public Text blackPriceText;
    public Text bluePriceText;
    public Text whitePriceText;

    // Face Mask Prices 
    public decimal[] strapPrices = { 6.00m, 6.00m, 6.00m };
    public decimal[] filterPrices = { 6.00m, 6.00m, 6.00m };
    public decimal[] colourFMPrices = { 6.00m, 6.00m, 6.00m };

    //  //  // GLOVES    //  //  //

    // Gloves Material
    public Text cottonMaterialPriceText;
    public Text plasticMaterialPriceText;
    public Text rubberMaterialPriceText;

    // Gloves Siza
    public Text largeSizePriceText;
    public Text mediumSizePriceText;
    public Text smallSizePriceText;

    // Gloves Colour 
    public Text cyanGPriceText;
    public Text limeGPriceText;
    public Text yellowGPriceText;

    // Gloves Prices 
    public decimal[] materialPrices = { 6.00m, 6.00m, 6.00m };
    public decimal[] sizePrices = { 6.00m, 6.00m, 6.00m };
    public decimal[] colourGPrices = { 6.00m, 6.00m, 6.00m };

    // Initializes Price tags
    private void Start()
    {
        faceMaskAvailable = false;
        glovesAvailable = false;

        // Initialise Hand Sanitiser
        pumpBottlePriceText.text = "$" + bottlePrices[0];
        sprayBottlePriceText.text = "$" + bottlePrices[1];
        squeezeBottlePriceText.text = "$" + bottlePrices[2];

        yellowPriceText.text = "$" + colourPrices[0];
        greenPriceText.text = "$" + colourPrices[1];
        redPriceText.text = "$" + colourPrices[2];

        applePriceText.text = "$" + scentPrices[0];
        watermelonPriceText.text = "$" + scentPrices[1];
        lemonPriceText.text = "$" + scentPrices[2];

        // Initialise FaceMasks
        basicStrapPriceText.text = "$" + strapPrices[0];
        elasticStrapPriceText.text = "$" + strapPrices[1];
        rubberStrapPriceText.text = "$" + strapPrices[2];

        doubleFilterPriceText.text = "$" + filterPrices[0];
        singleFilterPriceText.text = "$" + filterPrices[1];
        noneFilterPriceText.text = "$" + filterPrices[2];

        blackPriceText.text = "$" + colourFMPrices[0];
        bluePriceText.text = "$" + colourFMPrices[1];
        whitePriceText.text = "$" + colourFMPrices[2];

        // Initialise Gloves
        cottonMaterialPriceText.text = "$" + materialPrices[0];
        plasticMaterialPriceText.text = "$" + materialPrices[1];
        rubberMaterialPriceText.text = "$" + materialPrices[2];

        largeSizePriceText.text = "$" + sizePrices[0];
        mediumSizePriceText.text = "$" + sizePrices[1];
        smallSizePriceText.text = "$" + sizePrices[2];

        cyanGPriceText.text = "$" + colourGPrices[0];
        limeGPriceText.text = "$" + colourGPrices[1];
        yellowGPriceText.text = "$" + colourGPrices[2];
    }

    //  // // //  //    HANDSANITISER    //  //  //  //  // 

    // Bottles
    public void IncPumpBottle()
    {
        bottlePrices[0] = IncreasePrice(pumpBottlePriceText, 1.00m, 2.00m, 10.00m, bottlePrices[0]);
    }

    public void DecPumpBottle()
    {
        bottlePrices[0] = DecreasePrice(pumpBottlePriceText, 1.00m, 2.00m, 10.00m, bottlePrices[0]);
    }
   
    public void IncSprayBottle()
    {
        bottlePrices[1] = IncreasePrice(sprayBottlePriceText, 1.00m, 2.00m, 10.00m, bottlePrices[1]);
    }

    public void DecSprayBottle()
    {
        bottlePrices[1] = DecreasePrice(sprayBottlePriceText, 1.00m, 2.00m, 10.00m, bottlePrices[1]);
    }

    public void IncSqueezeBottle()
    {
        bottlePrices[2] = IncreasePrice(squeezeBottlePriceText, 1.00m, 2.00m, 10.00m, bottlePrices[2]);
    }

    public void DecSqueezeBottle()
    {
        bottlePrices[2] = DecreasePrice(squeezeBottlePriceText, 1.00m, 2.00m, 10.00m, bottlePrices[2]);
    }

    // Colours
    public void IncYellow()
    {
        colourPrices[0] = IncreasePrice(yellowPriceText, 1.00m, 2.00m, 10.00m, colourPrices[0]);
    }

    public void DecYellow()
    {
        colourPrices[0] = DecreasePrice(yellowPriceText, 1.00m, 2.00m, 10.00m, colourPrices[0]);
    }

    public void IncGreen()
    {
        colourPrices[1] = IncreasePrice(greenPriceText, 1.00m, 2.00m, 10.00m, colourPrices[1]);
    }

    public void DecGreen()
    {
        colourPrices[1] = DecreasePrice(greenPriceText, 1.00m, 2.00m, 10.00m, colourPrices[1]);
    }

    public void IncRed()
    {
        colourPrices[2] = IncreasePrice(redPriceText, 1.00m, 2.00m, 10.00m, colourPrices[2]);
    }

    public void DecRed()
    {
        colourPrices[2] = DecreasePrice(redPriceText, 1.00m, 2.00m, 10.00m, colourPrices[2]);
    }
    
    // Scent
    public void IncApple()
    {
        scentPrices[0] = IncreasePrice(applePriceText, 1.00m, 2.00m, 10.00m, scentPrices[0]);
    }

    public void DecApple()
    {
        scentPrices[0] = DecreasePrice(applePriceText, 1.00m, 2.00m, 10.00m, scentPrices[0]);
    }

    public void IncWatermelon()
    {
        scentPrices[1] = IncreasePrice(watermelonPriceText, 1.00m, 2.00m, 10.00m, scentPrices[1]);
    }

    public void DecWatermelon()
    {
        scentPrices[1] = DecreasePrice(watermelonPriceText, 1.00m, 2.00m, 10.00m, scentPrices[1]);
    }

    public void IncLemon()
    {
        scentPrices[2] = IncreasePrice(lemonPriceText, 1.00m, 2.00m, 10.00m, scentPrices[2]);
    }

    public void DecLemon()
    {
        scentPrices[2] = DecreasePrice(lemonPriceText, 1.00m, 2.00m, 10.00m, scentPrices[2]);
    }

    //  // // //  //    FACEMASK    //  //  //  //  // 

    // Strap
    public void IncBasicStrap()
    {
        strapPrices[0] = IncreasePrice(basicStrapPriceText, 1.00m, 2.00m, 10.00m, strapPrices[0]);
    }

    public void DecBasicStrap()
    {
        strapPrices[0] = DecreasePrice(basicStrapPriceText, 1.00m, 2.00m, 10.00m, strapPrices[0]);
    }

    public void IncElasticStrap()
    {
        strapPrices[1] = IncreasePrice(elasticStrapPriceText, 1.00m, 2.00m, 10.00m, strapPrices[1]);
    }

    public void DecElasticStrap()
    {
        strapPrices[1] = DecreasePrice(elasticStrapPriceText, 1.00m, 2.00m, 10.00m, strapPrices[1]);
    }

    public void IncRubberStrap()
    {
        strapPrices[2] = IncreasePrice(rubberStrapPriceText, 1.00m, 2.00m, 10.00m, strapPrices[2]);
    }

    public void DecRubberStrap()
    {
        strapPrices[2] = DecreasePrice(rubberStrapPriceText, 1.00m, 2.00m, 10.00m, strapPrices[2]);
    }


    // Filter
    public void IncDoubleFilter()
    {
        filterPrices[0] = IncreasePrice(doubleFilterPriceText, 1.00m, 2.00m, 10.00m, filterPrices[0]);
    }

    public void DecDoubleFIlter()
    {
        filterPrices[0] = DecreasePrice(doubleFilterPriceText, 1.00m, 2.00m, 10.00m, filterPrices[0]);
    }

    public void IncSingleFilter()
    {
        filterPrices[1] = IncreasePrice(singleFilterPriceText, 1.00m, 2.00m, 10.00m, filterPrices[1]);
    }

    public void DecSingleFIlter()
    {
        filterPrices[1] = DecreasePrice(singleFilterPriceText, 1.00m, 2.00m, 10.00m, filterPrices[1]);
    }

    public void IncNoneFIlter()
    {
        filterPrices[2] = IncreasePrice(noneFilterPriceText, 1.00m, 2.00m, 10.00m, filterPrices[2]);
    }

    public void DecNoneFilter()
    {
        filterPrices[2] = DecreasePrice(noneFilterPriceText, 1.00m, 2.00m, 10.00m, filterPrices[2]);
    }

    // Colour

    public void IncBlack()
    {
        colourFMPrices[0] = IncreasePrice(blackPriceText, 1.00m, 2.00m, 10.00m, colourFMPrices[0]);
    }

    public void DecBlack()
    {
        colourFMPrices[0] = DecreasePrice(blackPriceText, 1.00m, 2.00m, 10.00m, colourFMPrices[0]);
    }

    public void IncBlue()
    {
        colourFMPrices[1] = IncreasePrice(bluePriceText, 1.00m, 2.00m, 10.00m, colourFMPrices[1]);
    }

    public void DecBlue()
    {
        colourFMPrices[1] = DecreasePrice(bluePriceText, 1.00m, 2.00m, 10.00m, colourFMPrices[1]);
    }

    public void IncWhite()
    {
        colourFMPrices[2] = IncreasePrice(whitePriceText, 1.00m, 2.00m, 10.00m, colourFMPrices[2]);
    }

    public void DecWhite()
    {
        colourFMPrices[2] = DecreasePrice(whitePriceText, 1.00m, 2.00m, 10.00m, colourFMPrices[2]);
    }


    //  // // //  //    Gloves    //  //  //  //  // 

    // Material
    public void IncCottonMaterial()
    {
        materialPrices[0] = IncreasePrice(cottonMaterialPriceText, 1.00m, 2.00m, 10.00m, materialPrices[0]);
    }

    public void DecCottonMaterial()
    {
        materialPrices[0] = DecreasePrice(cottonMaterialPriceText, 1.00m, 2.00m, 10.00m, materialPrices[0]);
    }

    public void IncPlasticMaterial()
    {
        materialPrices[1] = IncreasePrice(plasticMaterialPriceText, 1.00m, 2.00m, 10.00m, materialPrices[1]);
    }

    public void DecPlasticMaterial()
    {
        materialPrices[1] = DecreasePrice(plasticMaterialPriceText, 1.00m, 2.00m, 10.00m, materialPrices[1]);
    }

    public void IncRubberMaterial()
    {
        materialPrices[2] = IncreasePrice(rubberMaterialPriceText, 1.00m, 2.00m, 10.00m, materialPrices[2]);
    }

    public void DecRubberMaterial()
    {
        materialPrices[2] = DecreasePrice(rubberMaterialPriceText, 1.00m, 2.00m, 10.00m, materialPrices[2]);
    } 

    // Size
    public void IncLargeSzie()
    {
        sizePrices[0] = IncreasePrice(largeSizePriceText, 1.00m, 2.00m, 10.00m, sizePrices[0]);
    }

    public void DecLargeSize()
    {
        sizePrices[0] = DecreasePrice(largeSizePriceText, 1.00m, 2.00m, 10.00m, sizePrices[0]);
    }

    public void IncMediumSize()
    {
        sizePrices[1] = IncreasePrice(mediumSizePriceText, 1.00m, 2.00m, 10.00m, sizePrices[1]);
    }

    public void DecMediumSize()
    {
        sizePrices[1] = DecreasePrice(mediumSizePriceText, 1.00m, 2.00m, 10.00m, sizePrices[1]);
    }

    public void IncSmallSize()
    {
        sizePrices[2] = IncreasePrice(smallSizePriceText, 1.00m, 2.00m, 10.00m, sizePrices[2]);
    }

    public void DecSmallSize()
    {
        sizePrices[2] = DecreasePrice(smallSizePriceText, 1.00m, 2.00m, 10.00m, sizePrices[2]);
    }

    // Colour
    public void IncCyan()
    {
        colourGPrices[0] = IncreasePrice(cyanGPriceText, 1.00m, 2.00m, 10.00m, colourGPrices[0]);
    }

    public void DecCyan()
    {
        colourGPrices[0] = DecreasePrice(cyanGPriceText, 1.00m, 2.00m, 10.00m, colourGPrices[0]);
    }

    public void IncLime()
    {
        colourGPrices[1] = IncreasePrice(limeGPriceText, 1.00m, 2.00m, 10.00m, colourGPrices[1]);
    }

    public void DecLime()
    {
        colourGPrices[1] = DecreasePrice(limeGPriceText, 1.00m, 2.00m, 10.00m, colourGPrices[1]);
    }

    public void IncYellowG()
    {
        colourGPrices[2] = IncreasePrice(yellowGPriceText, 1.00m, 2.00m, 10.00m, colourGPrices[2]);
    }

    public void DecYellowG()
    {
        colourGPrices[2] = DecreasePrice(yellowGPriceText, 1.00m, 2.00m, 10.00m, colourGPrices[2]);
    }

    //  //  //  //  // SHARED METHODS   //  //  //  //  // 

    // Increase Button 
    public decimal IncreasePrice(Text priceText, decimal increment, decimal min, decimal max, decimal current)
    {
        if (current == max)
        {
            Debug.Log("Cant go any Higher");
        }
        else
        {
            current += increment;
            priceText.text = "$" + current;

        }
        return current;
    }

    // Decrease Button 
    public decimal DecreasePrice(Text priceText, decimal increment, decimal min, decimal max, decimal current)
    {
        if (current == min)
        {
            Debug.Log("Cant go any Lower");
        }
        else
        {
            current -= increment;
            priceText.text = "$" + current;

        }
        return current;
    }

    // Stock Manager 3 buttons method 
    public void HandSanitiserOpen()
    {
        HideAndShowTiles(1);
        ShowComponents(handSanitiserComponents);
        HideComponents(faceMaskComponents);
        HideComponents(gloveComponents);
    }

    // Stock Manager 3 buttons method 
    public void FaceMaskOpen()
    {
        if (faceMaskAvailable == true)
        {
            HideAndShowTiles(2);
            ShowComponents(faceMaskComponents);
            HideComponents(handSanitiserComponents);
            HideComponents(gloveComponents);
        }        
    }

    // Stock Manager 3 buttons method 
    public void GlovesOpen()
    {
        if (glovesAvailable == true)
        {
            HideAndShowTiles(3);
            ShowComponents(gloveComponents);
            HideComponents(handSanitiserComponents);
            HideComponents(faceMaskComponents);
        }
    }

    // Hides and Shows the appropriate tile
    public void HideAndShowTiles(int id)
    {
        switch (id)
        {
            case 1:
                handSanitiserBtn.SetActive(false);
                handSanitiserTile.SetActive(false);
                faceMaskBtn.SetActive(true);
                faceMaskTile.SetActive(true);
                glovesBtn.SetActive(true);
                glovesTile.SetActive(true);
                break;
            case 2:
                handSanitiserBtn.SetActive(true);
                handSanitiserTile.SetActive(true);
                faceMaskBtn.SetActive(false);
                faceMaskTile.SetActive(false);
                glovesBtn.SetActive(true);
                glovesTile.SetActive(true);
                break;
            case 3:
                handSanitiserBtn.SetActive(true);
                handSanitiserTile.SetActive(true);
                faceMaskBtn.SetActive(true);
                faceMaskTile.SetActive(true);
                glovesBtn.SetActive(false);
                glovesTile.SetActive(false);
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    // Hides and Shows the appropriate components
    public void ShowComponents(GameObject[] components)
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i].SetActive(true);
        }
    }

    public void HideComponents(GameObject[] components)
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i].SetActive(false);
        }
    }

    // Closes the window
    public void CloseWindow()
    {
        window.SetActive(false);
    }

    // Opens the window
    public void OpenWindow()
    {
        window.SetActive(true);
    }    

    // Return prices of component combinations for HandSanitiser
    public decimal HandSanitiserPrice(int comp1ID,int comp2ID, int comp3ID)
    {
        return bottlePrices[comp1ID] + colourPrices[comp2ID] + scentPrices[comp3ID];
    }

    // Return prices of component combinations for FaceMask
    public decimal FaceMaskPrice(int comp1ID, int comp2ID, int comp3ID)
    {
        return strapPrices[comp1ID] + filterPrices[comp2ID] + colourFMPrices[comp3ID];
    }

    // Return prices of component combinations for Gloves
    public decimal GlovesPrice(int comp1ID, int comp2ID, int comp3ID)
    {
        return materialPrices[comp1ID] + sizePrices[comp2ID] + colourGPrices[comp3ID];
    }
}
