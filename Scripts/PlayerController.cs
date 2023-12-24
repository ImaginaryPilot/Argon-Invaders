using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float Speed = 4f;
    [Tooltip("m")] [SerializeField] float xRange = 6f;
    [Tooltip("m")] [SerializeField] float yRange = 3f;
    [SerializeField] GameObject[] bullets;

    [Header("Positions")]
    [SerializeField] float PositionPitchFactor = -5f;
    [SerializeField] float PositionYawFactor = 5f;

    [Header("Controls")]
    [SerializeField] float controlRollFactor = -15f;
    [SerializeField] float controlPitchFactor = -15f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void OnDeath()
    {
        isControlEnabled = false;
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * PositionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * PositionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffest = xThrow * Speed * Time.deltaTime;
        float yOffest = yThrow * Speed * Time.deltaTime;

        float currentX = transform.localPosition.x + xOffest;
        float currentY = transform.localPosition.y + yOffest;

        float newX = Mathf.Clamp(currentX, -xRange, xRange);
        float newY = Mathf.Clamp(currentY, -yRange, yRange);


        transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    void SetGunsActive(bool isActive)
    {
        foreach (GameObject bullets in bullets)
        {
            var emmissionModule = bullets.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isActive;
        }
    }
}
