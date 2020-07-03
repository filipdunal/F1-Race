using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointsSystem : MonoBehaviour
{
    public GameObject[] checkpoints;
    public Checkpoint[] checkpointsScripts;
    public int numberOfCheckpoints;
    public int scoredCheckpoints;

    public Text bestLapText;
    public Text lastLapText;
    public Text currentLapText;
    public Text checkpointsText;
    public Text sumOfPointsText;

    float lapTime;
    float lastLap;
    public float bestLap=999f;


    public float maxPointsWithoutPower = 100f;
    public float powerOfPoints = 2f;

    public float points;
    float sumOfPoints = 0f;
    

    private void OnGUI()
    {
        checkpointsText.text = scoredCheckpoints + "/" + numberOfCheckpoints;
        sumOfPointsText.text = System.Math.Round(sumOfPoints).ToString();
        currentLapText.text = System.Math.Round(lapTime,2).ToString();
        if(bestLap==999)
        {
            bestLapText.text = "";
        }
        else
        {
            bestLapText.text = System.Math.Round(bestLap, 2).ToString();
        }
        if (lastLap==0)
        {
            lastLapText.text = "";
        }
        else
        {
            lastLapText.text = System.Math.Round(lastLap, 2).ToString();
        }
        
    }
    private void Start()
    {
        checkpointsScripts = new Checkpoint[15];
        for(int i=0;i<numberOfCheckpoints;i++)
        {
            checkpointsScripts[i]=checkpoints[i].GetComponent<Checkpoint>();
        }
    }
    

    private void Update()
    {
        //Debug.Log(scoredCheckpoints + "/" + numberOfCheckpoints);
        scoredCheckpoints = 0;
        for(int i=0;i<numberOfCheckpoints;i++)
        {
            scoredCheckpoints += checkpointsScripts[i].scored;
        }
        //Debug.Log(scoredCheckpoints);

        if(scoredCheckpoints>0)
        {
            lapTime += Time.deltaTime;
            if (scoredCheckpoints == numberOfCheckpoints)
            {
                lastLap = lapTime;
                if(lastLap<bestLap)
                {
                    bestLap = lastLap;
                }

                points = maxPointsWithoutPower - lastLap;
                points=Mathf.Clamp(points, 0f, maxPointsWithoutPower);
                points = Mathf.Pow(points, powerOfPoints);
                sumOfPoints += points;
                Debug.Log(points);

                RefreshAll();
                lapTime = 0f;

            }
        }
    }

    void RefreshAll()
    {
        for (int i = 0; i < numberOfCheckpoints; i++)
        {
            checkpointsScripts[i].Refresh();
        }
    }

    public void RefreshAllLights()
    {
        for (int i = 0; i < numberOfCheckpoints; i++)
        {
            checkpointsScripts[i].RefreshLight();
        }
    }
}
