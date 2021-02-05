using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingComponent : MonoBehaviour
{
    public Crafting craftingObj;
    public AudioManager audioManager;

    private void OnMouseDown()
    {
        if (craftingObj.currentlyCrafting == true)
        {
            if (craftingObj.craftingHandSanitiser == true && gameObject.tag == "HS")
            {
                craftingObj.PlayerOrder(gameObject.name);
                audioManager.Play("Drill");
                audioManager.Play("Hammer");
                return;
            }

            if (craftingObj.craftingFaceMask == true && gameObject.tag == "FM")
            {
                craftingObj.PlayerOrder(gameObject.name);
                audioManager.Play("Drill");
                audioManager.Play("Hammer");
                return;
            }

            if (craftingObj.craftingGloves == true && gameObject.tag == "G")
            {
                craftingObj.PlayerOrder(gameObject.name);
                audioManager.Play("Drill");
                audioManager.Play("Hammer");
                return;
            }

            if (craftingObj.craftingGloves == false && craftingObj.craftingFaceMask == false && craftingObj.craftingHandSanitiser == false)
            {
                // error
                Debug.Log("You should pick up an ordr before you try craftignsometing ");
            }
        }
    }
}
