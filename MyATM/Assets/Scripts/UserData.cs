using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
  [SerializeField] private string userName;
  [SerializeField] private float userBalance;
  [SerializeField] private float userCash;

  public UserData(string name, float balance, float cash)
  {
    userName = name;
    userBalance = balance;
    userCash = cash;
  }
}
