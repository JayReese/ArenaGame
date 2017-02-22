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
            CameraVerticalMovement = Input.GetAxisRaw("Mouse Y");
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
            if(CameraHorizontalMovement != 0)
                RotateCharacter();

            if (CameraVerticalMovement != 0)
                LookVerticallyWithCamera();
        }

        private void LookVerticallyWithCamera()
        {
            transform.Rotate(-CameraVerticalMovement * (Time.fixedDeltaTime * CameraLookSensitivity) * 25, 0, 0);
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