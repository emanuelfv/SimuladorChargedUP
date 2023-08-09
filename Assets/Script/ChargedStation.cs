using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedStation : MonoBehaviour
{
    [SerializeField] bool colidindoComCharge = false;
    [SerializeField] bool marcarPontoDaCharge = false;
    [SerializeField] bool contagemDaCharge = false;
    [SerializeField] float esperarNaCharge;
    [SerializeField] int pontos;
    public Collider dentroDaCharge;

    // [SerializeField] float tempoPassadoDaPartida = Placar.tempoDejogo;

    // Update is called once per frame
    void Update()
    {
        if (Placar.tempoDejogo >= 105f)
        {
            if (colidindoComCharge == true)
            {
                if (transform.eulerAngles.z > 89.5 && transform.eulerAngles.z < 90.5f)
                {
                    contagemDaCharge = true;
                }
            }
        }

        if (contagemDaCharge)
        {
            //Contagem da Charge
            esperarNaCharge = esperarNaCharge + Time.deltaTime;
        }
        if (esperarNaCharge >= 10f)
        {
            marcarPontoDaCharge = true;
        }
        if (marcarPontoDaCharge)
        {
            Debug.Log("Ponto feito");
            Placar.pontosAzul += pontos;
            Placar.pontosDaCharge += pontos;
            marcarPontoDaCharge = false;
            contagemDaCharge = false;
            pontos = 0;
        }
    }
    private void OnTriggerEnter(Collider dentroDaCharge)
    {
        if (dentroDaCharge.gameObject.tag == "Player")
        {
            Debug.Log("Jogador tá dentro");
            colidindoComCharge = true;
        }
    }
    private void OnTriggerExit(Collider dentroDaCharge)
    {
        if (dentroDaCharge.gameObject.tag == "Player")
        {
            Debug.Log("Jogador tá fora");
            colidindoComCharge = false;
            contagemDaCharge = false;
        }
    }
}
