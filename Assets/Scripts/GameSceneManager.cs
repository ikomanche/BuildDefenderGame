using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager
{
    public enum Scene
    {
        GameScene,
        MenuScene,
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());        
    }
}
