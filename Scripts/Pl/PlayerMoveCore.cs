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
    private float MoveSpeed = 1.0f;
    [SerializeField]
    private float MaxMoveSpeed = 2.0f;
    [SerializeField]
    private float JumpSpeed = 1.0f;
    [SerializeField]
    private float GravitySpeed = 0.2f;

    private Rigidbody Rigidbody;
	private Animator Animator;

    public float moveAccel { get { return MoveAccel; } }
    public float maxMoveSpeed { get { return MaxMoveSpeed; } }
    public float jumpSpeed { get { return JumpSpeed; } }
    public float gravitySpeed { get { return GravitySpeed; } }
   

    public void Awake()
    {
    }


    public void Start()
    { 
        Rigidbody = gameObject.transform.GetComponentInChildren<Rigidbody>();
		Animator = gameObject.transform.GetComponentInChildren<Animator>();

        /// 重力を設定
        Physics.gravity = new Vector3(0.0f, -gravitySpeed, 0.0f);
    }

    public void Update()
    {
        Vector3 moveVelocity = Vector3.zero;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -gameObject.transform.forward*moveAccel*Time.deltaTime;
            Animator.SetBool("Walk Backward", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = gameObject.transform.forward * moveAccel * Time.deltaTime;
            Animator.SetBool("Walk Forward", true);
        }
        else
        {
            Rigidbody.velocity *= 0.7f;
            Animator.SetBool("Walk Forward", false);
            Animator.SetBool("Walk Backward", false);
        }

        //Rigidbody.AddForce(moveVelocity, ForceMode.Impulse);
    }

    public void LateUpdate()
    {
      
    }

}
