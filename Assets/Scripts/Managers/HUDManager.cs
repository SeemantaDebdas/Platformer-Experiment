using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get { return instance; } }
    static HUDManager instance;

    [SerializeField] GameObject WinScreen;
    [SerializeField] TextMeshProUGUI coinsCollectedText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;
    [Header("Instruction Panel")]
    [SerializeField] GameObject instructionPanel;

    [SerializeField] GameObject gameOverScreen;

    int coinAmt = 0;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateWinScreen()
    {
        coinsCollectedText.text = "Coins Collected: "+GameManager.Instance.TotalCoins.ToString();
        scoreText.text = "Score: " + (GameManager.Instance.TotalCoins * 10).ToString();
        WinScreen.SetActive(true);
    }

    public void ActivateGameoverScreen()=> gameOverScreen.SetActive(true);

    public void ActivateInstructionPanel() => instructionPanel.SetActive(true);

    public void UpdateCoinText() => coinText.text = "x "+(++coinAmt).ToString();

}
