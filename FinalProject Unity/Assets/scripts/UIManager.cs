using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;

    Controlls controls;
    Controlls.OnFootActions onFoot;
    public static UIManager Instance { get { return _instance; } }

    PlayerSettings _playerSettings;
    [SerializeField] GameObject _player;

    [Header("HUD")]
    [SerializeField] TMP_Text _ammo;
    [SerializeField] TMP_Text _granadesAmmo;

    [Header("")]
    [SerializeField] Sprite[] _crossHireList;
    [SerializeField] Image _crossHireUse;
    [SerializeField] Image _demostrationCross;
    [SerializeField] TMP_Dropdown _selectCross;

    [Header("UI")]
    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _optionsPanel;
    [SerializeField] Material _UIMaterial;

    [Header("")]
    [SerializeField] Slider _volume;

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

    bool onLoad;

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
    }
    private void Start()
    {
        controls = new Controlls();
        onFoot = controls.OnFoot;

        onFoot.Enable();

        LoadSettings();
    }
    private void Update()
    {
        if (onFoot.Back.triggered)
        {
            SwitchMenu();
        }
    }

    private void LoadSettings()
    {
        if (SaveManager.Instance == null) return;
        onLoad = true;
        _playerSettings = SaveManager.Instance._settings;

        _volume.value = _playerSettings._volume;
        AudioListener.volume = _volume.value;

        _brightness.value = _playerSettings._brightness;

        _quality.value = _playerSettings._quality;
        QualitySettings.SetQualityLevel(_quality.value);

        print($"{_playerSettings._R} {_playerSettings._G} {_playerSettings._B}");

        _selectCross.value = _playerSettings._CrossHire;
        _demostrationCross.sprite = _crossHireList[_selectCross.value];
        _crossHireUse.sprite = _crossHireList[_selectCross.value];

        _fullscreen.isOn = _playerSettings._fullscreen;
        Screen.fullScreen = _fullscreen.isOn;

        _sensX.text = _playerSettings._sensX.ToString();
        _sensY.text = _playerSettings._sensY.ToString();
        _player.GetComponent<PlayerLoock>().SensChange(_playerSettings._sensX, _playerSettings._sensY);

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
        _crossHireUse.sprite = _crossHireList[_selectCross.value];
        _demostrationCross.sprite = _crossHireList[_selectCross.value];
        _playerSettings._CrossHire = _selectCross.value;
    }

    public void SetSens()
    {
        float sensX = float.Parse(_sensX.text, CultureInfo.InvariantCulture.NumberFormat);
        float sensY = float.Parse(_sensY.text, CultureInfo.InvariantCulture.NumberFormat);

        _player.GetComponent<PlayerLoock>().SensChange(sensX, sensY);
        _playerSettings._sensX = sensX;
        _playerSettings._sensY = sensY;
    }

    public void SetInvertMode()
    {
        _player.GetComponent<PlayerLoock>().InvertMode(_InvertMode.isOn);
        _playerSettings._invertMode = _InvertMode.isOn;
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

    public void SetAmmo(int currentAmmo, int maxAmmo, int ammo)
    {
        _ammo.text = $"{currentAmmo} / {maxAmmo} : {ammo}";
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
