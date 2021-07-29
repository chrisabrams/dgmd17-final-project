using UnityEngine;

/*
Used to make camera follow drone
*/

public class MainCameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate(){
        transform.position = target.position + offset;

        if (transform.position.y > 200f) {
            transform.position = new Vector3(transform.position.x, 200f, transform.position.z);
        }
    }
}
