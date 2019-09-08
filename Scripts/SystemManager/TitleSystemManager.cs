using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内のシーン制御を行う
/// </summary>
public class TitleSystemManager : BaseSystemManager<TitleSystemManager>
{
    public override void Start()
    {
        base.Start();
        fadeManager.fadeIn();

       
    }
    public void FixedUpdate()
    {
        /// デバッグシーン遷移
        if(Input.GetMouseButton(0))
        { 
            fadeManager.fadeColor = Color.black;
			fadeManager.fadeOut(GameSceneManager.GameScene.InGame);
        }

    }
}
