using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinamechineVirtualCamera;
    private float orthographicSize;
    private float targetOrthographicSize;

    private void Start()
    {
        orthographicSize = cinamechineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }
    private void Update()
    {
        HandleMovement();
        HandleZoom();

    }

    private void HandleZoom()
    {
        float zoomAmount = 2f;
        targetOrthographicSize -= Input.mouseScrollDelta.y * zoomAmount;

        float minOrthographicSize = 10f;
        float maxOrthographicSize = 30f;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);

        cinamechineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }

    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
