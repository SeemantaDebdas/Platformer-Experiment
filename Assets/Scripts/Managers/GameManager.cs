using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    public int TotalCoins { get { return totalCoins; } }
    static GameManager instance;

    int totalCoins;
    int collectedCoins;

    public UnityEvent GameWonEvent;

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
        GameWonEvent = new UnityEvent();
    }

    private void Update()
    {
        if(collectedCoins == totalCoins)
        {
            //show Win Screen
            GameWonEvent.Invoke();
            HUDManager.Instance.ActivateWinScreen();
        }

        if (Input.GetKeyDown(KeyCode.P))
            Cheat();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void Cheat()
    {
        collectedCoins = totalCoins;
    }
}
