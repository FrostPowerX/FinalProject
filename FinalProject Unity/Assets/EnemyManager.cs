using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    [SerializeField] GameObject[] enemys;

    public GameObject[] Enemys { get { return enemys; } }

    public void DestroyEnemysOnLoad(bool[] idsDeaths)
    {
        if (enemys.Length != idsDeaths.Length) return;
        for (int i = 0; i < enemys.Length; i++)
        {
            if (idsDeaths[i]) enemys[i].GetComponent<HealthSystem>().Kill();
        }
    }
}
