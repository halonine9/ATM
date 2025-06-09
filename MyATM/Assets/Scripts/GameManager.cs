using TMPro;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public UserData userData;
    
    [SerializeField] private TextMeshProUGUI cashtext;
    [SerializeField] private TextMeshProUGUI balancetext;
    
    [SerializeField] private string userName;
    [SerializeField] private float userBalance;
    [SerializeField] private float userCash;

    private string savePath;
    
    void Awake()
    {
        instance = this;
        savePath = Application.persistentDataPath + "/user.json";
        userData = new UserData(userName, userBalance, userCash);
    }
    void Start()
    {
        LoadUserData();
        SaveUserData();
        Refresh();
    }

    public void Refresh()
    {
        cashtext.text = userData.GetCash().ToString("N0");
        balancetext.text = userData.GetBalance().ToString("N0");
    }
    
    public void SaveUserData()
    {
        if (userData == null) return;

        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
    }
    
    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            
            userName = userData.GetUserName();
            userCash = userData.GetCash();
            userBalance = userData.GetBalance();
        }
    }
}
