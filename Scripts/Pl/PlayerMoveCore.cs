using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーの移動
/// </summary>
public class PlayerMoveCore : MonoBehaviour
{

    [SerializeField]
    private float MoveAccel = 0.1f;
    [SerializeField]
    private float MaxMoveSpeed = 2.0f;
    [SerializeField]
    private float JumpSpeed = 1.0f;
    [SerializeField]
    private float GravitySpeed = 0.2f;

    [SerializeField]
    private bool IsGround;
    [SerializeField]
    private IPlayerBaseMove PlayerMove;

    private InputManager InputManager;
    private Rigidbody Rigidbody;

    public float moveAccel { get { return MoveAccel; } }
    public float maxMoveSpeed { get { return MaxMoveSpeed; } }
    public float jumpSpeed { get { return JumpSpeed; } }
    public float gravitySpeed { get { return GravitySpeed; } }
   

    public void Awake()
    {
    }

    // Start is called before the first frame update
    public void Start()
    {
        InputManager = GameObject.Find("InGameSystemManager").GetComponent<InputManager>();
        Rigidbody = gameObject.GetComponent<Rigidbody>();

        /// 重力を設定
        Physics.gravity = new Vector3(0.0f, -gravitySpeed, 0.0f);

        PlayerMove = new PlayerNormalMove(gameObject);
    }

    public void Update()
    {
        ///ジャンプ処理
        if(InputManager.isTouchBegan(0))
        {
            PlayerMove = new PlayerJumpMove(gameObject);
        }

       
        /// 何も入力がない場合は通常の横移動をする
        if(PlayerMove==null)
        {
            PlayerMove = new PlayerNormalMove(gameObject);
        }

        /// rigidbodyの値を変更する
        PlayerMove.movePlayer(gameObject);

        Debug.Log("PlayerMove: " + PlayerMove.GetType().ToString());
        Debug.Log("Velocity: " + Rigidbody.velocity);
    }

    public void LateUpdate()
    {
        /// 地上にいない時は重力をかける
        if(!isGround())
        {
            moveByGravity();
        }


        PlayerMove = null;
    }

    /// <summary>
    /// 重力を付加する
    /// </summary>
    private void moveByGravity()
    {
        Rigidbody.AddForce(new Vector3(0.0f, -gravitySpeed * Time.deltaTime, 0.0f),mode:ForceMode.Impulse);
    }

    /// <summary>
    /// レイを放ち、着地判定を行う
    /// </summary>
    /// <returns></returns>
    public bool isGround()
    {
        Ray ray = new Ray(gameObject.transform.position, -gameObject.transform.up);
        RaycastHit hit = new RaycastHit();
        float rayDistance = gameObject.transform.localScale.y * 0.51f;

        Debug.DrawRay(ray.origin,ray.direction,Color.red,1);
        if (Physics.Raycast(ray, out hit, rayDistance))
            IsGround = true;
        else
            IsGround = false;

        return IsGround;
    }
}
