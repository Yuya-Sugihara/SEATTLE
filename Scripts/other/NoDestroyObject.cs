using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム中一度も破壊されないオブジェクトの設定を行う
/// </summary>
public class NoDestroyObject : SingletonTemplate<GameSceneManager>
{
   
    public override void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
        }

        base.Awake();
    }

}
