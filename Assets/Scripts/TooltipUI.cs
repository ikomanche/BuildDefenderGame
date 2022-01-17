using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform;
    public static TooltipUI Instance { get; private set; }
    private TextMeshProUGUI textMeshPro;
    private RectTransform backgroundRectTransform;
    private RectTransform rectTransform;
    private ToolTipTimer toolTipTimer;
    private void Awake()
    {
        Instance = this;

        textMeshPro = transform.Find("text").GetComponent<TextMeshProUGUI>();
        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();

        Hide();

        //SetText("ikomanche!!");
    }

    private void Update()
    {
        HandleFollowMouse();

        if (toolTipTimer != null)
        {
            toolTipTimer.timer -= Time.deltaTime;
            if (toolTipTimer.timer < 0)
            {
                Hide();
            }
        }
    }

    private void HandleFollowMouse()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;

        if (anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width)
        {
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if (anchoredPosition.x < 0)
        {
            anchoredPosition.x = 0;
        }
        if (anchoredPosition.y + backgroundRectTransform.rect.height > canvasRectTransform.rect.height)
        {
            anchoredPosition.y = canvasRectTransform.rect.height - backgroundRectTransform.rect.height;
        }
        if (anchoredPosition.y < 0)
        {
            anchoredPosition.y = 0;
        }

        rectTransform.anchoredPosition = anchoredPosition;
    }

    private void SetText(string tooltipText)
    {
        textMeshPro.SetText(tooltipText);
        textMeshPro.ForceMeshUpdate();

        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(8, 8);

        backgroundRectTransform.sizeDelta = textSize + padding;
    }

    public void Show(string tooltipText, ToolTipTimer toolTipTimer = null)
    {
        this.toolTipTimer = toolTipTimer;
        gameObject.SetActive(true);
        SetText(tooltipText);
        HandleFollowMouse();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public class ToolTipTimer
    {
        public float timer;
    }
}
