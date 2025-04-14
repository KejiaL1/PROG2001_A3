using UnityEngine;

public class ContinuousRotator : MonoBehaviour
{
    [Header("旋转设置")]
    [Tooltip("旋转速度（度/秒）")]
    public float rotationSpeed = 30f; // 默认每秒30度

    [Tooltip("旋转轴")]
    public Vector3 rotationAxis = Vector3.up; // 默认绕Y轴旋转

    void Update()
    {
        // 计算每帧旋转角度（与帧率无关）
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        
        // 应用旋转（使用本地坐标系）
        transform.Rotate(rotationAxis, rotationThisFrame, Space.Self);
    }
}