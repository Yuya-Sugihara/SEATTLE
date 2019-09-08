using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーの移動
/// </summary>
public class PlayerMoveCore : MonoBehaviour
{

    [SerializeField]
    private float MoveSpeed = 0.1f;
    [SerializeField]
    private float MaxMoveSpeed = 2.0f;
    [SerializeField]
    private float JumpSpeed = 1.0f;
    [SerializeField]
    private float GravitySpeed = 0.2f;

    [SerializeField]
    private bool IsGround;

    private IPlayerBaseMove PlayerMove;
    private InputManager InputManager;

    public float moveSpeed { get { return MoveSpeed; } }
    public float maxMoveSpeed { get { return MaxMoveSpeed; } }
    public float jumpSpeed { get { return JumpSpeed; } }
    public float gravitySpeed { get { return GravitySpeed; } }
    public Vector3 moveVelocity { get; set; }

    public void Awake()
    {
        moveVelocity = Vector3.zero;
    }

    // Start is called before the first frame update
    public void Start()
    {
        InputManager = GameObject.Find("InGameSystemManager").GetComponent<InputManager>();

        PlayerMove = new PlayerIdleMove();
    }

    public void FixedUpdate()
    {
        ///
        if(InputManager.isTouchBegan(0))
        {
            PlayerMove = new PlayerJumpMove();
        }

        /// moveVelocityの値を変更する
        PlayerMove.movePlayer(gameObject);
        transform.position += moveVelocity;
    }

    public void LateUpdate()
    {
        /// ジャンプ状態の場合は落ちる状態へ変更する
        if(PlayerMove.GetType()==typeof(PlayerJumpMove))
        {
            PlayerMove = new PlayerFallMove();
        }

        /// 着地するととりあえず待機
        if(isGround())
        {
            PlayerMove = new PlayerIdleMove();
        }
    }

    private bool isGround()
    {
        Ray ray = new Ray(gameObject.transform.position, -gameObject.transform.up);
        RaycastHit hit = new RaycastHit();
        float rayDistance = 1.0f;

        Debug.DrawRay(ray.origin,ray.direction,Color.red,rayDistance);
        if (Physics.Raycast(ray, out hit, rayDistance))
            IsGround = true;
        else
            IsGround = false;

        return IsGround;
    }
}
