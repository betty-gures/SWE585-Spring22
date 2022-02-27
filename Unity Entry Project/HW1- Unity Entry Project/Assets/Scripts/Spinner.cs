using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 0;
    [SerializeField] float yAngle = 0;
    [SerializeField] float zAngle = 0;
    [SerializeField] float multiplier= 20;
    void Update()
    {
        transform.Rotate(xAngle * Time.deltaTime * multiplier, 
                         yAngle * Time.deltaTime * multiplier, 
                         zAngle * Time.deltaTime * multiplier);
    }
}
