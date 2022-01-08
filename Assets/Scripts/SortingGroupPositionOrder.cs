using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[RequireComponent(typeof(SortingGroup))]
public class SortingGroupPositionOrder : MonoBehaviour
{
    [SerializeField] private bool runOnce = true;
    private float precisionMultiplier = 5f;

    private SortingGroup _sortingGroup;

    private void Awake()
    {
        _sortingGroup = GetComponent<SortingGroup>();
    }

    private void LateUpdate()
    {
        _sortingGroup.sortingOrder = (int)(-transform.position.y * precisionMultiplier);

        if (runOnce) enabled = false;
    }
}
