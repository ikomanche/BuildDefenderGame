using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private BuildingTypeSO buildingType;
    private HealthSystem healthSystem;
    private Transform buildingDemolishBtn;

    private void Awake()
    {
        buildingDemolishBtn = transform.Find("pfBuildingDemolishBtn");
        HideDemolishBtn();
    }

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;

        healthSystem.SetHealthAmountMax(buildingType,true);

        healthSystem.OnDied += HealthSystem_OnDied;
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
}
