using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    public int TotalCoins { get { return totalCoins; } }
    static GameManager instance;

    int totalCoins;
    int collectedCoins;

    public void ProcessGameOver()
    {
        HUDManager.Instance.ActivateGameoverScreen();
    }

    public void IncreaseCollectedCoins() => collectedCoins++;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // +1 for the coin that gets popped out from the chest
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length + 1;
    }

    private void Update()
    {
        if(collectedCoins == totalCoins)
        {
            //show Win Screen
            HUDManager.Instance.ActivateWinScreen();
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
