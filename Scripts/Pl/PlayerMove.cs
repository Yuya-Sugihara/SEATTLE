using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基本的な横移動
/// </summary>
public class PlayerNormalMove : IPlayerBaseMove
{
    private Vector3 MoveVelocity;

    public void Awake()
    {
        MoveVelocity = Vector3.zero;
    }

    public void movePlayer(GameObject pl)
    {
        /// 加速度を元に移動速度を計算する
        float acceleration = pl.GetComponent<PlayerMoveCore>().moveSpeed;
        MoveVelocity += (pl.transform.forward * acceleration * Time.deltaTime);

        float maxSpeed = pl.GetComponent<PlayerMoveCore>().maxMoveSpeed;
        /// 移動速度が最大速度よりも速い場合、調整する
        if( MoveVelocity.sqrMagnitude >= maxSpeed*maxSpeed )
        {
            MoveVelocity = Vector3.Normalize(MoveVelocity) * maxSpeed;
        }

        /// 移動する
        pl.transform.position += MoveVelocity;
    }

   
}
