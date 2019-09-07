using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSystemManager : BaseSystemManager<InGameSystemManager>
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
            fadeManager.fadeColor = Color.red;
            fadeManager.fadeOut(GameSceneManager.GameScene.Result);
        }

    }
}
