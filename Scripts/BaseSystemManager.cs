using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 各シーンの管理を行うクラスの基底クラス
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseSystemManager<T> : SingletonTemplate<T>
    where T:BaseSystemManager<T>
{ 
    protected GameSceneManager gameSceneManager { get; private set; }

    public void Start()
    {
        /// シーン遷移を行う為にインスタンスを保持する
        gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
        if (gameSceneManager == null)
        {
            Debug.Assert(false, "[BaseSystemManager] start() GameSceneManager is not found.");
            return;
        }
    }

}
