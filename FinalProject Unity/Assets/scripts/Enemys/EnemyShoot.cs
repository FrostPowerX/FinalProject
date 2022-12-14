using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject fakeHead;
    [SerializeField] GameObject[] weapons;

    [SerializeField] Weapon currentWeapon;
    [SerializeField] EnemyMovement movement;

    [SerializeField] int ammo;

    [SerializeField] float maxDistance;

    [SerializeField] float minTimeToShoot;
    [SerializeField] float maxTimeToShoot;

    [SerializeField] float minShootingTime;
    [SerializeField] float maxShootingTime;

    [SerializeField] float shootingTime;
    [SerializeField] float shootCooldown;

    [SerializeField] bool shooting;

    Vector3 target;

    bool onView;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<EnemyMovement>()) movement = GetComponent<EnemyMovement>();

        int index = Random.Range(0, weapons.Length);
        EquipWeapon(index);

        if (currentWeapon != null && currentWeapon.Type != WeaponType.Mele) maxDistance = currentWeapon.MaxDistance + (currentWeapon.MaxDistance * 0.2f);
        else maxDistance = 35f;

        movement.FollowDistance(currentWeapon.MaxDistance * 0.9f);

        ammo = 50000;
    }

    // Update is called once per frame
    void Update()
    {
        shootingTime = (shootingTime <= 0) ? 0 : shootingTime -= Time.deltaTime;
        shootCooldown = (shootCooldown <= 0) ? 0 : shootCooldown -= Time.deltaTime;

        target = GameManager.Instance.GetPlayerPos() - transform.position;

        movement.OnView(onView);

        ShootingController();
    }

    private void FixedUpdate()
    {
        VerifyContact();
        Look();
    }

    private void ShootingController()
    {
        shooting = (shootingTime > 0) ? true : false;

        if (shootCooldown <= 0)
        {
            shootingTime = Random.Range(minShootingTime, maxShootingTime);
            shootCooldown = Random.Range(minTimeToShoot, maxTimeToShoot);
        }

        if (currentWeapon.Ammo <= 0 && currentWeapon.Type != WeaponType.Mele) currentWeapon.Reload(ammo);
    }
    private void VerifyContact()
    {
        Ray ray = new Ray(fakeHead.transform.position, target.normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.DrawRay(fakeHead.transform.position, ray.direction * hit.distance, Color.green);

            onView = (hit.transform.tag == "Player") ? true : false;
        }
    }
    private void Look()
    {
        Ray ray = new Ray(fakeHead.transform.position, target.normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, currentWeapon.MaxDistance))
        {
            Debug.DrawRay(fakeHead.transform.position, ray.direction * hit.distance, Color.red);

            Shoot();
        }
    }
    private void Shoot()
    {
        if (!shooting) return;

        currentWeapon.RayShoot(fakeHead, target);
    }
    private void EquipWeapon(int index)
    {
        currentWeapon = weapons[index].GetComponent<Weapon>();
        weapons[index].gameObject.SetActive(true);
    }
}
