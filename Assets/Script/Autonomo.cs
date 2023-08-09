using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autonomo : MonoBehaviour
{   
    //Movimentos do braço no autonomo
    [SerializeField] float velocidadeDoBraco, velocidadeDoIntake;
    [SerializeField] float movimentarBraco, movimentarIntake;
    [SerializeField] Transform Robo, Braco, Intake;
    public float movimentar, rotacionar, potenciaMotor;

    //Temporizador do autonomo
    [SerializeField] float tempoDePartida;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoDePartida = tempoDePartida + Time.deltaTime;
        if (tempoDePartida < 5f)
        {
            MovimentandoBraco();
        }
    }

    void MovimentandoBraco()
    {
        Braco.eulerAngles = new Vector3(Braco.eulerAngles.x, Braco.eulerAngles.y, Braco.eulerAngles.z);
        Debug.Log("Macarrão");
    }
}
