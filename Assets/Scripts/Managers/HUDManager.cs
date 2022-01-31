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
    [Header("Instruction Panel")]
    [SerializeField] GameObject instructionPanel;

    [SerializeField] GameObject gameOverScreen;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateWinScreen()
    {
        coinsCollectedText.text = "Coins Collected: "+GameManager.Instance.TotalCoins.ToString();
        WinScreen.SetActive(true);
    }

    public void ActivateGameoverScreen()=> gameOverScreen.SetActive(true);

    public void ActivateInstructionPanel() => instructionPanel.SetActive(true);

}
