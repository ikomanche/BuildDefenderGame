using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }    

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake()
    {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>("ResourceTypeList");

        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
        }

        DebugTestResourceAmountDictionary();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>("ResourceTypeList");
            AddResource(resourceTypeList.list[0], 2);
            DebugTestResourceAmountDictionary();
        }
    }

    private void DebugTestResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + " :" + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;
        DebugTestResourceAmountDictionary();
    }
}
