using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this is for first commit.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0.01f,0.0f,0.0f);
    }
}
