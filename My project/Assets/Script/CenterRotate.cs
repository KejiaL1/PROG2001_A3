using UnityEngine;


public class CenterRotate : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second.")]
    public float rotationSpeed = 45f;

    void Update()
    {
        // 物体沿自身 Y 轴旋转
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }

    // 使用 Trigger 方式检测碰撞
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入触发器的是否为汽车对象（这里假设汽车对象的标签为 "Player"）
        if (other.CompareTag("Player"))
        {
            // 通知管理器已收集到该物品（假设你的管理器脚本名为 CollectibleManager）
            CollectibleManager manager = FindObjectOfType<CollectibleManager>();
            if (manager != null)
            {
                manager.Collect();
            }
            // 消除该收集物
            Destroy(gameObject);
        }
    }
}