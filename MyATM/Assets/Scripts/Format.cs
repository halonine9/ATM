using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Format : MonoBehaviour
{
 [SerializeField] private Text cashtext;
 [SerializeField] private Text balancetext;
 private int cash = 100000;
 private int balance = 50000;
 void Start()
 {
  cashtext.text = cash.ToString("N0");
  balancetext.text = balance.ToString("N0");
 }
}
