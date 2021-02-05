using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transition;
    public AudioManager audioManagerObj;

    public float transitionTime = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    // Fading between Scenes
    // This script requires you to have the prefab in all scenes
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


    // Fading in game 
    public void FadeElevator()
    {
        StartCoroutine(FadeDuringElevator());
    }

    IEnumerator FadeDuringElevator()
    {
        audioManagerObj.Play("Elevator_Bell");

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        audioManagerObj.Play("Elevator_Bell");
    }
}
