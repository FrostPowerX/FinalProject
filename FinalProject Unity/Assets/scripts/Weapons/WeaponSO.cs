using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Name of Weapon", menuName = "New Weapon")]

public class WeaponSO : ScriptableObject
{
    [Header("Basico")]
    public string _name;
    public string description;

    [Header("Estadisticas")]
    public int ammo;
    public int maxAmmo;
    public float damage;
    public float reloadTime;
    public float distance;
    public float cooldown;
    public float dispersion;

    [Header("Caracteristicas")]
    public WeaponType weaponType;
    public Sprite icon;
    public GameObject hitPoint;
    public GameObject prefab;

}
