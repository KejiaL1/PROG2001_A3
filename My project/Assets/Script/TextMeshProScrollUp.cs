using UnityEngine;
using TMPro;

public class TextMeshProScrollUp : MonoBehaviour
{
    public float scrollSpeed = 50f; // 滚动速度
    private RectTransform textRectTransform;
    private float originalYPosition;

    void Start()
    {
        // 获取 TextMeshPro 的 RectTransform 组件
        textRectTransform = GetComponent<RectTransform>();
        if (textRectTransform == null)
        {
            Debug.LogError("TextMeshProScrollUp: No RectTransform found on this GameObject.");
        }

        // 保存初始位置
        originalYPosition = textRectTransform.anchoredPosition.y;
    }

    void Update()
    {
        // 更新文字的位置
        float newYPosition = textRectTransform.anchoredPosition.y + scrollSpeed * Time.deltaTime;
        textRectTransform.anchoredPosition = new Vector2(textRectTransform.anchoredPosition.x, newYPosition);

        // 如果文字完全移出屏幕，则重置位置
        if (newYPosition > Screen.height)
        {
            textRectTransform.anchoredPosition = new Vector2(textRectTransform.anchoredPosition.x, -textRectTransform.rect.height);
        }
    }
}