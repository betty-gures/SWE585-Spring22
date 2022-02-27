using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float multiplier= 20;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddRelativeForce(Vector3.up * multiplier * Time.deltaTime);
    }
}
