using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    EnemysSave[] enemysSaves;
    GameObject[] enemys;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        enemys = new GameObject[gameObject.transform.childCount];
        enemysSaves = new EnemysSave[enemys.Length];

        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public void LoadEnemys()
    {
        enemysSaves = SaveManager.Instance.enemysSaves;

        for (int i = 0; i < enemysSaves.Length; i++)
        {
            HealthSystem enemyhealth = enemys[i].GetComponent<HealthSystem>();
            Transform enemytrans = enemys[i].GetComponent<Transform>();
            EnemyShoot enemyShoot = enemys[i].GetComponent<EnemyShoot>();

            if (!enemysSaves[i].isAlive) enemyhealth.Kill();

            enemytrans.position = enemysSaves[i].position;
            enemytrans.rotation = enemysSaves[i].rotation;

            enemyhealth.SetHealth(enemysSaves[i].health);
            enemyhealth.SetMaxHealth(enemysSaves[i].maxHealth);

            enemyShoot.EquipWeapon(enemysSaves[i].weapon);
        }
    }
    public void SaveEnemys()
    {
        for(int i = 0; i < enemysSaves.Length; i++)
        {
            HealthSystem enemyhealth = enemys[i].GetComponent<HealthSystem>();
            Transform enemytrans = enemys[i].GetComponent<Transform>();
            EnemyShoot enemyShoot = enemys[i].GetComponent<EnemyShoot>();

            enemysSaves[i].position = enemytrans.position;
            enemysSaves[i].rotation = enemytrans.rotation;

            enemysSaves[i].isAlive = enemyhealth.IsAlive;
            enemysSaves[i].health = enemyhealth.Health;
            enemysSaves[i].maxHealth = enemyhealth.MaxHealth;

            enemysSaves[i].weapon = enemyShoot.GetWeaponIndex();
        }

        SaveManager.Instance.enemysSaves = enemysSaves;
    }
}
