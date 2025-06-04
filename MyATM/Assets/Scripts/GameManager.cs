using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public UserData userData;
    
    [SerializeField] private TextMeshProUGUI cashtext;
    [SerializeField] private TextMeshProUGUI balancetext;
    
    [SerializeField] private string userName;
    [SerializeField] public float userBalance;
    [SerializeField] public float userCash;

    void Awake()
    {
        instance = this;
        userData = new UserData(userName, userBalance, userCash);
    }
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        cashtext.text = userCash.ToString("N0");
        balancetext.text = userBalance.ToString("N0");
    }
}
