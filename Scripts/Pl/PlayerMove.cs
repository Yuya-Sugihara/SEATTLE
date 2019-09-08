using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerBaseMove:IPlayerBaseMove
{
    protected PlayerMoveCore PlayerMoveCore;

    public virtual void movePlayer(GameObject pl)
    {
        if (PlayerMoveCore == null)
        {
            PlayerMoveCore = pl.GetComponent<PlayerMoveCore>();
        }
    }
}

/// <summary>
/// 　待機
/// </summary>
public class PlayerIdleMove : PlayerBaseMove
{
    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        PlayerMoveCore.moveVelocity = Vector3.zero;
    }
}
/// <summary>
/// 基本的な横移動
/// </summary>
public class PlayerNormalMove : PlayerBaseMove
{
    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        /// 加速度を元に移動速度を計算する
        float acceleration = PlayerMoveCore.moveSpeed;
        Vector3 velocity = (pl.transform.forward * acceleration * Time.deltaTime);

        /// 移動速度が最大速度よりも速い場合、調整する
        float maxSpeed = pl.GetComponent<PlayerMoveCore>().maxMoveSpeed;
        if( velocity.sqrMagnitude >= maxSpeed*maxSpeed )
        {
            velocity = Vector3.Normalize(velocity) * maxSpeed;
        }

        /// 移動する
        PlayerMoveCore.moveVelocity += velocity;
    }
}

/// <summary>
/// ジャンプ移動
/// </summary>
public class PlayerJumpMove : PlayerBaseMove
{
    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        
        /// 加速度を元に移動速度を計算する
        float acceleration = PlayerMoveCore.jumpSpeed;
        Vector3 velocity = (pl.transform.up * acceleration * Time.deltaTime);

        /// 移動する
        PlayerMoveCore.moveVelocity += velocity;
    }
}

/// <summary>
/// 落下移動
/// </summary>
public class PlayerFallMove : PlayerBaseMove
{
    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);
        
        float gravity = PlayerMoveCore.gravitySpeed;
        var velocity = new Vector3(0.0f, -gravity,0.0f);
        PlayerMoveCore.moveVelocity += velocity;
    }
}
