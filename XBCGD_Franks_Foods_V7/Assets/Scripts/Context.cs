using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Context : MonoBehaviour
{
    public string context;
    public Image image;
    public Text text;

    private void Start()
    {
        image = GameObject.FindGameObjectWithTag("Context Image").gameObject.GetComponent<Image>();
        text = GameObject.FindGameObjectWithTag("Context Text").gameObject.GetComponent<Text>();
        HideUI();
    }

    //Display context
    private void OnMouseOver()
    {
        text.text = context;
        ShowUI();
    }

    //hide context
    private void OnMouseExit()
    {
        text.text = "";
        HideUI();
    }

    void ShowUI()
    {
        image.gameObject.SetActive(true);
    }

    void HideUI()
    {
        image.gameObject.SetActive(false);
    }
}
