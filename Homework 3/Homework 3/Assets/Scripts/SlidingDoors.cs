using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoors : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    [SerializeField] float WaittimeMin = 0.1f;
    [SerializeField] float WaittimeMax = 0.3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (period >= Mathf.Epsilon)
            StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        
        float cycles = Time.time / period;  // continually growing over time
        
        const float tau = Mathf.PI * 2;  // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau);  // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
        float Waittime= Random.Range(WaittimeMin,WaittimeMax);
        float initialperiod = period;
        period = 0;
        yield return new WaitForSecondsRealtime (Waittime);
        period = initialperiod;
    }


}
