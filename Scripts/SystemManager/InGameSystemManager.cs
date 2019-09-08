using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSystemManager : BaseSystemManager<InGameSystemManager>
{
    private InputManager InputManager;

    public override void Start()
    {
        base.Start();

        InputManager = gameObject.GetComponent<InputManager>();

        if(fadeManager!=null)
            fadeManager.fadeIn();
    }

    public void FixedUpdate()
    {
        /// デバッグシーン遷移
        if (InputManager.isTouchBegan(0))
        {
            if (fadeManager != null)
            {
                fadeManager.fadeColor = Color.red;
                fadeManager.fadeOut(GameSceneManager.GameScene.Result);
            }
        }

    }
}
