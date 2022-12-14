using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
    Primary,
    Secondary,
    Mele
}

public class Weapon : MonoBehaviour
{
    [Header("Referencia")]
    [SerializeField] WeaponSO reference;

    [Header("Basico")]
    [SerializeField] string _name;
    [SerializeField] string description;

    [Header("Estadisticas")]
    [SerializeField] int ammo;
    [SerializeField] int maxAmmo;
    [SerializeField] float damage;
    [SerializeField] float reloadTime;
    [SerializeField] float distance;
    [SerializeField] float cooldown;
    [SerializeField] float dispersion;

    [Header("Caracteristicas")]
    [SerializeField] WeaponType weaponType;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject prefab;
    [SerializeField] Sprite icon;
    [SerializeField] GameObject hitPoint;
    [SerializeField] bool isDroped;

    float _cooldown;
    float _reloadTime;
    [SerializeField] float _pickCooldown;

    bool reloading;
    bool shooting;
    [SerializeField] bool pickeable;

    Animator animator;

    public string Name { get { return _name; } }

    public float Damage { get { return damage; } }
    public int Ammo { get { return ammo; } }
    public int MaxAmmo { get { return maxAmmo; } }
    public float MaxDistance { get { return distance; } }

    public WeaponType Type { get { return weaponType; } }
    public GameObject DropObjt { get { return prefab; } }

    public bool Pickeable { get { return pickeable; } }
    public bool Reloading { get { return reloading; } }
    public bool Shooting { get { return shooting; } set { shooting = value; } }

    private void Awake()
    {
        Init();

        if (!isDroped) gameObject.SetActive(false);
    }

    private void Start()
    {
        ammo = maxAmmo;

        _cooldown = 0;
        _reloadTime = 0;
        reloading = false;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _cooldown = (_cooldown <= 0) ? 0 : _cooldown -= Time.deltaTime;
        _reloadTime = (_reloadTime <= 0 && reloading) ? 0 : _reloadTime -= Time.deltaTime;
        _pickCooldown = (_pickCooldown <= 0) ? 0 : _pickCooldown -= Time.deltaTime;

        AnimationController();

        if (reloading && _reloadTime <= 0)
        {            
            reloading = false;
        }
        if (_pickCooldown <= 0 && pickeable == false) pickeable = true;
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
        dispersion = reference.dispersion;

        weaponType = reference.weaponType;
        icon = reference.icon;
        hitPoint = reference.hitPoint;
        prefab = reference.prefab;
    }
    private void AnimationController()
    {
        if (animator == null) return;

        if (ammo > 0 && !reloading) animator.SetBool("Shooting", shooting);
        else if (ammo <= 0) animator.SetBool("Shooting", false);
    }

    public void RayShoot(GameObject point)
    {
        if (weaponType != WeaponType.Mele)
        {
            if (ammo <= 0) return;
            if (reloading) return;
        }
        if (_cooldown != 0) return;

        ammo--;

        RaycastHit hit;
        Ray ray = new Ray(point.transform.position, point.transform.forward);
        if (Physics.Raycast(ray, out hit, distance))
        {         
            if (hit.transform.GetComponent<HealthSystem>() == null)
            {
                if (hitPoint != null) Instantiate(hitPoint, hit.point, hit.transform.rotation, hit.transform);
            }
            else
            {
                HealthSystem target = hit.transform.GetComponent<HealthSystem>();
                target.TakeDamage(damage);
            }
        }

        _cooldown = cooldown;
    }
    public void RayShoot(GameObject point, Vector3 targetPoint)
    {
        if (weaponType != WeaponType.Mele)
        {
            if (ammo <= 0) return;
            if (reloading) return;
        }
        if (_cooldown != 0) return;

        ammo--;

        RaycastHit hit;
        Ray ray = new Ray(point.transform.position, targetPoint.normalized);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.GetComponent<HealthSystem>() == null)
            {
                if (hitPoint != null) Instantiate(hitPoint, hit.point, hit.transform.rotation, hit.transform);
            }
            else
            {
                HealthSystem target = hit.transform.GetComponent<HealthSystem>();
                target.TakeDamage(damage);
            }
        }

        _cooldown = cooldown;
    }

    public int Reload(int ammo)
    {
        if (reloading) return ammo;
        if (weaponType == WeaponType.Mele) return ammo;
        if (ammo <= 0) return ammo;
        if (this.ammo == maxAmmo) return ammo;

        int ammoNeed = maxAmmo - this.ammo;

        if (ammo >= ammoNeed)
        {
            ammo -= ammoNeed;
            this.ammo += ammoNeed;
        }
        else
        {
            this.ammo += ammo;
            ammo = 0;
        }

        _reloadTime = reloadTime;
        reloading = true;
        return ammo;
    }
    public void Drop(Weapon replace)
    {
        ammo = replace.ammo;

        _pickCooldown = 2f;
        pickeable = false;
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
