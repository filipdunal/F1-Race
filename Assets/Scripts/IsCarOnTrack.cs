using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCarOnTrack : MonoBehaviour
{
    public GameObject car;
    Steering carSteering;
    private void Start()
    {
        carSteering=car.GetComponent<Steering>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name =="car")
        {
            carSteering.speedForce = carSteering.originalSpeedForce;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "car")
        {
            //Debug.Log("TAK");
            carSteering.speedForce = carSteering.originalSpeedForce / 3f ;
        }
    }
}
