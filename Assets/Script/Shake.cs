using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    public static Shake Instance;
    private CinemachineVirtualCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin cinemachinePerlin;
    private float shakeDuration;
    private float totalShakeDuration;
    private float initialIntensity;

    private void Awake()
    {
        Instance = this;
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachinePerlin = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;
            cinemachinePerlin.m_AmplitudeGain = Mathf.Lerp(initialIntensity, 0, 1 - (shakeDuration / totalShakeDuration));
        }
    }

    public void CameraMovement(float intensity, float frequency, float duration)
    {
        cinemachinePerlin.m_AmplitudeGain = intensity;
        cinemachinePerlin.m_FrequencyGain = frequency;
        initialIntensity = intensity;
        totalShakeDuration = duration;
        shakeDuration = duration;
    }

}