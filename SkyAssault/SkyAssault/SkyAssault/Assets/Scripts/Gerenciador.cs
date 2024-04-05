using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour
{

    [SerializeField] private Transform[] listAviao;

    private float pontos = 0;

    private static Gerenciador _instancia ;


    public TextMeshProUGUI pontosTextUI;

    public static Gerenciador Instancia{
        get{ 
            if(_instancia == null){
                var go = new GameObject("Gerenciador");
                _instancia = go.AddComponent<Gerenciador>();
            }
            return _instancia; 
        }
    }
    void Awake(){
        DontDestroyOnLoad(this);
        _instancia = this;

        if(this.pontosTextUI!=null){
            this.pontosTextUI.enabled = false;
        }
    }

    void Start()
    {
        
    }

    private int indiceAviao = 0;
    private Transform aviaoJogador; 
    public void EscolheAviao(int indiceAviao){
        this.indiceAviao = indiceAviao;
    }

    public void IniciaJogo(){
        if(this.aviaoJogador != null){
            Destroy(this.aviaoJogador.gameObject);
        }

        this.pontos = 0;
        this.AtualizaPontos();

        this.aviaoJogador = GameObject.Instantiate(this.listAviao[this.indiceAviao]);
        var cameraAviao = Camera.main.GetComponent<CameraAviao>();
        if(cameraAviao!=null){
            cameraAviao.alvo = this.aviaoJogador;
            cameraAviao.ResetaPosicao();
        }
    }

    public void TerminaJogo(){

    }

    public void ReiniciaJogo(){
        this.IniciaJogo();
    }

    public void AtualizaPontos(){
        if(this.pontosTextUI!=null){
            if(!this.pontosTextUI.enabled){
                this.pontosTextUI.enabled = true;
            }
            this.pontosTextUI.text = pontos.ToString();
        }
    }
    public void AdicionaPontos(float pontos){
        this.pontos += pontos;
        this.AtualizaPontos();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            this.ReiniciaJogo();
        }
    }


}
