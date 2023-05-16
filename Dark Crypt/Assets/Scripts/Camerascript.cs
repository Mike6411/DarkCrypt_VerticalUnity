using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float targetDistance;

    [SerializeField]
    private float cameraLerp;

    Camera camera;

    float cameraMaxConstraint = 70f;
    float cameraMinConstraint = 30f;

    private float rotationX;
    private float rotationY;

    private void Awake()
    {
        camera= GetComponent<Camera>();
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        rotationX += Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, cameraMinConstraint, cameraMaxConstraint);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        transform.position = Vector3.Lerp(transform.position, target.transform.position - transform.forward * targetDistance, cameraLerp * Time.deltaTime);
    }
}