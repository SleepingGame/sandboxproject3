using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Dragoon : MonoBehaviour
{
    int boolcounter = 0;
    public UnityEngine.Events.UnityEvent erased;

     

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "NerfDart")
        {
            boolcounter++;
            
            if(boolcounter == 1 )
            {
                print("Hey you! You better stop");
            }
            if(boolcounter == 2)
            {
                print("This is last time I am forgiving you. Stop!");
            }
            if(boolcounter == 3)
            {
                print("That's it. I had enough, so I will delete your gun. Do not underestimate a Dragons");
                erased.Invoke();
            }
        }

        if(collision.gameObject.tag == "BowlingBall")
        {
            print("Oh, no! The strongest dark materia from other world is demolishing my cells and I am dying!");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "BoomBox")
        {
            print("Really? Wow. Just wow");
        }
        if(collision.gameObject.tag == "Pin")
        {
            print("I expect what can't be predicted!");
        }

    }



}
