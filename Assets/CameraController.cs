using UnityEngine;
using System.Collections;
using System;

namespace PlayerControl
{
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        ///  Camera controller script, created to serve as the method of controlling the camera.
        /// </summary>
        /// 
        /// Third person camera pos: 1, 1.2, -2.3
        /// Overhead camera pos: 0, 3, -3.5

        [SerializeField] float CameraHorizontalMovement, CameraVerticalMovement,
                               CameraLookSensitivity,
                               CameraOffsetX, CameraOffsetY, CameraOffsetZ;
        //[SerializeField] Vector3 CameraPositionOffset;
        [SerializeField] GameObject PlayerCharacter;
        [SerializeField] Quaternion CurrentCameraRotation;

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

        void RotateCamera()
        {
            if(CameraHorizontalMovement != 0)
                RotateCharacter();

            if (CameraVerticalMovement != 0)
                LookVerticallyWithCamera();
        }

        private void LookVerticallyWithCamera()
        {
           transform.Rotate(Mathf.Clamp(transform.eulerAngles.x, 10, 30) * -CameraVerticalMovement * (Time.fixedDeltaTime * CameraLookSensitivity), 0, 0);
        }

        void RotateCharacter()
        {
            if(PlayerCharacter.GetComponent<PlayerMovement>())
                PlayerCharacter.GetComponent<PlayerMovement>().Orient(CameraHorizontalMovement, CameraLookSensitivity);
        }

        void SetDefaults()
        {
            CameraOffsetX = 0.8f;
            CameraOffsetY = 1f;
            CameraOffsetZ = -2.3f;

            transform.localPosition = new Vector3(CameraOffsetX, CameraOffsetY, CameraOffsetZ);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        float ClampAngle(float angle, float min, float max)
        {
            if (angle < 90 || angle > 270)
            {
                if (angle > 180)
                    angle -= 360;

                if (max > 180)
                    max -= 360;

                if (min > 180)
                    min -= 360;
            }

            angle = Mathf.Clamp(angle, min, max);

            if (angle < 0)
                angle += 360;

            return angle;
        }
    }
}