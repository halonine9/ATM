
using TMPro;
using UnityEngine;

public class InputUI : MonoBehaviour
{
    [Header("로그인")]
    [SerializeField] private TMP_InputField loginId;
    [SerializeField] private TMP_InputField loginPs;
    [Header("회원가입")]
    [SerializeField] private TMP_InputField signUpId;
    [SerializeField] private TMP_InputField signUpName;
    [SerializeField] private TMP_InputField signUpPs;
    [SerializeField] private TMP_InputField signUpPsc;
    
   
    
    public void OnClickLogin()
    {
        GameManager.instance.Login(loginId.text, loginPs.text);
    }

    public void OnClickSignUp()
    {
        if (string.IsNullOrWhiteSpace(signUpId.text) ||
            string.IsNullOrWhiteSpace(signUpName.text) ||
            string.IsNullOrWhiteSpace(signUpPs.text) ||
            string.IsNullOrWhiteSpace(signUpPsc.text))
        {
            GameManager.instance.errortext.text = GameManager.instance.nullError;
            GameManager.instance.Errorpopup.SetActive(true);
            return;
        }
        if (signUpPs.text != signUpPsc.text)
        {
            GameManager.instance.errortext.text = GameManager.instance.nullError;
            GameManager.instance.Errorpopup.SetActive(true);
            return;
        }

        GameManager.instance.SignUp(signUpId.text, signUpPs.text, signUpName.text);
    }
}