    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

    //BUTTONS
    public Button startBtn;
    public Button optionsBtn;
    public Button muteBtn;
    public Button exitBtn;
    public Button closeOptionsBtn;

    public Scene gameScene;

    //PANELS
    public GameObject optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtn()
    {
        
        SceneManager.LoadScene("Incremential");
    }

    public void OptionsBtn()
    {
        optionsPanel.gameObject.SetActive(true);
    }

    public void OptionsCloseBtn()
    {
        optionsPanel.gameObject.SetActive(false);
    }

  

   
}
