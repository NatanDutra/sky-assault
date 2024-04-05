using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision other){

        if (other.gameObject.CompareTag("Cube")){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Gerenciador.Instancia.AdicionaPontos(1f);
        } 

        if (other.gameObject.CompareTag("Inimigo")){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Gerenciador.Instancia.AdicionaPontos(5f);
        } 

        
       
    }    

}
