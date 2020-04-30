using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple bowling lane logic, is triggered externally by buttons that are routed
/// to the InitialiseRound, TalleyScore and ResetRack.
/// 
/// Future work;
///   Use the timer in update to limit how long a player has to bowl,
///   Detect that the player/ball is 'bowled' from behind the line
/// </summary>
public class BowlingLaneBehaviour : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject bowlingBall;
    public Transform[] pinSpawnLocations;
    public Transform defaultBallLocation;
    Rigidbody rb;
    //TODO; we need a way of tracking the pins that are used for scoring and so we can clean them up


    List<GameObject> pins = new List<GameObject>();
    BowlingListItem bowlingListItem;

    private void Start()
    {
        bowlingListItem = FindObjectOfType<BowlingListItem>();
        bowlingListItem.MaxScore = pinSpawnLocations.Length;
    }

    [ContextMenu("InitialiseRound")]
    public void InitialiseRound()
    {
        //TODO; need to move or init or create pins for a round of bowling, most likely to include some of the following;
        
        foreach (var pinLoc in pinSpawnLocations)
        {
            var newPin = Instantiate(pinPrefab, pinLoc.position, pinLoc.rotation);
            pins.Add(newPin);
        }
        
    }



    public void BallReachedEnd()
    {
        //TODO; this needs to return the ball to the ball feed so the player could bowl again or at least clean ups
        //bowlingBall.transform.position = defaultBallLocation.transform.position;

    }

    int score;

    [ContextMenu("TalleyScore")]
    public void TalleyScore()
    {
        score = 0;


        for (int i = 0; i < pins.Count; i++)
        {

        float angle = Vector3.Dot(Vector3.up, pins[i].transform.up);

            if (angle <= 0.9f)
            {
                score++;
            }

        }

        bowlingListItem.Score = score;
        bowlingListItem.BowlingScored();
        

        //Vector3.up or new Vector3(0, 1, 0) 
        

      //TODO; determine score and get that information out to a checklist item, either via event or directly
    }

    [ContextMenu("ResetRack")]
    public void ResetRack()
    {
        //TODO; clean up all objects created by the bowling lane, preparing for a new round of bowling to occur
        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].transform.position = pinSpawnLocations[i].transform.position;
            pins[i].transform.position = pinSpawnLocations[i].transform.position;
        }

        bowlingBall.transform.position = defaultBallLocation.transform.position;
        rb = bowlingBall.GetComponent<Rigidbody>();
        rb.velocity =new Vector3(0,0,0);

        bowlingListItem.Score = 0;
        bowlingListItem.BowlingScored();

    }

    protected void Update()
    {
        
    }
}
