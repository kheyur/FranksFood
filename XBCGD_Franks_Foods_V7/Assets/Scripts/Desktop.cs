using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desktop : MonoBehaviour
{
    public GameObject desktop;
    public AudioManager audioManager;

    private void OnMouseDown()
    {
        audioManager.Play("OpenDesktop");
        desktop.SetActive(true);
    }

    public void ShutDown()
    {
        audioManager.Play("CloseDesktop");
        desktop.SetActive(false);
    }
}
