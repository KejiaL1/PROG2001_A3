using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenePlay : MonoBehaviour
{
    // Load scene by build index
    public void LoadMyScene(int sceneNumber)
    {

        StartCoroutine(PlayMySound(sceneNumber)); // Load scene by name
        //SceneManager.LoadScene(sceneNumber);
    }

    // Delayed load for int parameter
    public void LoadMyScene(string sceneName)
    {
        StartCoroutine(PlayMySound(sceneName)); 
    }

    // Immediate load for string parameter
    private IEnumerator PlayMySound(int sceneNumber)
    {
        yield return new WaitForSeconds(0.5f); 
        SceneManager.LoadScene(sceneNumber); 
    }

    private IEnumerator PlayMySound(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}