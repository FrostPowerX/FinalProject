using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReloadAmmo : MonoBehaviour
{
    [SerializeField, Range(0, 2), Tooltip("0 = AmmoRifle \n1 = AmmoPistol \n2 = Both")] int typeMuni;
    [SerializeField] TMP_Text text;
    [SerializeField] int amountAmmo;
    [SerializeField] int ammoPerCall;

    [SerializeField] float amountHealing;

    [SerializeField] float delayCharge;

    int amountGive;
    float healing;
    float _delay;

    private void Update()
    {
        _delay = (_delay > 0) ? _delay -= Time.deltaTime : 0;

        text.text = $"Municion Tipo {typeMuni}: {amountAmmo}\nCuracion: 999";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && _delay <= 0)
        {
            if (!other.GetComponent<PlayerShoot>()) return;
            PlayerShoot target = other.GetComponent<PlayerShoot>();
            HealthSystem targetHealth = other.GetComponent<HealthSystem>();
            if (amountAmmo > ammoPerCall && amountAmmo > 0)
            {
                amountGive = ammoPerCall;
                amountAmmo -= ammoPerCall;
            }
            else if (amountAmmo > 0)
            {
                amountGive = amountAmmo;
                amountAmmo = 0;
            }
            if (amountAmmo > 0)
            {
                switch (typeMuni)
                {
                    case 0:
                        target.AmmoRifle += amountGive;
                        break;

                    case 1:
                        target.AmmoPistol += amountGive;
                        break;

                    case 2:
                        target.AmmoRifle += amountGive;
                        target.AmmoPistol += amountGive;
                        break;
                }
            } 

            healing = targetHealth.Health + amountHealing;
            targetHealth.SetHealth(healing);

            _delay = delayCharge;
        }
    }
}
