using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("�ƶ�����")]
    public float acceleration = 800f;     // �������������ʾ��Ӧ���죩
    public float maxSpeed = 20f;          // ����ٶ�
    public float deceleration = 0.98f;    // �ɿ���ʱ�ļ������ӣ�0~1֮�䣩

    [Header("ת������")]
    public float turnSpeed = 100f;        // ת���ٶ�

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = Vector3.zero;

        // ǰ�����������
        if (Input.GetKey(KeyCode.W))
            inputDirection += transform.forward;
        if (Input.GetKey(KeyCode.S))
            inputDirection -= transform.forward;

        // ˮƽת�򣨵�������Ҳ��Ȼת��
        if (Input.GetKey(KeyCode.A))
        {
            // ������ڵ���
            if (Input.GetKey(KeyCode.S))
                transform.Rotate(0f, turnSpeed * Time.fixedDeltaTime, 0f); // ���ң���󷽣�
            else
                transform.Rotate(0f, -turnSpeed * Time.fixedDeltaTime, 0f); // ��������ǰ����
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.S))
                transform.Rotate(0f, -turnSpeed * Time.fixedDeltaTime, 0f); // �����Һ󷽣�
            else
                transform.Rotate(0f, turnSpeed * Time.fixedDeltaTime, 0f);  // ���ң�����ǰ����
        }

        // ���˳���ƽ���
        if (inputDirection != Vector3.zero)
        {
            if (rb.velocity.magnitude < maxSpeed)
                rb.AddForce(inputDirection.normalized * acceleration * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        else
        {
            // �ɿ���ʱ�Զ����٣�ģ��Ħ����
            rb.velocity *= deceleration;
        }
    }
}
