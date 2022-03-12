using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingRepairBtn : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private ResourceTypeSO goldResourceType;
    private BuildingTypeSO buildingType;
    private void Awake()
    {
        transform.Find("button").GetComponent<Button>().onClick.AddListener(() =>
        {
            int missingHealth = healthSystem.GetHealthAmountMax() - healthSystem.GetHealthAmount();
            int repairCost = missingHealth / 2;
            ResourceAmount[] resourceAmountCost = new ResourceAmount[]{
                new ResourceAmount {resourceType = goldResourceType,amount = repairCost}};

            if (ResourceManager.Instance.CanAfford(resourceAmountCost))
            {
                //Can afford
                ResourceManager.Instance.SpendResources(resourceAmountCost);
                healthSystem.Heal(missingHealth);
            }
            else
            {
                //cannot afford
                TooltipUI.Instance.Show("Cannot afford repair cost !", new TooltipUI.ToolTipTimer { timer = 2f });
            }
            
        });
    }
}
