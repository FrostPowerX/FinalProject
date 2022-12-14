using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    static SaveManager _instance;
    public static SaveManager Instance { get { return _instance; } }

    public PlayerSettings _settings;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadSettings();
    }

    public void SaveSettings()
    {
        string playerSettings = JsonUtility.ToJson(_settings);
        File.WriteAllText(Application.dataPath + "/playerSettings.json", playerSettings);
        print("Save settings Succes!");
    }
    private void LoadSettings()
    {
        if (File.Exists(Application.dataPath + "/playerSettings.json"))
        {
            string playerSettings = File.ReadAllText(Application.dataPath + "/playerSettings.json");
            _settings = JsonUtility.FromJson<PlayerSettings>(playerSettings);
            print("Load Succes!");
            return;
        }
        print("Fail to load settings!");
    }
}
