using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstant : MonoBehaviour
{

    public Vector3 speed;
    public ForceMode forceMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(speed, forceMode);
    }
}
