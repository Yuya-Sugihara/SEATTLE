using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float CameraOffset = 5.0f;
    [SerializeField]
    private float CameraAngleDg = 20.0f;

    private GameObject Pl;
    private Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = gameObject.GetComponent<Camera>();
        Pl = GameObject.Find("pl");
        if(Pl==null)
        {
            Debug.Assert(false, "[PlayerCamera] player is not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
        translateCamera();
    }

    private void translateCamera()
    {
        var playerTransform = Pl.transform;
        var playerPos = playerTransform.position;

        /// 注視点から直角にoffset分伸ばした地点がカメラの位置
        var lookAt = playerPos;

        /// 角度分カメラのy座標を上にする
        var verticalOffset = Mathf.Tan(Mathf.Deg2Rad*CameraAngleDg) * CameraOffset;
        var cameraPos = new Vector3(lookAt.x, lookAt.y+verticalOffset, -CameraOffset);
        
        /// 位置の変更
        transform.position = cameraPos;

        transform.LookAt(Pl.transform);

        ///　回転の変更
        //var cameraDir = Vector3.Normalize(lookAt - cameraPos);
        //var q = Quaternion.FromToRotation(Vector3.forward, cameraDir);
        //transform.rotation = q;

        //Camera.
    }
}
