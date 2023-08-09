using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{
    //Durante a partida
    public Text tempoDePartidaTXT;
    public Text pontuacao;
    public Text faltas;

    //Pós partida
    public Text faltasTelaFinal;
    public Text gridTelaFinal;
    public Text chargeTelaFinal;
    public Text autonomoTelaFinal;
    
    //Tempo de partida
    [SerializeField] float segundos;
    [SerializeField] int minutos;
    public static float tempoDejogo;

    //Tela de fim de jogo
    public GameObject telaFimDeJogo;
    public GameObject pontosFimDeJogo;

    //Pontuação do time Azul
    public static int pontosAzul = 0;
    public static float faltasAzul = 0.0f;
    
    //Pontuação do time Vermelho
    public static int pontosVermelho = 0;

    //Para o placa final
    public static int pontosDaCharge;
    public static int pontosDoGrid;
    public static int pontosDoAutonomo;

    void Update()
    {
        tempoDejogo = tempoDejogo + Time.deltaTime;
        Temporizador();
        Pontuacao();
        // Debug.Log(pontosAzul);
    }

    void Temporizador()
    {
        segundos = segundos - Time.deltaTime;

        if (segundos <= 0 && minutos != 0)
        {
            minutos --;
            segundos = 59f;
        }
        if (segundos <= 0 && minutos == 0)
        {
            Debug.Log("Fim de jogo");
            FimDeJogo();
        }

        tempoDePartidaTXT.text = $"{minutos}:{Math.Round(segundos)}";
    }
    
    void Pontuacao()
    {
        //Tela inicial
        pontuacao.text = $"{pontosAzul}";
        faltas.text = $"{Math.Round(faltasAzul)}";
        
        //Tela final
        faltasTelaFinal.text = $"{Math.Round(faltasAzul)}";
        gridTelaFinal.text = $"{pontosDoGrid}";
        chargeTelaFinal.text = $"{pontosDaCharge}";
        autonomoTelaFinal.text = $"{pontosDoAutonomo}";
    }

    void FimDeJogo()
    {
        telaFimDeJogo.SetActive(true);

        //Mostrando a pontuação
        if(segundos < -5f)
        {
            pontosFimDeJogo.SetActive(true);;
        }
    }
}
