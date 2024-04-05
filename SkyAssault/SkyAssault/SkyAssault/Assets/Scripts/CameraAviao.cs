using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraAviao : MonoBehaviour
{

    public Transform alvo;
    public bool focaAviao = true;
    public bool segueAviao = true;

    public float altura = 1f;
    public float distancia = 2f;

    [Range(0.0f,1.0f)]
    public float atraso = 0f;

    private Vector3 cameraStartPosition;
    private Quaternion cameraStartRotation;

    void Awake()
    {
       this.cameraStartPosition = this.transform.position;
       this.cameraStartRotation = this.transform.rotation;
    }

    public void ResetaPosicao(){
        this.transform.position = this.cameraStartPosition;
        this.transform.rotation = this.cameraStartRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate(){
        if(alvo!=null){

            var camera = Camera.main;
            if(this.segueAviao){
                var novaPosicao = alvo.position + Vector3.up * altura + alvo.forward * -distancia;
                camera.transform.position = Vector3.Lerp(camera.transform.position, novaPosicao, Time.fixedDeltaTime * (1.0f - atraso)); 
            }

            if(this.focaAviao){
                camera.transform.LookAt(alvo,Vector3.up);
            }
        }
    }
}
