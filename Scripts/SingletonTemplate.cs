using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シングルトンを実装するテンプレートクラス　デフォルトはシーン内のみ存在する
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonTemplate<T> : MonoBehaviour
    where T :SingletonTemplate<T>
{
    private static SingletonTemplate<T> Instance;
 
    public static SingletonTemplate<T> instance
    {
        get
        {
            if (Instance == null) Debug.Assert(false, "Singleton is not created.");
            return Instance;
        }
    }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;

    }
}
