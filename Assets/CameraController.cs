using UnityEngine;
using System.Collections;
using System;

namespace PlayerControl
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField] float CameraHorizontalMovement, CameraVerticalMovement,
                               CameraLookSensitivity,
                               CameraOffsetX, CameraOffsetY, CameraOffsetZ;
        //[SerializeField] Vector3 CameraPositionOffset;
        [SerializeField] GameObject PlayerCharacter;
        Quaternion CurrentCameraRotation;

        // Use this for initialization
        void Start()
        {
            CameraLookSensitivity = 2f;
            PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
            SetDefaults();

            //Debug.Log(transform.parent.transform.localPosition);
        }

        // Update is called once per frame
        void Update()
        {
            CameraHorizontalMovement = Input.GetAxisRaw("Mouse X");
            CameraVerticalMovement = Input.GetAxis("Mouse Y");
        }

        void FixedUpdate()
        {
            RotateCamera();
        }

        void LateUpdate()
        {
            
        }

        void RotateCamera()
        {
            //if (CameraHorizontalMovement != 0)
            //    transform.RotateAround(PlayerCharacter.transform.position, Vector3.up, CameraLookSensitivity * CameraHorizontalMovement);

            //CurrentCameraRotation = transform.rotation;

            if(CameraHorizontalMovement != 0)
                RotateCharacter();

            if (CameraVerticalMovement >= 1 || CameraVerticalMovement <= -1)
                LookVerticallyWithCamera();
        }

        private void LookVerticallyWithCamera()
        {
            transform.Rotate(Mathf.Clamp(-CameraVerticalMovement * (Time.fixedDeltaTime * CameraLookSensitivity) * 25, -90, 90), transform.rotation.y, transform.rotation.z);
        }

        void RotateCharacter()
        {
            if(PlayerCharacter.GetComponent<PlayerMovement>())
                PlayerCharacter.GetComponent<PlayerMovement>().Orient(CameraHorizontalMovement, CameraLookSensitivity);
        }

        void SetDefaults()
        {
            CameraOffsetX = 0.6f;
            CameraOffsetY = 1.3f;
            CameraOffsetZ = -2f;
        }
    }
}