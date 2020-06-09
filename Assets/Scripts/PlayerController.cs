using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CubeGame
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody rb;
        public float speed = 5f;
        public float jumpForce;
        private bool isGrounded = true;
        public float rotSpeed = 5f;
        private Vector3 initialPosition;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            initialPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if(CanJump()) Jump();
            Move();
        }

        private void Jump()
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            RotateAnim();
        }

        private void RotateAnim()
        {
            Vector3 rot = new Vector3(0, 0, -90);
            rb.DORotate(rot, rotSpeed).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).Play();

        }

        private bool CanJump()
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                return true;
            }
            return false;
        }

        private void Move()
        {
            rb.MovePosition(rb.position + Vector3.right * speed * Time.fixedDeltaTime);
        }

        private void FixRotation()
        {
            DOTween.KillAll();
            transform.rotation = Quaternion.identity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Danger")
            {
                Restart();
            }
            else
            {
                isGrounded = true;
                FixRotation();
            }

        }
        private void Restart()
        {
            GameController.Instance.Restart();
        }
        private void OnCollisionExit(Collision collision)
        {
            isGrounded = false;
        }
    }
}
