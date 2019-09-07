using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSystemManager : BaseSystemManager<ResultSystemManager>
{

    public override void Start()
    {
        base.Start();
        fadeManager.fadeIn();
    }
    public void FixedUpdate()
    {
        /// デバッグシーン遷移
        if (Input.GetMouseButton(0))
        {
            fadeManager.fadeColor = Color.white;
            fadeManager.fadeOut(GameSceneManager.GameScene.Title);
        }

    }
}

