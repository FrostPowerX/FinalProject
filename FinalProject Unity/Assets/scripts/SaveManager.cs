using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct WeaponSave
{
    public string name;
    public int ammo;
}

[System.Serializable]
public struct EnemysSave
{
    public bool[] idsDeath;
}

[System.Serializable]
public struct PlayerSaves
{
    public string Name;
    public float Duration;
    public int Level;

    public Vector3 Position;
    public Quaternion Rotation;

    public WeaponSave primary;
    public WeaponSave secundary;
    public WeaponSave mele;

    public int weaponEquiped;

    public EnemysSave enemys;

    public int ammoRifle;
    public int ammoPistol;

    public float health;
    public float maxHealth;
}

public enum PathSaves
{
    GamseSave,
    SettingsSave
}

public class SaveManager : MonoBehaviour
{
    static SaveManager _instance;
    public static SaveManager Instance { get { return _instance; } }

    public PlayerSettings _settings;
    public PlayerSaves _saves;
    public Scene escena;

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
        print("Fail to load settings!");
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
            _saves = JsonUtility.FromJson<PlayerSaves>(gameSave);
            print("Load GameSave Succes!");
            return;
        }
        print("Fail to load GameSave!");
    }
    public void SaveGame()
    {
        string gameSave = JsonUtility.ToJson(_saves);
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
