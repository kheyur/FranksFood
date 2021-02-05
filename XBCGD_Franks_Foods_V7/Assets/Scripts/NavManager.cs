using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavManager : MonoBehaviour
{
    public AudioManager audioManagerObj;

    public GameObject radialNavMenu;
    public GameObject incremential;
    public GameObject elevator;
    public GameObject options;

    public bool radialMenuOpen = false;

    //Show Radial Menu 
    public void RadialOpenClose()
    {
        if (radialMenuOpen == false)
        {
            radialMenuOpen = true;
            radialNavMenu.SetActive(true);
            audioManagerObj.Play("MenuOpen");
        }
        else
        {
            radialMenuOpen = false;
            radialNavMenu.SetActive(false);
            audioManagerObj.Play("MenuOpen");
        }

    }


    public void Escape()
    {
        Application.Quit();
    }
    // Show
    public void ElevatorOpen()
    {
        elevator.SetActive(true);
        audioManagerObj.Play("Elevator");
        radialNavMenu.SetActive(false);
    }

    public void OptionsOpen()
    {
        options.SetActive(true);
        audioManagerObj.Play("Options");
        radialNavMenu.SetActive(false);
    }

    public void IncrementialOpen()
    {
        incremential.SetActive(true);
        audioManagerObj.Play("Incremential");
        radialNavMenu.SetActive(false);
    }

    // Hide 
    public void ElevatorClose()
    {
        elevator.SetActive(true);
        //audioManagerObj.Play();
    }

    public void OptionsClose()
    {
        options.SetActive(false);
        //audioManagerObj.Play();
    }

    public void IncrementialClose()
    {
        incremential.SetActive(true);
        //audioManagerObj.Play();
    }
}
