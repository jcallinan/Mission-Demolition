using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    static public GameObject POI;
    public Vector2 minXY = Vector2.zero;

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
        //if (POI == null) return;
        // get the position of the POI
        // Vector3 destination = POI.transform.position;

        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        } else
        {
            // get the position of the poi
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    //return to default view
                    POI = null;
                    // in the next update
                    return;
                }
            }

        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        //force dest.z to be camz to keep the camera far enough away
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
