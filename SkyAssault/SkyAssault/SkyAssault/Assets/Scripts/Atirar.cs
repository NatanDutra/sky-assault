using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float velocidade = 50f;
    public GameObject bala;
    public Transform cano;
    public float intervalo = 0.1f;
    public float forçaBala = 2f;

    private float tempo;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            tempo += Time.deltaTime;

            if(tempo >= intervalo)
            {

                GameObject novaBala = Instantiate(bala, cano.position, cano.rotation);

                novaBala.transform.Rotate(90,0,0);
                Destroy(novaBala, 5);


                Rigidbody rb = novaBala.GetComponent<Rigidbody>();

                rb.AddForce(cano.forward * velocidade * forçaBala, ForceMode.Impulse);

                tempo = 0f;
            }
        }
    }
}
