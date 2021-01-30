using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private GameObject player;
    private float minClamp = -90f;
    private float maxClamp = 90f;

    [HideInInspector]
    private Vector2 rotation;
    private Vector2 currentLookRotation;
    private Vector2 rotationVector = new Vector2(0, 0);

    public float lookSensitivity = 2f;
    public float lookSmoothDamp = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);

        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X")
            * lookSensitivity);

        currentLookRotation.y = Mathf.SmoothDamp(currentLookRotation.y, rotation.y, ref rotationVector.y, lookSmoothDamp);

        transform.localEulerAngles = new Vector3(-currentLookRotation.y, 0, 0);
    }
}
