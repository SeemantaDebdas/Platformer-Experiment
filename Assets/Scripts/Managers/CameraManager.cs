using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get { return instance; } }
    static CameraManager instance;

    [SerializeField] List<CinemachineVirtualCamera> cameras;

    private void Awake()
    {
        instance = this;
        UpdateCamera(0);
    }

    public void UpdateCamera(int cameraIdx)
    {
        for(int i = 0; i < cameras.Count; i++)
        {
            if(i == cameraIdx)
            {
                cameras[i].Priority = 11;
                cameras[i].gameObject.SetActive(true);
            }
            else
            {
                cameras[i].Priority = 10;
                cameras[i].gameObject.SetActive(false);
            }
        }
    }
}
