using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeGame
{
    public class CameraFollower : MonoBehaviour
    {
        public GameObject target;
        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        private void FixedUpdate()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            Vector3 destPosition = target.transform.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, destPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
