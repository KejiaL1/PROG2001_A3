using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;            // ��Ҫ�����Ŀ�꣨�������������
    public Vector3 offset = new Vector3(0f, 5f, -10f);  // �����ƫ����
    public float followSpeed = 5f;      // ����ƽ����

    void LateUpdate()
    {
        if (target == null) return;

        // Ŀ��λ�� + ƫ�ƣ�ʹ�� target ����ת�����������λ��
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // ʼ�տ���Ŀ��
        transform.LookAt(target);
    }
}
