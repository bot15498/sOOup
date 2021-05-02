using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    public Transform leftClamp;
    public Transform rightClamp;

    // Update is called once per frame
    void Update()
    {
      



        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(offset);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        var pos = transform.position;

        pos.x = Mathf.Clamp(transform.position.x, leftClamp.transform.position.x, rightClamp.transform.position.x);
        transform.position = pos;
    }
}
