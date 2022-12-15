using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;

    Controlls controls;
    Controlls.OnFootActions onFoot;
    public static UIManager Instance { get { return _instance; } }

    PlayerSettings _playerSettings;
    PlayerSaves _gameSaves;

    [SerializeField] GameObject _player;

    [Header("HUD")]
    [SerializeField] TMP_Text _ammo;
    [SerializeField] TMP_Text _granadesAmmo;
    [SerializeField] TMP_Text messageDisplayDatabase;
    [SerializeField] Image _BarFillEnemy;
    [SerializeField] Image _BarFillPlayer;
    [SerializeField] GameObject _PanelEnemy;

    [Header("")]
    [SerializeField] Sprite[] _crossHireList;
    [SerializeField] Image _crossHireUse;
    [SerializeField] Image _demostrationCross;
    [SerializeField] TMP_Dropdown _selectCross;

    [Header("UI")]
    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _optionsPanel;
    [SerializeField] GameObject _losePanel;
    [SerializeField] Material _UIMaterial;

    [Header("")]
    [SerializeField] Slider _volume;
    [SerializeField] Slider loadingBar;

    [Header("")]
    [SerializeField] Slider _brightness;
    [SerializeField] TMP_Dropdown _quality;
    [SerializeField] Toggle _fullscreen;

    [Header("")]
    [SerializeField] TMP_InputField _sensX;
    [SerializeField] TMP_InputField _sensY;
    [SerializeField] Toggle _InvertMode;

    [Header("")]
    [SerializeField] Slider[] _RGB;

    [Header("Others")]
    [SerializeField] bool _destroyOnLoad;
    [SerializeField] bool _isMainMenu;
    [SerializeField] float messageDisplayLength;
    [SerializeField] float autoSaveTime;

    private int loadSceneIndex;

    float _autoSave;

    bool onLoad;
    bool loadingData;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            //if (!_destroyOnLoad) DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        controls = new Controlls();
        onFoot = controls.OnFoot;

        onFoot.Enable();

        loadingData = EventManager.loadGame;
        if (GameManager.Instance != null) _player = GameManager.Instance.Player;

        _autoSave = autoSaveTime;

        LoadSettings();
    }

    private void Update()
    {
        _autoSave = (_autoSave > 0 && !_isMainMenu) ? _autoSave - Time.deltaTime : 0;

        if (onFoot.Back.triggered && _isMainMenu == false && _player.GetComponent<HealthSystem>().IsAlive)
        {
            SwitchMenu();
        }
        if (loadingData) LoadPlayerData();

        if (_autoSave <= 0 && !_isMainMenu)
        {
            SaveGame();
            _autoSave = autoSaveTime;
        }
    }

    public void LoadSettings()
    {
        if (SaveManager.Instance == null) return;
        onLoad = true;
        _playerSettings = SaveManager.Instance._settings;

        _volume.value = _playerSettings._volume;
        AudioListener.volume = _volume.value;

        _brightness.value = _playerSettings._brightness;

        _quality.value = _playerSettings._quality;
        QualitySettings.SetQualityLevel(_quality.value);

        _selectCross.value = _playerSettings._CrossHire;
        _demostrationCross.sprite = _crossHireList[_selectCross.value];
        if (!_isMainMenu) _crossHireUse.sprite = _crossHireList[_selectCross.value];

        _fullscreen.isOn = _playerSettings._fullscreen;
        Screen.fullScreen = _fullscreen.isOn;

        _sensX.text = _playerSettings._sensX.ToString();
        _sensY.text = _playerSettings._sensY.ToString();
        if (!_isMainMenu) _player.GetComponent<PlayerLoock>().SensChange(_playerSettings._sensX, _playerSettings._sensY);
        if (!_isMainMenu) _player.GetComponent<PlayerLoock>().InvertMode(_playerSettings._invertMode);

        _UIMaterial.color = new Color(_playerSettings._R, _playerSettings._G, _playerSettings._B);
        _RGB[0].value = _playerSettings._R;
        _RGB[1].value = _playerSettings._G;
        _RGB[2].value = _playerSettings._B;

        print("Se cargaron los settings!");
        onLoad = false;
    }
    public void SaveSettings()
    {
        SaveManager.Instance._settings = _playerSettings;
        SaveManager.Instance.SaveSettings();
    }

    public void SetVolume()
    {
        _playerSettings._volume = _volume.value;
        AudioListener.volume = _volume.value;
    }
    public void SetBrightness()
    {
        _playerSettings._brightness = _brightness.value;
    }
    public void SetQuality()
    {
        _playerSettings._quality = _quality.value;
        QualitySettings.SetQualityLevel(_quality.value);
    }
    public void SetUIColor()
    {
        if (onLoad) return;

        float R = _RGB[0].value;
        float G = _RGB[1].value;
        float B = _RGB[2].value;

        _UIMaterial.color = new Color(R,G,B);
        _playerSettings._R = R;
        _playerSettings._G = G;
        _playerSettings._B = B;
    }
    public void SetFullScreen()
    {
        _playerSettings._fullscreen = _fullscreen.isOn;
        Screen.fullScreen = _fullscreen.isOn;
    }
    public void SetCrossHire()
    {
        if (!_isMainMenu) _crossHireUse.sprite = _crossHireList[_selectCross.value];
        _demostrationCross.sprite = _crossHireList[_selectCross.value];
        _playerSettings._CrossHire = _selectCross.value;
    }
    public void SetSens()
    {
        float sensX = float.Parse(_sensX.text, CultureInfo.InvariantCulture.NumberFormat);
        float sensY = float.Parse(_sensY.text, CultureInfo.InvariantCulture.NumberFormat);

        if (!_isMainMenu) _player.GetComponent<PlayerLoock>().SensChange(sensX, sensY);
        _playerSettings._sensX = sensX;
        _playerSettings._sensY = sensY;
    }
    public void SetInvertMode()
    {
        if (!_isMainMenu) _player.GetComponent<PlayerLoock>().InvertMode(_InvertMode.isOn);
        _playerSettings._invertMode = _InvertMode.isOn;
    }
    public void SetAmmo(int currentAmmo, int maxAmmo, int ammo, bool active)
    {
        _ammo.text = $"{currentAmmo} / {maxAmmo} : {ammo}";
        _ammo.gameObject.SetActive(active);
    }
    public void SetPanelLoseActive(bool value)
    {
        _losePanel.SetActive(value);
    }

    public void NewGame()
    {
        loadSceneIndex = 1;
        _gameSaves.Level = 1;
        Time.timeScale = 1;
        SoundManager.Instance.StopMusicMenu();
        SoundManager.Instance.PlayMusicGame();
        StartCoroutine(LoadAsynchronously(loadSceneIndex));
    }
    public void SaveGame()
    {
        PlayerShoot player;

        if (GameManager.Instance != null)
        {
            player = GameManager.Instance.Player.GetComponent<PlayerShoot>();
        }
        else player = null;

        GameObject[] enemys = EnemyManager.instance.Enemys;
        _gameSaves.Level = SceneManager.GetActiveScene().buildIndex;

        _gameSaves.Position = GameManager.Instance.Player.transform.position;
        _gameSaves.Rotation = GameManager.Instance.Player.transform.rotation;

        if (player.Weapons[0] != null) _gameSaves.primary.name = player.Weapons[0].Name;
        if (player.Weapons[0] != null) _gameSaves.primary.ammo = player.Weapons[0].Ammo;

        if (player.Weapons[1] != null) _gameSaves.secundary.name = player.Weapons[1].Name;
        if (player.Weapons[1] != null) _gameSaves.secundary.ammo = player.Weapons[1].Ammo;

        if (player.Weapons[2] != null) _gameSaves.mele.name = player.Weapons[2].Name;
        if (player.Weapons[2] != null) _gameSaves.mele.ammo = player.Weapons[2].Ammo;

        _gameSaves.weaponEquiped = player.WeaponEquipedIndex();

        _gameSaves.ammoRifle = player.AmmoRifle;
        _gameSaves.ammoPistol = player.AmmoPistol;

        _gameSaves.health = GameManager.Instance.Player.GetComponent<HealthSystem>().Health;
        _gameSaves.maxHealth = GameManager.Instance.Player.GetComponent<HealthSystem>().MaxHealth;

        if (enemys != null)
        {
            _gameSaves.enemys.idsDeath = new bool[enemys.Length];

            for (int i = 0; i < enemys.Length; i++)
            {
                HealthSystem enemy = enemys[i].GetComponent<HealthSystem>();
                if (!enemy.IsAlive)
                {
                    _gameSaves.enemys.idsDeath[i] = true;
                }
                else _gameSaves.enemys.idsDeath[i] = false;
            }
        }

        SaveManager.Instance._saves = _gameSaves;
        SaveManager.Instance.SaveGame();
    }
    public void LoadGame()
    {   
        if (!SaveManager.Instance.ExistSaveGame()) return;

        SoundManager.Instance.StopMusicMenu();
        SoundManager.Instance.PlayMusicGame();

        SaveManager.Instance.LoadGame();
        _gameSaves = SaveManager.Instance._saves;

        loadSceneIndex = _gameSaves.Level;
        EventManager.loadGame = true;
        StartCoroutine(LoadAsynchronously(loadSceneIndex));
    }
    public void ReloadScene()
    {
        int id = SceneManager.GetActiveScene().buildIndex;
        LoadGame();

        StartCoroutine(LoadAsynchronously(id));
    }
    public void LoadScene(int id)
    {
        if (!SaveManager.Instance.ExistSaveGame()) return;

        SoundManager.Instance.StopMusicMenu();
        SoundManager.Instance.PlayMusicGame();

        SaveManager.Instance.LoadGame();
        _gameSaves = SaveManager.Instance._saves;

        _gameSaves.Position = new Vector3(0, 1, 0);

        EventManager.loadGame = true;
        StartCoroutine(LoadAsynchronously(id));
    }


    public void MainMenu()
    {
        loadSceneIndex = 0;
        if (SoundManager.Instance != null) SoundManager.Instance.StopMusicGame();
        if (SoundManager.Instance != null) SoundManager.Instance.PlayMusicMenu();
        StartCoroutine(LoadAsynchronously(loadSceneIndex));
        Destroy(gameObject);
        Destroy(GameManager.Instance.gameObject);
    }

    public void Message(string message, float duration,Color col)
    {
        messageDisplayLength = duration;
        StartCoroutine(MessageDisplay(message, col));
    }

    public Image GetEnemyBarFill()
    {
        return _BarFillEnemy;
    }
    public GameObject GetPanelEnemy()
    {
        return _PanelEnemy;
    }
    public Image GetPlayerBarFill()
    {
        return _BarFillPlayer;
    }
    public void SwitchMenu()
    {
        if (!_menuPanel.activeSelf)
        {
            _menuPanel.SetActive(!_menuPanel.activeSelf);
            _player.GetComponent<PlayerLoock>().OnMenu(true);
            _player.GetComponent<PlayerMovement>().OnMenu(true);
            _player.GetComponent<PlayerShoot>().OnMenu(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else if (_menuPanel.activeSelf && !_optionsPanel.activeSelf)
        {
            _menuPanel.SetActive(!_menuPanel.activeSelf);
            _player.GetComponent<PlayerLoock>().OnMenu(false);
            _player.GetComponent<PlayerMovement>().OnMenu(false);
            _player.GetComponent<PlayerShoot>().OnMenu(false);
            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1f;
        }
    }
    public void ExitApplication()
    {
        Application.Quit();
    }


    private void LoadPlayerData()
    {
        SoundManager.Instance.StopMusicMenu();
        SoundManager.Instance.PlayMusicGame();

        _gameSaves = SaveManager.Instance._saves;
        PlayerShoot player = GameManager.Instance.Player.GetComponent<PlayerShoot>();
        GameManager.Instance.Player.transform.position = _gameSaves.Position;
        GameManager.Instance.Player.transform.rotation = _gameSaves.Rotation;

        player.LoadData(_gameSaves.primary, _gameSaves.secundary, _gameSaves.mele, _gameSaves.weaponEquiped);
        player.AmmoRifle = _gameSaves.ammoRifle;
        player.AmmoPistol = _gameSaves.ammoPistol;

        EnemyManager.instance.DestroyEnemysOnLoad(_gameSaves.enemys.idsDeath);

        GameManager.Instance.Player.GetComponent<HealthSystem>().SetHealth(_gameSaves.health);
        GameManager.Instance.Player.GetComponent<HealthSystem>().SetMaxHealth(_gameSaves.maxHealth);

        loadingData = false;
        EventManager.loadGame = false;
        Time.timeScale = 1;
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            //loadingBar.value = progress;

            yield return null;
        }


    }
    IEnumerator MessageDisplay(string message, Color col)
    {
        messageDisplayDatabase.color = col;
        messageDisplayDatabase.text = message;
        yield return new WaitForSeconds(messageDisplayLength);
        messageDisplayDatabase.text = "";
    }
}
