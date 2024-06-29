using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] int currentPointBalance;
    public int CurrentBalance { get { return currentBalance; } }
    public int CurrentPointBalance { get { return currentPointBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI displayPointBalance;

    void Awake() {
        currentBalance = startingBalance;
        currentPointBalance = 0;
        UpdateDisplay();
    }

    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void DepositPoints(int amount) {
        currentPointBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0) {
            ReloadScene();
        }
    }

    public void WithdrawPoints(int amount) {
        currentPointBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentPointBalance < 0) {
            ReloadScene();
        }
    }

    void UpdateDisplay() {
        displayBalance.text = "Gold: " + currentBalance;
        displayPointBalance.text = "Points: " + currentPointBalance;
    }

    void ReloadScene() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
