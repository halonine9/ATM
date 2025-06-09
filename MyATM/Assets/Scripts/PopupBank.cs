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
  [SerializeField] private TMP_InputField inputtargetName;
  [SerializeField] private TMP_InputField inputRemittance;
  [Header("errorText")]
  [SerializeField] public TextMeshProUGUI errortext;
  [SerializeField] private string lackError;
  [SerializeField] private string notfoundError;
  [SerializeField] public string nullError;
  public void RemittanceMoney()
  {
    string text = inputRemittance.text;
    string targetUserName = inputtargetName.text;
    
    float.TryParse(text, out float amount);
    
    UserData sender = GameManager.instance.userData;
    UserData recipient = GameManager.instance.GetUserData(targetUserName);
    
    if (sender.GetBalance() < amount)
    {
      errortext.text = lackError;
      panel.SetActive(true);
      return;
    }

    if (recipient == null)
    {
      errortext.text = notfoundError;
      panel.SetActive(true);
      return;
    }

    if (string.IsNullOrWhiteSpace(inputtargetName.text) ||
        string.IsNullOrWhiteSpace(inputRemittance.text))
    {
      errortext.text = nullError;
      panel.SetActive(true);
      return;
    }

    sender.SetBalance(sender.GetBalance() - amount);
    recipient.SetBalance(recipient.GetBalance() + amount);
    
    GameManager.instance.SaveUserData();
    GameManager.instance.Refresh();
  }

  public void InputFieldMoney(bool isMode)
  {
      string text = isMode ? inputDeposit.text : inputWithdraw.text;
      float.TryParse(text, out float amount);
      if(isMode) DepositMoney(amount);
      else WithdrawMoney(amount);
  }

  public void DepositMoney(float amount)
  {
    if (GameManager.instance.userData.GetCash() < amount)
    {
      panel.SetActive(true);
      return;
    }
    Counting(amount);
  }

  public void WithdrawMoney(float amount)
  {
    if (GameManager.instance.userData.GetBalance() < amount)
    {
      panel.SetActive(true);
      return;
    }

    amount = -amount;
    Counting(amount);
  }
  
  void Counting(float amount)
  {
    float deposit = GameManager.instance.userData.GetCash() - amount;
    Debug.Log(deposit);
    float withdraw = GameManager.instance.userData.GetBalance() + amount;
    Debug.Log(withdraw);
    GameManager.instance.userData.SetCash(deposit);
    GameManager.instance.userData.SetBalance(withdraw);
    
    GameManager.instance.SaveUserData();
    GameManager.instance.Refresh();
  }
}
