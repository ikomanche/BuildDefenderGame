using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnDied;
    public event EventHandler OnHealed;
    private int healthAmount;
    private BuildingTypeHolder buildingTypeHolder;
    [SerializeField]private int healthAmountMax;


    private void Awake()
    {
        healthAmount = healthAmountMax;
    }

    public void Heal(int healAmount)
    {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnHealed?.Invoke(this, EventArgs.Empty);
    }
    public void HealFull()
    {        
        healthAmount = healthAmountMax;

        OnHealed?.Invoke(this, EventArgs.Empty);
    }

    public void Damage(int damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }

    public void SetHealthAmountMax(BuildingTypeSO buildingType, bool SetHealthAmount)
    {
        this.healthAmountMax = buildingType.healthAmountMax;

        if (SetHealthAmount)
            this.healthAmount = buildingType.healthAmountMax;
    }

    public bool IsDead()
    {
        return healthAmount == 0; 
    }
    public bool IsFullHealth()
    {
        return healthAmount == healthAmountMax; 
    }
    public int GetHealthAmount()
    {
        return healthAmount;
    }
    public int GetHealthAmountMax()
    {
        return healthAmountMax;
    }
    public float GetHealthAmountNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
}
