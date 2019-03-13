using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlue : MonoBehaviour
{
    public GameObject go;
    public Material material;

    public static MoveBlue instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null){
            instance = this;
        }
        else Destroy(this);
        //this.GetComponent<MeshRenderer>().material = material;
        //go.GetComponent<MeshRenderer>().material = material;
        
    }

    public void SetMaterial(){
        this.GetComponent<MeshRenderer>().material = material;
        go.GetComponent<MeshRenderer>().material = material;
    }
}
