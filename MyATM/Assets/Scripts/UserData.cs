using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
  public string userName;
  public float userBalance;
  public float userCash;

  public UserData(string name, float balance, float cash)
  {
    userName = name;
    userBalance = balance;
    userCash = cash;
  }
  public string GetUserName() => userName;
  public float GetBalance() => userBalance;
  public float GetCash() => userCash;
  
  public void SetCash(float newCash) => userCash = newCash;
  public void SetBalance(float newBalance) => userBalance = newBalance;
}
