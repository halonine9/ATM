using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
  public string userId;
  public string userPassword;
  public string userName;
  public float userBalance;
  public float userCash;

  public UserData(string id, string password, string name, float balance, float cash)
  {
    userId = id;
    userPassword = password;
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
