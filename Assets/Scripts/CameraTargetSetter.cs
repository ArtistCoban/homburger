using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetSetter : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    void Update()
    {
        if (virtualCamera.Follow == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                virtualCamera.Follow = player.transform;
                Debug.Log("Kamera follow hedefi atandý: " + player.name);
            }
        }
    }
}
