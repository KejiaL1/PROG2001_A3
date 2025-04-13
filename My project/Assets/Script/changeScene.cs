using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Load scene by build index with delay
    public void LoadMyScene(int sceneNumber)
    {
        StartCoroutine(PlayMySound(sceneNumber));
    }

    // Load scene by name immediately
    public void LoadMyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        StartCoroutine(PlayMySound(sceneName));
    }

    // Delayed scene load with int parameter (1.5s wait)
    private IEnumerator PlayMySound(int sceneNumber)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneNumber);
    }

    // Immediate scene load with string parameter
    private IEnumerator PlayMySound(string sceneName)
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(sceneName);
    }
}