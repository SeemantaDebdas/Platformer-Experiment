using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour
{
    [SerializeField] int triggerIdx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            CameraManager.Instance.UpdateCamera(triggerIdx);
    }
}
