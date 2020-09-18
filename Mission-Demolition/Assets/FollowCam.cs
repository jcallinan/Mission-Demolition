using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    static public GameObject POI;
    [Header("Set Dynamically")]
    public float camZ; // the desired pos. of the camera

    void Awake() {
        camZ = this.transform.position.z;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        // run at max 50 fps
        if (POI == null) return;
        // get the position of the POI
        Vector3 destination = POI.transform.position;
        destination = Vector3.Lerp(transform.position, destination, easing);
        //force dest.z to be camz to keep the camera far enough away
        destination.z = camZ;
        transform.position = destination;

    }
}
