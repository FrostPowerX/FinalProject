using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum PathSaves
{
    GamseSave,
    SettingsSave
}

[System.Serializable]
public struct GameSave
{
    public EnemysSave[] enemySave;
    public PlayerSaves playerSave;
    public Scene sceneSave;
}

public class SaveManager : MonoBehaviour
{
    static SaveManager _instance;
    public static SaveManager Instance { get { return _instance; } }

    private GameSave gameSave;
    private List<GameSave> gameSaveList;

    public PlayerSettings _settings;

    public EnemysSave[] enemysSaves;
    public PlayerSaves playerSaves;
    public Scene scene;

    [SerializeField] string pathSettingsSave;
    [SerializeField] string pathGameSave;

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

    private void LoadSettings()
    {
        if (File.Exists(Application.dataPath + pathSettingsSave))
        {
            string playerSettings = File.ReadAllText(Application.dataPath + pathSettingsSave);
            _settings = JsonUtility.FromJson<PlayerSettings>(playerSettings);
            print("Load Succes!");
            return;
        }
        print("Fail to load settings! The file dosnt exist or corrupt!");
    }
    public void SaveSettings()
    {
        string playerSettings = JsonUtility.ToJson(_settings);
        File.WriteAllText(Application.dataPath + pathSettingsSave, playerSettings);
        print("Save settings Succes!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.dataPath + pathGameSave))
        {
            string gameSave = File.ReadAllText(Application.dataPath + pathGameSave);
            this.gameSave = JsonUtility.FromJson<GameSave>(gameSave);

            playerSaves = this.gameSave.playerSave;
            enemysSaves = this.gameSave.enemySave;
            scene = this.gameSave.sceneSave;

            print("Load GameSave Succes!");
            return;
        }
        print("Fail to load GameSave!");
    }
    public void SaveGame()
    {
        this.gameSave.enemySave = enemysSaves;
        this.gameSave.playerSave = playerSaves;
        this.gameSave.sceneSave = scene;

        string gameSave = JsonUtility.ToJson(this.gameSave);
        File.WriteAllText(Application.dataPath + pathGameSave, gameSave);
        print("Save GameSave Succes!");
    }

    public bool ExistSaveGame()
    {
        return File.Exists(Application.dataPath + pathGameSave);
    }
    public bool ExistSaveSettings()
    {
        return File.Exists(Application.dataPath + pathSettingsSave);
    }

}
