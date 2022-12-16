using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Image _barfill;

    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] float currentShield;
    [SerializeField] float maxShield;

    [SerializeField] bool isInvulnerable;
    [SerializeField] bool isPlayer;

    [SerializeField] Weapon[] weapons;
    [SerializeField] Animator animator;
    [SerializeField] EnemyMovement movement;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Collider _collider;
    [SerializeField] EnemyShoot enemyshoot;

    [SerializeField] PlayerMovement _pm;
    [SerializeField] PlayerLoock _pl;
    [SerializeField] PlayerShoot _ps;
    [SerializeField] Rigidbody _rb;

    [SerializeField] bool ragdoll;
    [SerializeField] bool isAlive;

    public float Health { get { return currentHealth; } }
    public float MaxHealth { get { return maxHealth; } }
    public bool IsInvulnerable { get { return isInvulnerable; } }
    public bool IsAlive { get { return isAlive; } }

    private void Start()
    {
        if (gameObject.GetComponent<Animator>()) animator = GetComponent<Animator>();
        if (GetComponent<EnemyMovement>()) movement = GetComponent<EnemyMovement>();
        if (GetComponent<NavMeshAgent>()) agent = GetComponent<NavMeshAgent>();
        if (GetComponent<Collider>()) _collider = GetComponent<Collider>();
        if (GetComponent<EnemyShoot>()) enemyshoot = GetComponent<EnemyShoot>();
        if (_barfill == null && isPlayer) _barfill = UIManager.Instance.GetPlayerBarFill();

        isAlive = true;

        UpdateUI();
    }

    private void OnDeath()
    {
        if (!ragdoll && !isPlayer) gameObject.SetActive(false);
        else if (ragdoll) RagdollDeath();
        else if (isPlayer) PlayerDeath();

        isAlive = false;
    }
    private void UpdateUI()
    {
        if (_barfill == null) return;

        _barfill.fillAmount = currentHealth / maxHealth;
    }
    private void RagdollDeath()
    {
        if (_collider != null)  _collider.enabled = false;
        if (movement != null) movement.enabled = false;
        if (agent != null) agent.enabled = false;
        if (animator != null)  animator.enabled = false;
        if (enemyshoot != null) enemyshoot.enabled = false;
        if (weapons != null)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] != null) weapons[i].gameObject.SetActive(false);
            }
        }
    }
    private void PlayerDeath()
    {
        if (_collider != null) _collider.enabled = false;
        if (_pm != null) _pm.enabled = false;
        if (_pl != null) _pl.enabled = false;
        if (_ps != null) _ps.enabled = false;

        EventManager.PlayerDeath();
    }

    public void SetHealth(float amount)
    {
        currentHealth =(amount <= maxHealth) ? amount : maxHealth;
        UpdateUI();
    }
    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
        currentHealth = (currentHealth > maxHealth) ? maxHealth : currentHealth;
        UpdateUI();
    }

    public void TakeDamage(float dmg) // Valores Negativos Suman Vida
    {
        if (isInvulnerable) return;

        currentHealth = (currentHealth > 0) ? currentHealth - dmg : 0;

        if (currentHealth <= 0) OnDeath();
        UpdateUI();
    }

    public void Revive(double healthPercent) // Ingrese Value 0.0 to 1.0
    {
        currentHealth = maxHealth * (float)healthPercent;
        
        UpdateUI();
        
        if (ragdoll)
        {
            if (animator != null) animator.enabled = true;
            if (agent != null) agent.enabled = true;
            if (movement != null) movement.enabled = true;
            if (enemyshoot != null) enemyshoot.enabled = true;
            if (_collider != null)  _collider.enabled = true;
        }
        else
        {
            gameObject.SetActive(true);
        }

        isAlive = true;
    }
    public void Revive(Vector3 position, double healthPercent)
    {
        currentHealth = maxHealth * (float)healthPercent;
        transform.position = position;
        
        UpdateUI();

        if (ragdoll)
        {
            if (animator != null) animator.enabled = true;
            if (agent != null) agent.enabled = true;
            if (movement != null) movement.enabled = true;
            if (enemyshoot != null) enemyshoot.enabled = true;
            if (_collider != null)  _collider.enabled = true;
        }
        else
        {
            gameObject.SetActive(true);
        }
        isAlive = true;
    }

    public void Kill()
    {
        TakeDamage(9999999999);
    }
    public void SwitchVulnerable(bool isInvulnerable) => this.isInvulnerable = isInvulnerable;
}
