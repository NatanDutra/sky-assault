using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MenuEscolha;


    public void BtnAdicionarAviao(int indiceAviao)
    {
        Debug.Log("Aviao Adicionado");

        Gerenciador.Instancia.EscolheAviao(indiceAviao);
        Gerenciador.Instancia.IniciaJogo();

        MenuEscolha.SetActive(false);
    }
    
}
