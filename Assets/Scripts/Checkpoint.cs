using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isStart;
    public int scored;
    public GameObject lightMark;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="car")
        {
            if(isStart)
            {
                transform.parent.GetComponent<CheckpointsSystem>().RefreshAllLights();
            }
            scored = 1;
            lightMark.SetActive(true);
        }
    }
    public void Refresh()
    {
        scored = 0;
    }

    public void RefreshLight()
    {
        lightMark.SetActive(false);
    }
}
