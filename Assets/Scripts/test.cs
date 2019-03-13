using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material material = MoveBlue.instance.material;
        this.GetComponent<MeshRenderer>().material = material;
    }
}
