using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Text userNameInput;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.userName = "Name";
    }

    public void UpdateUserName()
    {
        GameManager.Instance.userName = userNameInput.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
