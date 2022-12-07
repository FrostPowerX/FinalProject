using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Animator anim;

    [SerializeField] float damage;
    [SerializeField] float maxDistance;
    [SerializeField] float deathTime;
    float currentDeathTime;

    [SerializeField] Controlls controlls;
    [SerializeField] Controlls.OnFootActions onFoot;

    [SerializeField] Image puntero;
    [SerializeField] Image barLife;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject hitPoint;

    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        controlls = new Controlls();
        onFoot = controlls.OnFoot;

        onFoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        currentDeathTime -= Time.deltaTime;

        shoot = (onFoot.Shoot.IsPressed()) ? true : false;
        anim.SetBool("OnShoot", shoot);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.DrawRay(cam.transform.position, ray.direction * hit.distance, Color.red);

            if (shoot && currentDeathTime <= 0)
            {
                Instantiate(hitPoint, hit.point, hit.transform.rotation, hit.transform);

                if (hit.transform.GetComponent<HealthSystem>())
                    Shoot(hit.transform.GetComponent<HealthSystem>());
                
                currentDeathTime = deathTime;
            }

            if (hit.transform.GetComponent<HealthSystem>())
            {
                panel.SetActive(true);
                HealthSystem target = hit.transform.GetComponent<HealthSystem>();

                puntero.color = Color.red;

                barLife.fillAmount = target.Health / target.MaxHealth;
            }
            else
            {
                puntero.color = Color.white;
                panel.SetActive(false);
            }
        }
        else
        {
            puntero.color = Color.white;
            panel.SetActive(false);
        }
    }

    void Shoot(HealthSystem target)
    {
        target.TakeDamage(damage);
    }
}
