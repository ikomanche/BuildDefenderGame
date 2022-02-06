using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

        transform.Find("replayBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameSceneManager.Load(GameSceneManager.Scene.GameScene);
        });
        transform.Find("mainMenuBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameSceneManager.Load(GameSceneManager.Scene.MenuScene);
        });

        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);

        transform.Find("wavesSurvivedText").GetComponent<TextMeshProUGUI>().SetText("You " +
            "Survived " + EnemyWaveManager.Instance.GetWaveNumber().ToString() + " Waves!");
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
