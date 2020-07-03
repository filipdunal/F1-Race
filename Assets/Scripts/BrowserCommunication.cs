using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class BrowserCommunication : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendData(float x);
    public CheckpointsSystem checkpointSystem;
    float _globalBestTime=0f;
    float actualPoints;
    public void ReceiveData(float globalBestTime)
    {
        _globalBestTime = globalBestTime;
        if(globalBestTime!=0f && globalBestTime<checkpointSystem.bestLap)
        {
            checkpointSystem.bestLap = globalBestTime;
        }
    }
    private void LateUpdate()
    {
        if(checkpointSystem.points!=actualPoints)
        {
            Debug.Log("Send data");
            SendData(checkpointSystem.points);
            actualPoints = checkpointSystem.points;
        }
        
        
    }
}

//unityInstance.SendMessage('BrowserCommunication','ReceiveData',value)
