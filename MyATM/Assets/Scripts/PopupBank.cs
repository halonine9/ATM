using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
  [SerializeField] private GameObject panel;
  [SerializeField] private TMP_InputField inputDeposit;
  [SerializeField] private TMP_InputField inputWithdraw;
  public void InputFieldMoney(bool isMode)
  {
      string text = isMode ? inputDeposit.text : inputWithdraw.text;
      float.TryParse(text, out float amount);
      if(isMode) DepositMoney(amount);
      else WithdrawMoney(amount);
  }

  public void DepositMoney(float amount)
  {
    if (GameManager.instance.userCash < amount)
    {
      panel.SetActive(true);
      return;
    }
    Counting(amount);
  }

  public void WithdrawMoney(float amount)
  {
    if (GameManager.instance.userBalance < amount)
    {
      panel.SetActive(true);
      return;
    }

    amount = -amount;
    Counting(amount);
  }

  void Counting(float amount)
  {
    GameManager.instance.userCash -= amount;
    GameManager.instance.userBalance += amount;
    GameManager.instance.Refresh();
  }
}
