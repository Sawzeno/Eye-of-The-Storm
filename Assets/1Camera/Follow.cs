using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }


    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 position = target.position;
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(position.x, position.y, position.z) + offset, Time.deltaTime * 2f);
    }
}