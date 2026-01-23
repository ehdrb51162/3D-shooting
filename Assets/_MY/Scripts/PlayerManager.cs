using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    private StarterAssetsInputs input;
    private ThirdPersonController controller;
    private Animater anim;

    [Header("Aim")]
    [SerializeField]
    private CinemachineVirtualCamera aimCam;
    
    [SerializeField]
    private GameObject aimImage;
    // Start is called before the first frame update
    [SerializeField]
    private LayerMask tagetLayer;
    [SerializeField]
    private GameObject aimObj;
    [SerializeField]
    private float aimObjDis = 20f;
    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        controller = GetComponent<ThirdPersonController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AimCheck();
    }
    private void AimCheck()
    {
    
        if(input.aim)
        {
            AimControll(true);
            anim.SetLayerWeight(1,1);
            Vector3 targetPosition = Vector3.zero;
            Transform camTransform = Camera.main.transform;                
            RaycastHit hit;

            if(Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, tagetLayer))
            {
                //Debug.Log("Name : " + hit.transform.gameObject.name);
                targetPosition = hit.point;
                aimObj.transform.position = hit.point;
            }
            else
            {
                targetPosition = camTransform.position + camTransform.forward * aimObjDis;
                aimObj.transform.position = camTransform.position + camTransform.forward * aimObjDis;
            }

            Vector3 targetAim = targetPosition;

            targetAim.y = transform.position.y;
            Vector3 aimDir = (targetAim - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 50f);
        }
        else
        {
            AimControll(false);
            
            anim.SetLayerWeight(1,0);
        }
    }
    private void AimControll(bool isCheck)
    {
        aimCam.gameObject.SetActive(isCheck);
            aimImage.SetActive(isCheck);
            controller.isAimMove = isCheck;
    }
}
