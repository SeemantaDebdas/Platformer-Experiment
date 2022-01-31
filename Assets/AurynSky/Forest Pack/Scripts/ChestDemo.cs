using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HUDManager.Instance.ActivateInstructionPanel();
                transform.Rotate(-50, 0, 0);
            }
        }
    }
}
