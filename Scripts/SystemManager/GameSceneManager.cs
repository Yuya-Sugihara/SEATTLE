using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム内のシーン制御を行う
/// </summary>
public class GameSceneManager : SingletonTemplate<GameSceneManager>
{
    /// ゲーム内のシーン
    public enum GameScene
    {
        Title=0,
        InGame,
        Result
    };

    public override void Awake()
    {
        base.Awake();    
    }

    public void Start()
    {
        
    }

    public void ChangeNextScene(GameScene nextScene)
    {
        SceneManager.LoadSceneAsync((int)nextScene);
    }
}
