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
    protected FadeManager fadeManager { get; private set; }

    public virtual void Start()
    {
        /// シーン遷移を行う為にインスタンスを保持する
        fadeManager = GameObject.Find("GameSceneManager").GetComponent<FadeManager>();
        if (fadeManager == null)
        {
            Debug.Assert(false, "[BaseSystemManager] start() fadeManager is not found.");
            return;
        }
    }

}
