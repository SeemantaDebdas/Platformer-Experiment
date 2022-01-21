using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    public int TotalCoins { get { return totalCoins; } }
    static GameManager instance;

    int totalCoins;
    int collectedCoins;

    public void IncreaseCollectedCoins() => collectedCoins++;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    private void Update()
    {
        if(collectedCoins == totalCoins)
        {
            //show Win Screen
            HUDManager.Instance.ActivateWinScreen();
        }
    }
}
