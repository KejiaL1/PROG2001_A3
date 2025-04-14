using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollectibleManager : MonoBehaviour
{
    public int totalCollectibles = 5;
    private int collectedCount = 0;

    public TextMeshProUGUI collectibleUIText;
    public GameObject winPanel;
    public TextMeshProUGUI winMessageText;

    public GameObject failPanel;
    public TextMeshProUGUI failMessageText;

    [Header("Player Car")]
    public Transform carTransform;
    public float fallThresholdY = -10f;

    private bool gameEnded = false;

    public string targetSceneName = "NextScene";


    void Start()
    {
        UpdateCollectibleUI();
        winPanel.SetActive(false);
        failPanel.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded && carTransform.position.y < fallThresholdY)
        {
            GameFail("Failed! Car fell out of the scene!");
        }
    }

    public void Collect()
    {
        if (gameEnded) return;

        collectedCount++;
        UpdateCollectibleUI();

        if (collectedCount >= totalCollectibles)
        {
            GameWin("Victory! All items collected!");
            StartCoroutine(LoadSceneAfterDelay(targetSceneName));
        }
    }

    void UpdateCollectibleUI()
    {
        if (collectibleUIText != null)
        {
            collectibleUIText.text = "     Remaining: " + (totalCollectibles - collectedCount);
        }
    }

    void GameWin(string message)
    {
        gameEnded = true;
        winPanel.SetActive(true);
        if (winMessageText != null)
        {
            winMessageText.text = message;
        }
    }

    void GameFail(string message)
    {
        gameEnded = true;
        failPanel.SetActive(true);
        if (failMessageText != null)
        {
            failMessageText.text = message;
        }
    }
        IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
