using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;
    private Transform arrowBtn;
    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;
    private void Awake()
    {
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingTypeList");

        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();

        int index = 0;

        arrowBtn = Instantiate(btnTemplate, transform);
        arrowBtn.gameObject.SetActive(true);

        float offSetAmount = 140f;
        arrowBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(offSetAmount * index, 0);
        arrowBtn.Find("image").GetComponent<Image>().sprite = arrowSprite;
        arrowBtn.Find("image").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -40);

        arrowBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            BuildingManager.Instance.SetActiveBuildingType(null);
        });       

        index++;

        foreach (BuildingTypeSO buildingType in buildingTypeList.list)
        {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);
            
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offSetAmount * index, 0);
            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            btnTransformDictionary[buildingType] = btnTransform;

            index++;
        }
    }

    private void Update()
    {
        UpdateActiveBuildingTypeButton();
    }

    private void UpdateActiveBuildingTypeButton()
    {
        foreach (BuildingTypeSO buildingType in btnTransformDictionary.Keys)
        {
            arrowBtn.Find("selected").gameObject.SetActive(false);
            Transform btnTransform = btnTransformDictionary[buildingType];
            btnTransform.Find("selected").gameObject.SetActive(false);

            BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
            if (activeBuildingType == null)
            {
                arrowBtn.Find("selected").gameObject.SetActive(true);
            }
            else
            {
                btnTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
            }
        }
    }
}
