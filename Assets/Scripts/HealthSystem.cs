using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnDied;
    private int healthAmount;
    private BuildingTypeHolder buildingTypeHolder;
    [SerializeField]private int healthAmountMax;


    private void Awake()
    {
        healthAmount = healthAmountMax;
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
    public int GetHealthAmount()
    {
        return healthAmount;
    }
    public float GetHealthAmountNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
}
