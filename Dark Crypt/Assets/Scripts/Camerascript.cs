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

    Camera mycamera;

    float cameraMaxConstraintX = 70f;
    float cameraMinConstraintX = 45f;
    float cameraMinConstraintY = -45f;
    float cameraMaxConstraintY = 45f;

    private float rotationX;
    private float rotationY;

    private void Awake()
    {
        mycamera= GetComponent<Camera>();
        mycamera = Camera.main;
    }

    private void LateUpdate()
    {
        rotationX += Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, cameraMinConstraintX, cameraMaxConstraintX);
        rotationY = Mathf.Clamp(rotationY, cameraMinConstraintY, cameraMaxConstraintY);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        transform.position = Vector3.Lerp(transform.position, target.transform.position - transform.forward * targetDistance, cameraLerp * Time.deltaTime);
    }
}