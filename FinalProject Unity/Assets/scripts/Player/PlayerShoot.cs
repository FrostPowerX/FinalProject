using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Animator anim;

    [SerializeField] GameObject[] showWeapons;
    [SerializeField] Weapon[] weapons;
    [SerializeField] Weapon currentWeapon;

    [SerializeField] int ammoRifle;
    [SerializeField] int ammoPistol;
    [SerializeField] float maxDistance;

    [SerializeField] Image barLife;
    [SerializeField] GameObject panel;

    [SerializeField] bool animatorEnabled;

    Controlls controlls;
    Controlls.OnFootActions onFoot;

    public Weapon[] Weapons { get { return weapons; } }
    public Weapon Weapon { get { return currentWeapon; } }
    public int AmmoRifle { get { return ammoRifle; } set { ammoRifle = value; } }
    public int AmmoPistol { get { return ammoPistol; } set { ammoPistol = value; } }

    bool shoot;
    bool onMenu;

    void Start()
    {
        controlls = new Controlls();
        onFoot = controlls.OnFoot;

        onFoot.Enable();

        weapons = new Weapon[3];

        anim.enabled = animatorEnabled;

        if (barLife == null) barLife = UIManager.Instance.GetEnemyBarFill();
        if (panel == null) panel = UIManager.Instance.GetPanelEnemy();
    }
    void Update()
    {
        if (onMenu) return;

        Inputs();

        if (anim.enabled) anim.SetBool("OnShoot", shoot);
    }
    private void FixedUpdate()
    {
        LookAndShoot();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Weapon target = collision.gameObject.GetComponent<Weapon>();
            if (!target.Pickeable) return;
            if (EquipWeapon(target.Name)) Destroy(target.gameObject);
        }
    }

    private void Inputs()
    {
        shoot = onFoot.Shoot.IsPressed() ? true : false;

        if (currentWeapon != null) currentWeapon.Shooting = shoot;
        if (onFoot.Weapon1.triggered) SelectWeapon(0, false);
        if (onFoot.Weapon2.triggered) SelectWeapon(1, false);
        if (onFoot.Weapon3.triggered) SelectWeapon(2, false);
        if (onFoot.DropWeapon.triggered) DropWeapon();
        if (onFoot.Reload.triggered && currentWeapon != null)
        {
            switch (currentWeapon.Type)
            {
                case WeaponType.Primary:
                    ammoRifle = currentWeapon.Reload(ammoRifle);
                    break;

                case WeaponType.Secondary:
                    ammoPistol = currentWeapon.Reload(ammoPistol);
                    break;

                default:
                    currentWeapon.Reload(0);
                    break;
            }
        }
    }
    private void LookAndShoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.DrawRay(cam.transform.position, ray.direction * hit.distance, Color.red);

            if (hit.transform.GetComponent<HealthSystem>())
            {
                panel.SetActive(true);
                HealthSystem target = hit.transform.GetComponent<HealthSystem>();

                barLife.fillAmount = target.Health / target.MaxHealth;
            }
            else
            {
                panel.SetActive(false);
            }
        }
        else
        {
            panel.SetActive(false);
        }

        if (shoot && currentWeapon != null)
        {
            ReloadNoAmmo();
            if (currentWeapon.Reloading) return;
            currentWeapon.RayShoot(cam.gameObject);
        }
    }
    private void SelectWeapon(int num, bool OnTake)
    {
        switch (num)
        {
            case 0:
                if (currentWeapon == null)
                {
                    if (weapons[0] == null) return;

                    currentWeapon = weapons[0];
                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (weapons[0].Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (OnTake) return;
                    if (weapons[0] == null) return;

                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (currentWeapon.Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(false);
                    }

                    currentWeapon = weapons[0];
                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (weapons[0].Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(true);
                    }
                }
                break;

            case 1:
                if (currentWeapon == null)
                {
                    if (weapons[1] == null) return;

                    currentWeapon = weapons[1];
                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (weapons[1].Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (OnTake) return;
                    if (weapons[1] == null) return;

                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (currentWeapon.Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(false);
                    }

                    currentWeapon = weapons[1];
                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (weapons[1].Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(true);
                    }
                }
                break;

            case 2:
                if (currentWeapon == null)
                {
                    if (weapons[2] == null) return;

                    currentWeapon = weapons[2];
                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (weapons[2].Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (OnTake) return;
                    if (weapons[2] == null) return;

                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (currentWeapon.Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(false);
                    }

                    currentWeapon = weapons[2];
                    for (int i = 0; i < showWeapons.Length; i++)
                    {
                        if (weapons[2].Name == showWeapons[i].name)
                            showWeapons[i].gameObject.SetActive(true);
                    }
                }
                break;
        }
        if (currentWeapon == null) return;
    }
    private bool EquipWeapon(string name)
    {
        for (int i = 0; i < showWeapons.Length; i++)
        {
            if (showWeapons[i].name == name)
            {
                Weapon target = showWeapons[i].GetComponent<Weapon>();

                switch (target.Type)
                {
                    case WeaponType.Primary:
                        if (weapons[0] == null)
                        {
                            weapons[0] = target;
                            SelectWeapon(0, true);
                            return true;
                        }
                        break;

                    case WeaponType.Secondary:
                        if (weapons[1] == null)
                        {
                            weapons[1] = target;
                            SelectWeapon(1, true);
                            return true;
                        }
                        break;

                    case WeaponType.Mele:
                        if (weapons[2] == null)
                        {
                            weapons[2] = target;
                            SelectWeapon(2, true);
                            return true;
                        }
                        break;
                }
                return false;
            }
        }
        return false;
    }
    private void DropWeapon()
    {
        if (currentWeapon == null) return;
        for (int i = 0; i < showWeapons.Length; i++)
        {
            if (showWeapons[i] != null)
                if (currentWeapon.Name == showWeapons[i].name)
                {
                    showWeapons[i].gameObject.SetActive(false);
                    break;
                }
        }
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
                if (currentWeapon.Name == weapons[i].Name)
                {
                    weapons[i] = null;
                    break;
                }
        }

        GameObject instantiated = Instantiate(currentWeapon.DropObjt, cam.transform.position, cam.transform.rotation);
        instantiated.GetComponent<Weapon>().Drop(currentWeapon);

        currentWeapon = null;
    }
    private void ReloadNoAmmo()
    {
        switch (currentWeapon.Type)
        {
            case WeaponType.Primary:
                if (currentWeapon.Ammo <= 0) ammoRifle = currentWeapon.Reload(ammoRifle);
                break;
            case WeaponType.Secondary:
                if (currentWeapon.Ammo <= 0) ammoPistol = currentWeapon.Reload(ammoPistol);
                break;

            default:
                break;
        }
    }

    public int WeaponEquipedIndex()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == null) break;
            if (currentWeapon.Name == weapons[i].Name) return i;
        }

        return -1;
    }
    public void LoadData(WeaponSave primary, WeaponSave secundary, WeaponSave mele, int equiped)
    {
        EquipWeapon(primary.name);
        EquipWeapon(secundary.name);
        EquipWeapon(mele.name);

        if (weapons[0] != null) weapons[0].Ammo = primary.ammo;
        if (weapons[1] != null) weapons[1].Ammo = secundary.ammo;
        if (weapons[2] != null) weapons[2].Ammo = mele.ammo;

        SelectWeapon(equiped, false);
    }
    public void OnMenu(bool value) => onMenu = value;
}
