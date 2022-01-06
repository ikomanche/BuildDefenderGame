using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    private BuildingTypeSO activeBuildingType;
    private BuildingTypeListSO buildingTypeList;
    private Camera mainCamera;

    private void Awake()
    {
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingTypeList");
        //activeBuildingType = buildingTypeList.list[0];
    }
    private void Start()
    {
        mainCamera = Camera.main;        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (activeBuildingType != null)
            {
                Instantiate(activeBuildingType.Prefab, GetMouseWorldPosition(), Quaternion.identity);
            }
        }
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    buildingType = buildingTypeList.list[0];
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    buildingType = buildingTypeList.list[1];
        //}

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        return mouseWorldPosition;
    }
    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
    }   
    
    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
    }
}
