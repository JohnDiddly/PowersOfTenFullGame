using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBall : MonoBehaviour
{

    // get input for the facing angle
    public float facingAngle = 0;

    // get input for the x and z for the ball
    float x = 0;
    float z = 0;

    Vector2 unitv2;

    public GameObject cameraReference;
    float distanceToCamera = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // user controls
        x = Input.GetAxis("Horizontal") * Time.deltaTime * -100;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 500;

        // Facing Angle
        facingAngle += x;
        unitv2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));

    }

    private void FixedUpdate()
    {

        // Apply force behind the ball
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitv2.x, 0, unitv2.y) * z * 3);

        // Set Camera Position Behidn the Ball based on rotation
        cameraReference.transform.position = new Vector3(-unitv2.x * distanceToCamera, distanceToCamera, -unitv2.y * distanceToCamera) + this.transform.position;

    }

}


