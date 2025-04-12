using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarStability : MonoBehaviour
{
    public Vector3 centerOfMassOffset = new Vector3(0, -0.9f, 0); // Y�Ḻֵ��ʾ��������

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMassOffset;
    }
}
