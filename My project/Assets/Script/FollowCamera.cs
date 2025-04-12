using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;            // 需要跟随的目标（你的汽车父对象）
    public Vector3 offset = new Vector3(0f, 5f, -10f);  // 摄像机偏移量
    public float followSpeed = 5f;      // 跟随平滑度

    void LateUpdate()
    {
        if (target == null) return;

        // 目标位置 + 偏移，使用 target 的旋转方向来计算后方位置
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // 始终看向目标
        transform.LookAt(target);
    }
}
