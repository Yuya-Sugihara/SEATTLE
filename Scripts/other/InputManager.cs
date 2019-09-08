using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonTemplate<InputManager>
{
    [SerializeField]
    private bool isTouchEnable=false;

    /// <summary>
    ///     押し始め
    /// </summary>
    /// <param name="touchNum"></param>
    /// <returns></returns>
    public bool isTouchBegan(int touchNum)
    {
        /// タッチパネル対応
        if(isTouchEnable)
        {
            if(Input.touchCount>0)
            {
                Touch touch = Input.GetTouch(touchNum);
                if (touch.phase == TouchPhase.Began)
                    return true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(touchNum))
                return true;
        }

        return false;
    }

    /// <summary>
    /// 長押し
    /// </summary>
    /// <param name="touchNum"></param>
    /// <returns></returns>
    public bool isTouchMoved(int touchNum)
    {
        /// タッチパネル対応
        if (isTouchEnable)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(touchNum);
                if (touch.phase == TouchPhase.Moved)
                    return true;
            }
        }
        else
        {
            if (Input.GetMouseButton(touchNum))
                return true;
        }

        return false;
    }

    /// <summary>
    /// 押し終わり
    /// </summary>
    /// <param name="touchNum"></param>
    /// <returns></returns>
    public bool isTouchEnded(int touchNum)
    {
        /// タッチパネル対応
        if (isTouchEnable)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(touchNum);
                if (touch.phase == TouchPhase.Ended)
                    return true;
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(touchNum))
                return true;
        }

        return false;
    }
}
