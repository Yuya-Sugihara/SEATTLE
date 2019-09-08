using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーの移動
/// </summary>
public class PlayerMoveCore : MonoBehaviour
{

    [SerializeField]
    private float MoveSpeed=0.1f;
    [SerializeField]
    private float MaxMoveSpeed=2.0f;

    private Vector3 MoveVelocity;
    private IPlayerBaseMove PlayerMove;

    public float moveSpeed {
        get { return MoveSpeed; }
    }
    public float maxMoveSpeed
    {
        get { return MaxMoveSpeed; }
    }

    public void Awake()
    {
        MoveVelocity = Vector3.zero;
    }

    // Start is called before the first frame update
    public void Start()
    {
        PlayerMove = new PlayerNormalMove();
    }

    public void FixedUpdate()
    {
        PlayerMove.movePlayer(gameObject);
    }

    
}
