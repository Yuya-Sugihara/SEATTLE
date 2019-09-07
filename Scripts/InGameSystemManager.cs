using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSystemManager : BaseSystemManager<InGameSystemManager>
{

    public void FixedUpdate()
    {
        /// デバッグシーン遷移
        if (Input.GetMouseButton(0))
        {
            gameSceneManager.ChangeNextScene(GameSceneManager.GameScene.Result);
        }

    }
}
