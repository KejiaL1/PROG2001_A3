using UnityEngine;
using TMPro;

public class ChaosLevelManager2 : MonoBehaviour
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

    [Header("Player Car")]
    public Transform carTransform;       // 拖入汽车对象
    public float fallThresholdY = -10f;  // 汽车掉出场景的 Y 值

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

        // ✅ 新增：检测掉出场景失败
        if (gameActive && carTransform.position.y < fallThresholdY)
        {
            gameActive = false;
            if (gameResultText != null)
            {
                gameResultText.text = "Failed! Car fell out of the scene!";
            }
        }
    }

    /// <summary>
    /// 游戏结束时，根据当前的混乱程度显示成功或失败信息
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
    /// 更新显示当前混乱程度的 UI 文本
    /// </summary>
    private void UpdateChaosUI()
    {
        if (chaosLevelText != null)
            chaosLevelText.text = "Chaos Level: " + currentChaosLevel.ToString("F0");
    }

    /// <summary>
    /// 更新显示剩余时间的 UI 文本
    /// </summary>
    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "Time Remaining: " + Mathf.Max(timeRemaining, 0).ToString("F0") + " s";
    }

    /// <summary>
    /// 当汽车发生碰撞时，根据碰撞物体的 Rigidbody 质量累加混乱程度得分
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
