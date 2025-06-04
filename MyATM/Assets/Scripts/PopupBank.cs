using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
  [SerializeField] private GameObject panel;

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
