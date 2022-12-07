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
    public float damage;
    public float ammo;
    public float maxAmmo;
    public float reloadTime;
    public float distance;
    public float cooldown;

    [Header("Caracteristicas")]
    public Image icon;
}
