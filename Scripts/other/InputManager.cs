using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonTemplate<InputManager>
{
    [SerializeField]
    private bool isTouchEnable=false;

    private Vector3[] InputStartPos;

    public override void Awake()
    {
        base.Awake();

        InputStartPos = new Vector3[2]; //２本の指を受け付ける
    }

    public void Update()
    {
        updateInputPosInfo();
    }

    #region 公開メソッド
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

    /// <summary>
    /// マウスでスライドされたベクトルを返す
    /// </summary>
    /// <returns></returns>
    public Vector3 getInputVector()
    {
        if(Input.GetMouseButton(0) && InputStartPos[0]!=Vector3.zero)
        {
            return Vector3.Normalize(Input.mousePosition - InputStartPos[0]);
        }

        return Vector3.zero;
    }
    #endregion

    #region 非公開メソッド
    private void updateInputPosInfo()
    {
        ///とりあえずキー入力で移動させる
        if (Input.GetMouseButtonDown(0))
        {
            InputStartPos[0] = Input.mousePosition;
            Debug.Log("input start pos: " + InputStartPos[0]);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            InputStartPos[0] = Vector3.zero;
        }


    }
    #endregion
}
