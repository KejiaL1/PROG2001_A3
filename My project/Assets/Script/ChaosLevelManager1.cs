using UnityEngine;
using TMPro;

public class ChaosLevelManager1 : MonoBehaviour
{
    [Header("Score Settings")]
    [Tooltip("Score multiplier: the chaos level added equals the collided object's mass multiplied by this value")]
    public float scoreMultiplier = 1f;

    [Tooltip("Target Chaos Level (score)")]
    public float targetChaosLevel = 100f;

    [HideInInspector]
    public float currentChaosLevel = 0f;

    [Header("UI References (TextMeshProUGUI)")]
    [Tooltip("Displays the current chaos level")]
    public TextMeshProUGUI chaosLevelText;

    [Tooltip("Displays the target chaos level")]
    public TextMeshProUGUI targetChaosText;

    [Tooltip("Displays game result (Success/Failure)")]
    public TextMeshProUGUI gameResultText;

    [Header("Player Car")]
    public Transform carTransform;
    public float fallThresholdY = -10f;

    private bool gameActive = true;

    void Start()
    {
        if (targetChaosText != null)
            targetChaosText.text = "Target Chaos Level: " + targetChaosLevel.ToString("F0");

        UpdateChaosUI();

        if (gameResultText != null)
            gameResultText.text = "";
    }

    void Update()
    {
        if (!gameActive) return;

        // 检测掉出场景失败
        if (carTransform != null && carTransform.position.y < fallThresholdY)
        {
            gameActive = false;
            if (gameResultText != null)
                gameResultText.text = "Failed! Car fell out of the scene!";
        }
    }

    private void UpdateChaosUI()
    {
        if (chaosLevelText != null)
            chaosLevelText.text = "Chaos Level: " + currentChaosLevel.ToString("F0");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameActive) return;

        Rigidbody otherRb = collision.rigidbody;
        if (otherRb != null)
        {
            float mass = otherRb.mass;
            float addedScore = mass * scoreMultiplier;
            currentChaosLevel += addedScore;

            UpdateChaosUI();
            Debug.Log("Added chaos: " + addedScore + ", Current chaos level: " + currentChaosLevel);

            // ✅ 如果达标立即胜利
            if (currentChaosLevel >= targetChaosLevel)
            {
                gameActive = false;
                if (gameResultText != null)
                    gameResultText.text = "Success! Chaos level achieved!";
            }
        }
    }
}
