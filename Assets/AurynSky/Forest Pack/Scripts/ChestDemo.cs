using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    [SerializeField] GameObject coinPrefab;
    [SerializeField] float forceMultiplier = 2f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(-50, 0, 0);
                GameObject coinPrefabSpawn = Instantiate(coinPrefab, transform.position,Quaternion.identity);
                coinPrefabSpawn.AddComponent<Rigidbody>().AddForce(new Vector3(-0.3f, 1, 0) * forceMultiplier,ForceMode.Impulse);
            }
        }
    }
}
