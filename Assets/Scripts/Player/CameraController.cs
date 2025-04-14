using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float minFOV=25f;
    [SerializeField] ParticleSystem speedUpParticles;
    [SerializeField] float maxFOV=120f;
    [SerializeField] float zoomDur=1f;
    [SerializeField] float zoomSpeedModifier=4f;
    CinemachineCamera cinemachineCamera;
    void Awake()
    {
        cinemachineCamera=GetComponent<CinemachineCamera>();
    }
    public void ChangeCamerFOV(float moveSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(moveSpeed));
        if (moveSpeed>0)speedUpParticles.Play();    
    }
    IEnumerator ChangeFOVRoutine(float moveSpeed)
    {
        float startFOV=cinemachineCamera.Lens.FieldOfView;
        float targetFOV=Mathf.Clamp(startFOV+moveSpeed*zoomSpeedModifier,minFOV, maxFOV);
        float elapsedTime=0;
        while(elapsedTime<zoomDur)
        {
            float t=elapsedTime/zoomDur;
            elapsedTime+=Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView=Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }
        
        cinemachineCamera.Lens.FieldOfView=targetFOV;    
    }
}
