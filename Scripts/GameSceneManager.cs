using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム内のシーン制御を行う
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    /// ゲーム内のシーン
    public enum GameScene
    {
        Title=0,
        InGame,
        Result
    };

    private static GameSceneManager Instance;
    public static GameSceneManager instance
    {
        get
        {
            if (Instance == null) Debug.Assert(false, "GameSceneManager is not created.");
            return Instance;
        }
    }

    public void Awake()
    {
        if (Instance != null)
            return;

        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeNextScene(GameScene nextScene)
    {
        SceneManager.LoadSceneAsync((int)nextScene);
    }
}
