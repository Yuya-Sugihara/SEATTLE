using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム内のシーン制御を行う
/// </summary>
public class TitleSystemManager : BaseSystemManager<TitleSystemManager>
{
    public void FixedUpdate()
    {
        /// デバッグシーン遷移
        if(Input.GetMouseButton(0))
        {
            gameSceneManager.ChangeNextScene(GameSceneManager.GameScene.InGame);
        }

    }
}
