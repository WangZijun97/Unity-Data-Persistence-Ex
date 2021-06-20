using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton implementation
    public static GameManager Instance
    { get; private set; }

    public string userName;

    private Func<string> GenSaveFilePath;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        GenSaveFilePath = () => Application.persistentDataPath + "/savedata.json";
        LoadDataFromDisc();
    }

    [Serializable]
    class SaveData
    {
        public string lastUserName;
    }

    public void SaveDataToDisc()
    {
        Debug.Log("saving");
        SaveData data = new SaveData();
        data.lastUserName = Instance.userName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GenSaveFilePath(), json);
    }

    public void LoadDataFromDisc()
    {
        if (!File.Exists(GenSaveFilePath()))
        {
            return;
        }

        Debug.Log("loading");
        string json = File.ReadAllText(GenSaveFilePath());
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Instance.userName = data.lastUserName;
    }
}
