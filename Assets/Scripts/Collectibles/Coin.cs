using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //later implement object pooling
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseCollectedCoins();
            Destroy(this.gameObject);
        }
            
    }
}
