using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //later implement object pooling
        if (other.CompareTag("Player"))
        {
            HUDManager.Instance.UpdateCoinText();
            GameManager.Instance.IncreaseCollectedCoins();
            Destroy(this.gameObject);
        }
            
    }
}
