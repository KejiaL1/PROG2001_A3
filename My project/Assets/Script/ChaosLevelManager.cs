using UnityEngine;
using TMPro;

public class ChaosLevelManager : MonoBehaviour
{
    [Header("Score Settings")]
    [Tooltip("Score multiplier: the chaos level added equals the collided object's mass multiplied by this value")]
    public float scoreMultiplier = 1f;
    [Tooltip("Target Chaos Level (score)")]
    public float targetChaosLevel = 100f;
    [HideInInspector]
    public float currentChaosLevel = 0f;

    [Header("Time Settings")]
    [Tooltip("Total game duration (in seconds)")]
    public float gameDuration = 60f;
    private float timeRemaining;

    [Header("UI References (TextMeshProUGUI)")]
    [Tooltip("Displays the current chaos level")]
    public TextMeshProUGUI chaosLevelText;
    [Tooltip("Displays the target chaos level")]
    public TextMeshProUGUI targetChaosText;
    [Tooltip("Displays the time remaining")]
    public TextMeshProUGUI timerText;
    [Tooltip("Displays game result (Success/Failure)")]
    public TextMeshProUGUI gameResultText;

    private bool gameActive = true;

    void Start()
    {
        timeRemaining = gameDuration;
        if (targetChaosText != null)
            targetChaosText.text = "Target Chaos Level: " + targetChaosLevel.ToString("F0");
        UpdateChaosUI();
        UpdateTimerUI();
        if (gameResultText != null)
            gameResultText.text = "";
    }

    void Update()
    {
        if (gameActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    /// <summary>
    /// ��Ϸ����ʱ�����ݵ�ǰ�Ļ��ҳ̶���ʾ�ɹ���ʧ����Ϣ
    /// </summary>
    private void EndGame()
    {
        gameActive = false;
        if (gameResultText != null)
        {
            if (currentChaosLevel >= targetChaosLevel)
                gameResultText.text = "Success! Chaos level achieved!";
            else
                gameResultText.text = "Failed! Insufficient chaos level!";
        }
    }

    /// <summary>
    /// ������ʾ��ǰ���ҳ̶ȵ� UI �ı�
    /// </summary>
    private void UpdateChaosUI()
    {
        if (chaosLevelText != null)
            chaosLevelText.text = "Chaos Level: " + currentChaosLevel.ToString("F0");
    }

    /// <summary>
    /// ������ʾʣ��ʱ��� UI �ı�
    /// </summary>
    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "Time Remaining: " + Mathf.Max(timeRemaining, 0).ToString("F0") + " s";
    }

    /// <summary>
    /// ������������ײʱ��������ײ����� Rigidbody �����ۼӻ��ҳ̶ȵ÷�
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (!gameActive)
            return;

        Rigidbody otherRb = collision.rigidbody;
        if (otherRb != null)
        {
            float mass = otherRb.mass;
            float addedScore = mass * scoreMultiplier;
            currentChaosLevel += addedScore;
            UpdateChaosUI();
            Debug.Log("Added chaos: " + addedScore + ", Current chaos level: " + currentChaosLevel);
        }
    }
}
