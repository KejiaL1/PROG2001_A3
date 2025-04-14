using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (x,y,z) * Time.deltaTime);
    }
}
