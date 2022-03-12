using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private BuildingTypeSO buildingType;
    private HealthSystem healthSystem;
    private Transform buildingDemolishBtn;
    private Transform buildingRepairBtn;

    private void Awake()
    {
        buildingDemolishBtn = transform.Find("pfBuildingDemolishBtn");
        buildingRepairBtn = transform.Find("pfBuildingRepairBtn");
        HideDemolishBtn();
        HideRepairBtn();
    }

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;

        healthSystem.SetHealthAmountMax(buildingType,true);

        healthSystem.OnDied += HealthSystem_OnDied;
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnHealed += HealthSystem_OnHealed;
    }

    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
        if (healthSystem.IsFullHealth())
        {
            HideRepairBtn();
        }
    }

    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        ShowRepairBtn();
    }

    private void HealthSystem_OnDied(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        ShowDemolishBtn();
    }
    private void OnMouseExit()
    {
        HideDemolishBtn();
    }

    private void HideDemolishBtn()
    {
        if (buildingDemolishBtn != null)
            buildingDemolishBtn.gameObject.SetActive(false);
    }
    private void ShowDemolishBtn()
    {
        if (buildingDemolishBtn != null)
            buildingDemolishBtn.gameObject.SetActive(true);
    }
    private void HideRepairBtn()
    {
        if (buildingRepairBtn != null)
            buildingRepairBtn.gameObject.SetActive(false);
    }
    private void ShowRepairBtn()
    {
        if (buildingRepairBtn != null)
            buildingRepairBtn.gameObject.SetActive(true);
    }
}
