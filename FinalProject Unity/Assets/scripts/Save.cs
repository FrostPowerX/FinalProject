using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeaponSave
{
    public string name;
    public int ammo;
}

[System.Serializable]
public struct EnemysSave
{
    public Vector3 position;
    public Quaternion rotation;

    public float health;
    public float maxHealth;

    public int weapon;

    public bool isAlive;
}

[System.Serializable]
public struct PlayerSaves
{
    // Stadistics of Player

    public Vector3 position;
    public Quaternion rotation;

    public float health;
    public float maxHealth;
    public float shield;
    public float maxShield;

    public string Name;
    public float Duration;
    public int Level;

    // Equipament

    public WeaponSave primary;
    public WeaponSave secundary;
    public WeaponSave mele;

    public int weaponEquiped;

    public int ammoRifle;
    public int ammoPistol;
}
