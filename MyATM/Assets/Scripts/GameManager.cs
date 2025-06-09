using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.Serialization;

[System.Serializable]
public class UserDatabase
{
    public List<UserData> userDB = new List<UserData>();
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public UserData userData;
    [SerializeField] private float defaultCash;
    [SerializeField] private float defaultBalance;
    [Header("Popup")]
    [SerializeField] private GameObject Loginpopup;
    [SerializeField] private GameObject SingUppopup;
    [SerializeField] private GameObject Bankpopup;
    [SerializeField] public GameObject Errorpopup;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI nametext;
    [SerializeField] private TextMeshProUGUI cashtext;
    [SerializeField] private TextMeshProUGUI balancetext;
    [SerializeField] public TextMeshProUGUI errortext;
    [Header("errorText")]
    [SerializeField] private string loginError;
    [SerializeField] private string signupError;
    [SerializeField] public string nullError;
    
    
    
    private UserDatabase userdb = new UserDatabase();
    private string dbPath;
    
    void Awake()
    {
        instance = this;
        dbPath = Application.persistentDataPath + "/user.json";
        LoadUserData();
        Refresh();
    }

    public void Refresh()
    {
        nametext.text = userData.GetUserName();
        cashtext.text = userData.GetCash().ToString("N0");
        balancetext.text = userData.GetBalance().ToString("N0");
    }
    
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userdb, true);
        File.WriteAllText(dbPath, json);
    }
    
    public void LoadUserData()
    {
        if (File.Exists(dbPath))
        {
            string json = File.ReadAllText(dbPath);
            userdb = JsonUtility.FromJson<UserDatabase>(json);
        }
        else
        {
            userdb = new UserDatabase();
        }
    }
    
    public void Login(string id, string ps)
    {
        var user = userdb.userDB.Find(u => u.userId == id && u.userPassword == ps);
        if (user != null)
        {
            userData = user;
            Refresh();
            Bankpopup.SetActive(true);
            Loginpopup.SetActive(false);
        }
        else
        {
            Errorpopup.SetActive(true);
            errortext.text = loginError;
        }
    }
    
    public void SignUp(string id, string ps, string name)
    {
        if (userdb.userDB.Exists(u => u.userId == id))
        {
            errortext.text = signupError;
            Errorpopup.SetActive(true);
            return;
        }
        var newUser = new UserData(id, ps, name, defaultBalance, defaultCash);
        userdb.userDB.Add(newUser);
        SaveUserData();
        SingUppopup.SetActive(false);
    }
    
    public UserData GetUserData(string name)
    {
        return userdb.userDB.Find(u => u.userName == name);
    }
}
