using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class FocaNoAviao : MonoBehaviour
{
    [Header("Configurações do avião")]
    [SerializeField]private Transform aviao;
    [SerializeField]private Transform[] targetsAviao;   

    [SerializeField]public float velocidadeRotacao = 5.0f;

    [Header("Configurações de menssage")]
    [SerializeField]private string message = "Destruindo forças inimigas!";
    private bool mensagemMostrada = false;
    public float velocidade = 100f;
    public GameObject bala;
    public Transform cano;
    public float intervalo = 0.1f;
    public float forçaBala = 2f;

    private float tempo;
    public void Start(){

    }

    public void BuscaAviao(){
        this.aviao = FindObjectOfType<PlayerBase>()?.gameObject?.transform;
        this.targetsAviao = FindObjectsOfType<PlayerBase>()?.Select(x=>x.gameObject.transform).ToArray();
    }
    private void Update()
    {
        BuscaAviao();
        VerificaAlturaDoAviao();
    }

    private void Atirar()
    {
            //incrmente o tempo do tiro
            tempo += Time.deltaTime;

            //verifica se o tempo decorrido é maior ou menor que o intervalo do termpo do tiro
                //instancia a bala pelo cano da metralhadora
                GameObject novaBala = Instantiate(bala, cano.position, cano.rotation);

                //ajusta a rotaçã da bala, nem sempre é nescessario usar
                novaBala.transform.Rotate(90,0,0);

                //destroy a balapara ajuste da ememoria
                Destroy(novaBala, 5);

                //é uma boa pratica dar um get, pegar o componente de fisica da bala antes de usar
                Rigidbody rb = novaBala.GetComponent<Rigidbody>();

                //aplica uma força de impulso na bala
                rb.AddForce(cano.forward * velocidade * forçaBala, ForceMode.Impulse);

    }
    private void VerificaAlturaDoAviao()
    {
        
        if (targetsAviao != null && targetsAviao.Any())
        {
            Debug.Log(this.aviao + " " + this.targetsAviao[0]);

            TorpedoSegueAviao();
            float alturaDoTorpedo = transform.position.y;
            float alturaDoAviao = targetsAviao[0].position.y;

            if (alturaDoAviao >= alturaDoTorpedo && !mensagemMostrada)
            {
                Atirar();
                mensagemMostrada = true;
            }
        }
    }
    private void TorpedoSegueAviao()
    {
        transform.LookAt(targetsAviao[0]);
    }
}


