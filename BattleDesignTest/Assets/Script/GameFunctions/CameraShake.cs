using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    private CinemachineImpulseSource cinemachineImpulseSource;

    void Start()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeCamera(float amplitude, float time)
    {
        cinemachineImpulseSource.m_ImpulseDefinition.m_AmplitudeGain = amplitude;
        cinemachineImpulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = time;
        cinemachineImpulseSource.GenerateImpulse();

    }


}
