using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Script
{
public class Camera : MonoBehaviour
{
    public Transform target;
    public float translateSpeed;
    public float rotateSpeed;


    public Vector3[] offset;
    public int currentOffset;
    //clock on screen
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleTransation(offset[currentOffset]);
        HandleRotation();
        HandleCameraView();
    }
    private void HandleTransation(Vector3 offset)
    {
        if (target == null) return; 
        Vector3 targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        
    }
    private void HandleRotation()
    {
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    private void HandleCameraView()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentOffset++;
            if (currentOffset >= offset.Length) currentOffset = 0;
            
        }
    }
}
}

