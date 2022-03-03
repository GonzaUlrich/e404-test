using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Vector3 grow = new Vector3(1,1,1);
    private Vector3 myScale;
    void Start()
    {
        myScale = transform.localScale;
        transform.localScale= new Vector3(0,0,0);
    }

    void Update()
    {
        if(transform.localScale.x<=myScale.x){
            transform.localScale+=grow*Time.deltaTime;
        }
        
    }
}
