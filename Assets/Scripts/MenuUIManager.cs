using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private InputField userNameInput;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance)
        {
            userNameInput.text = GameManager.Instance.userName;
        }
        
    }

    public void UpdateUserName()
    {
        GameManager.Instance.userName = userNameInput.text;
    }

    public void StartGame()
    {
        GameManager.Instance.SaveDataToDisc();
        SceneManager.LoadScene("Main");
    }
}
