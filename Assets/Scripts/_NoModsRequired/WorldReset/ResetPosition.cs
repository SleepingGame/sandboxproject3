using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent antibully;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 9, 0);
    }


    public void police()
    {
        transform.position = new Vector3(0, 9, -45);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
