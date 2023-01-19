using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    PlayerShoot shoot;
    HealthSystem health;

    PlayerSaves playerSave;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] GameObject prefabPlayer;
    [SerializeField] GameObject player;

    [SerializeField] int currentScore;

    public GameObject Player { get { return player; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Vector3 position = new Vector3(0, 1, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        player = Instantiate(prefabPlayer, position, rotation);

        EventManager.OnPlayerDeath += PlayerDeath;
    }

    private void Start()
    {
        shoot = player.transform.GetComponent<PlayerShoot>();
        health = player.transform.GetComponent<HealthSystem>();
    }

    public void Save()
    {
        playerSave.position = player.transform.position;
        playerSave.rotation = player.transform.rotation;

        playerSave.health = health.Health;      
        playerSave.maxHealth = health.MaxHealth;

        playerSave.ammoRifle = shoot.AmmoRifle;
        playerSave.ammoPistol = shoot.AmmoPistol;

        playerSave.primary.name = shoot.Weapons[0].name;
        playerSave.primary.ammo = shoot.Weapons[0].Ammo;

        playerSave.secundary.name = shoot.Weapons[1].name;
        playerSave.secundary.ammo = shoot.Weapons[1].Ammo;

        playerSave.mele.name = shoot.Weapons[2].name;
        playerSave.mele.ammo = shoot.Weapons[2].Ammo;

        playerSave.weaponEquiped = shoot.WeaponEquipedIndex();

        SaveManager.Instance.playerSaves = playerSave;
    }

    public void Load()
    {
        playerSave = SaveManager.Instance.playerSaves;

        health.SetHealth(playerSave.health);
        health.SetMaxHealth(playerSave.maxHealth);

        player.transform.position = playerSave.position;
        player.transform.rotation = playerSave.rotation;

        shoot.AmmoPistol = playerSave.ammoPistol;
        shoot.AmmoRifle = playerSave.ammoRifle;

        shoot.LoadData(playerSave.primary, playerSave.secundary, playerSave.mele, playerSave.weaponEquiped);
    }

    private void PlayerDeath()
    {
        UIManager.Instance.SetPanelLoseActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }
    public Vector3 GetPlayerHeadPos()
    {
        return player.transform.Find("PlayerCam").transform.position;
    }
}
