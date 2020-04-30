using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrested : MonoBehaviour
{

    void Start()
    {
        transform.position = new Vector3(-10, 2, 1);
    }

    public void busted()
    {
        transform.position = new Vector3(0, 9, -45);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
