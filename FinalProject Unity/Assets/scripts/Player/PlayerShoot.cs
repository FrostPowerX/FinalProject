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

    [SerializeField] Controlls controlls;
    [SerializeField] Controlls.OnFootActions onFoot;

    [SerializeField] Image puntero;
    [SerializeField] Image barLife;
    [SerializeField] GameObject panel;

    bool shoot;
    bool onMenu;

    // Start is called before the first frame update
    void Start()
    {
        controlls = new Controlls();
        onFoot = controlls.OnFoot;

        onFoot.Enable();

        weapons = new Weapon[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (onMenu) return;

        Inputs();

        anim.SetBool("OnShoot", shoot);
    }

    private void FixedUpdate()
    {
        LookAndShoot();
    }

    private void Inputs()
    {
        shoot = onFoot.Shoot.IsPressed() ? true : false;

        if (currentWeapon != null) currentWeapon.Shooting = shoot;
        if (onFoot.Weapon1.triggered) SelectWeapon(0);
        if (onFoot.Weapon2.triggered) SelectWeapon(1);
        if (onFoot.Weapon3.triggered) SelectWeapon(2);
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
            }
            UpdateUI(currentWeapon.Type);
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

        if ((shoot && currentWeapon != null) && currentWeapon.Reloading == false)
        {
            currentWeapon.RayShoot(cam.gameObject);
            UpdateUI(currentWeapon.Type);
        }
    }
    private void UpdateUI(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.Primary:
                UIManager.Instance.SetAmmo(currentWeapon.Ammo, currentWeapon.MaxAmmo, ammoRifle);
                break;

            case WeaponType.Secondary:
                UIManager.Instance.SetAmmo(currentWeapon.Ammo, currentWeapon.MaxAmmo, ammoPistol);
                break;
        }
    }
    private void SelectWeapon(int num)
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

        UpdateUI(currentWeapon.Type);
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
                            return true;
                        }
                        break;

                    case WeaponType.Secondary:
                        if (weapons[1] == null)
                        {
                            weapons[1] = target;
                            return true;
                        }
                        break;

                    case WeaponType.Mele:
                        if (weapons[2] == null)
                        {
                            weapons[2] = target;
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Weapon target = collision.gameObject.GetComponent<Weapon>();
            if (!target.Pickeable) return;
            if (EquipWeapon(target.Name)) Destroy(target.gameObject);
        }
    }

    public void OnMenu(bool value) => onMenu = value;
}
