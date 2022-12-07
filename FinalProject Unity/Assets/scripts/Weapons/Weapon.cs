using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [Header("Referencia")]
    [SerializeField] WeaponSO reference;

    [Header("Basico")]
    [SerializeField] string _name;
    [SerializeField] string description;

    [Header("Estadisticas")]
    [SerializeField] float damage;
    [SerializeField] float ammo;
    [SerializeField] float maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] float distance;
    [SerializeField] float cooldown;

    [Header("Caracteristicas")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject prefab;
    [SerializeField] Image icon;

    float _cooldown;
    float _reloadTime;

    bool reloading;

    public float Damage { get { return damage; } }
    public float Ammo { get { return ammo; } }
    public float MaxAmmo { get { return maxAmmo; } }
    public float MaxDistance { get { return distance; } }

    public bool Reloading { get { return reloading; } }

    private void Start()
    {
        ammo = maxAmmo;

        _cooldown = 0;
        _reloadTime = 0;
        reloading = false;

        Init();
    }

    private void Update()
    {
        _cooldown = (_cooldown <= 0) ? 0 : _cooldown -= Time.deltaTime;
        _reloadTime = (_reloadTime <= 0 && reloading) ? 0 : _reloadTime -= Time.deltaTime;

        if (reloading && _reloadTime <= 0)
        {
            ammo = (ammo == maxAmmo) ? ammo + 1: ammo = maxAmmo;
            _reloadTime = reloadTime;
            reloading = false;
        }
    }

    private void Init()
    {
        _name = reference._name;
        description = reference.description;
        damage = reference.damage;
        ammo = reference.ammo;
        maxAmmo = reference.maxAmmo;
        distance = reference.distance;
        reloadTime = reference.reloadTime;
        cooldown = reference.cooldown;

        icon = reference.icon;
    }

    public void RayShoot(GameObject point)
    {
        if (ammo <= 0) return;
        if (_cooldown <= 0) return; 

        RaycastHit hit;
        Ray ray = new Ray(point.transform.position, point.transform.forward);
        if (Physics.Raycast(ray, out hit, distance))
        {
            

            if (hit.transform.GetComponent<HealthSystem>() == null) return;
            HealthSystem target = hit.transform.GetComponent<HealthSystem>();
            target.TakeDamage(damage);
        }

        _cooldown = cooldown;
    }
    public void Reload()
    {
        if (reloading) return;
        if (ammo == maxAmmo + 1) return;

        reloading = true;
    }
    public string Description()
    {
        string desc = 
            $"Nombre: {_name}" +
            $"Daño: {damage}" +
            $"Cargador: {maxAmmo}" +
            $"" +
            $"Tiempo de recarga: {reloadTime}" +
            $"Distancia Efectiva: {distance}" +
            $"" +
            $"" +
            $"{description}";

        return desc;
    }
}
