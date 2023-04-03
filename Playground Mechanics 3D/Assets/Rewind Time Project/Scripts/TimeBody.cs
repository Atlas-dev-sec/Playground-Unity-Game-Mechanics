using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    private bool isRewinding = false;
    public float recordTime = 7f;
    List<PointInTime> pointInTimes;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        pointInTimes = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.Return)){
            StopRewind();
        }
    }

    void FixedUpdate() {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind(){
        if (pointInTimes.Count > 0){
            PointInTime pointInTime = pointInTimes[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointInTimes.RemoveAt(0);
        }else {
            StopRewind();
        }
        
    }


    void Record (){
        if (pointInTimes.Count >  Mathf.Round(recordTime / Time.fixedDeltaTime)){
            pointInTimes.RemoveAt( pointInTimes.Count - 1);
        }
        pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind(){
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind(){
        isRewinding = false;
        rb.isKinematic = false;
    }
}
