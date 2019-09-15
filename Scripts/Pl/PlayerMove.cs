using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerBaseMove:IPlayerBaseMove
{
    protected PlayerMoveCore playerMoveCore { get; private set; }
    protected Rigidbody rigidbody { get; private set; }

    public PlayerBaseMove(GameObject pl)
    {
        if(pl!=null)
        {
            playerMoveCore = pl.GetComponent<PlayerMoveCore>();
            rigidbody = pl.GetComponent<Rigidbody>();
        }
    }
    public virtual void movePlayer(GameObject pl)
    {
    }
}

/// <summary>
/// 　待機 移動量を０にする
/// </summary>
public class PlayerIdleMove : PlayerBaseMove
{
    public PlayerIdleMove(GameObject pl):
        base(pl)
    { }

    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        rigidbody.velocity = Vector3.zero;
    }
}

public class PlayerConstantVelocityMove : PlayerBaseMove
{
    public PlayerConstantVelocityMove(GameObject pl):
        base(pl)
    { }

    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        //Vector3 nowVelocity = rigidbody.velocity;
        //rigidbody.AddForce(nowVelocity);
    }
}
/// <summary>
/// 基本的な横移動
/// </summary>
public class PlayerNormalMove : PlayerBaseMove
{
    public PlayerNormalMove(GameObject pl):
        base(pl)
    { }

    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        /////////////////////////////////////////////////
        ///////////////　空中にいる時は等速直線運動させる
        /// 空中にいる時は等速直線運動
        //if (!playerMoveCore.isGround())
            //return;

        /// 加速度を元に移動速度を計算する
        float acceleration = playerMoveCore.moveAccel;
        Vector3 velocity = (pl.transform.forward * acceleration * Time.deltaTime);
        velocity.y = 0.0f;

        /// クランプ
        float maxSpeed = playerMoveCore.maxMoveSpeed;
        if( rigidbody.velocity.sqrMagnitude >= maxSpeed * maxSpeed )
        {
            return;
        }

        /// 移動速度の変更
        rigidbody.AddForce(velocity,mode:ForceMode.Impulse);
    }
}

/// <summary>
/// ジャンプ移動
/// </summary>
public class PlayerJumpMove : PlayerBaseMove
{
    private float VerticalSpeed;

    public PlayerJumpMove(GameObject pl):
        base(pl)
    {
        VerticalSpeed = playerMoveCore.jumpSpeed;
    }

    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        rigidbody.AddForce(new Vector3(0.0f, VerticalSpeed * Time.deltaTime,0.0f),mode:ForceMode.Impulse);
        VerticalSpeed += Physics.gravity.y;
    }
}

/// <summary>
/// 落下移動 重力処理はrigidBodyで行う為、下方向の移動量をなくす
/// </summary>
public class PlayerFallMove : PlayerBaseMove
{
    public PlayerFallMove(GameObject pl):
        base(pl)
    { }

    public override void movePlayer(GameObject pl)
    {
        base.movePlayer(pl);

        //Vector3 oldVelocity = PlayerMoveCore.moveVelocity;
        //PlayerMoveCore.moveVelocity += Physics.gravity;

    }
}
