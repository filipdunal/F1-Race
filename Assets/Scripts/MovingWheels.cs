using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWheels : MonoBehaviour
{
    public float degreesToRotate;
    public float smooth;
    Quaternion target;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            target = Quaternion.Euler(0, 0, degreesToRotate);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            target = Quaternion.Euler(0, 0, -degreesToRotate);
        }
        else
        {
            target = Quaternion.Euler(0, 0, 0);
        }
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
    }
}
