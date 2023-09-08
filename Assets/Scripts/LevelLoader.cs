using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    public GameObject button;

    private void ExecuteTrigger(string trigger) 
    {
        if (button != null) 
        {
            var animator = button.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    public void OnButtonClick()
    {
        if (button.gameObject.name == "EnterMenu")
        {
            StartCoroutine(LoadLevel(1));
        }
        else if (button.gameObject.name == "Start")
        {
            StartCoroutine(LoadLevel(2));
        }
        else if (button.gameObject.name == "Next") 
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else if (button.gameObject.name == "Menu" || button.gameObject.name == "Return")
        {
            StartCoroutine(LoadLevel(1));
        }
        else if (button.gameObject.name == "Retry")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        else if (button.gameObject.name == "Quit") 
        {
            Application.Quit();
        }
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        // Play animation
        transition.SetTrigger("Start");

        // Wait a short while
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
