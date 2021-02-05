using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Crafting craftingObj;

    private void OnMouseDown()
    {
        craftingObj.OfferOrder();
    }
}
