using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("移动设置")]
    public float acceleration = 800f;     // 加速力（更大表示响应更快）
    public float maxSpeed = 20f;          // 最大速度
    public float deceleration = 0.98f;    // 松开键时的减速因子（0~1之间）

    [Header("转向设置")]
    public float turnSpeed = 100f;        // 转向速度

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = Vector3.zero;

        // 前进与后退输入
        if (Input.GetKey(KeyCode.W))
            inputDirection += transform.forward;
        if (Input.GetKey(KeyCode.S))
            inputDirection -= transform.forward;

        // 水平转向（倒车方向也自然转）
        if (Input.GetKey(KeyCode.A))
        {
            // 如果正在倒车
            if (Input.GetKey(KeyCode.S))
                transform.Rotate(0f, turnSpeed * Time.fixedDeltaTime, 0f); // 向右（左后方）
            else
                transform.Rotate(0f, -turnSpeed * Time.fixedDeltaTime, 0f); // 向左（正常前进）
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.S))
                transform.Rotate(0f, -turnSpeed * Time.fixedDeltaTime, 0f); // 向左（右后方）
            else
                transform.Rotate(0f, turnSpeed * Time.fixedDeltaTime, 0f);  // 向右（正常前进）
        }

        // 添加顺滑推进力
        if (inputDirection != Vector3.zero)
        {
            if (rb.velocity.magnitude < maxSpeed)
                rb.AddForce(inputDirection.normalized * acceleration * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        else
        {
            // 松开键时自动减速（模拟摩擦）
            rb.velocity *= deceleration;
        }
    }
}
