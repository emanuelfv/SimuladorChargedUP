using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoRobo : MonoBehaviour
{
    [SerializeField] float ForcaMotoraFinal, ForcaMotoraInicial, Freio, velocidadeDoBraco, velocidadeDoIntake;
    [SerializeField] float movimentarBraco, movimentarIntake;
    [SerializeField] Transform DriveTrain, Braco, Intake;
    [SerializeField] WheelCollider RodasEquerda1, RodasEquerda2, RodasDireita1, RodasDireita2, RodasEsquerdaParaTracao, RodasDireitaParaTracao;
    [SerializeField] Rigidbody gravidade;
    [SerializeField] Transform JoyStick, MancheObj;
    float manchePosition, mancheAngulo;
    public float movimentar, rotacionar, potenciaMotor;
    public float potenciometro = 2f;
    
    void Start() 
    {    
        //Manche por completo
        gravidade = GetComponent<Rigidbody>();
        MancheObj.eulerAngles = new Vector3(MancheObj.eulerAngles.x, MancheObj.eulerAngles.y - 90f, MancheObj.eulerAngles.z);
    }

    void Update()
    {
        Potenciometro();
        Tracao();
        MovimentandoBracoComJoystick();
        MovimentandoIntakeComJoystick();
        Manche();
    }

    void Tracao()
    {
    //Para detectar o Manche
        // potenciaMotor = Input.GetAxisRaw("Potencia do motor") * 10;
        movimentar = -Input.GetAxisRaw("Manete Vertical") * ForcaMotoraFinal;
        rotacionar += Input.GetAxisRaw("Manete Rotation") * 3 * potenciaMotor;

    //Para fazer o Drive Train se movimentar
        if(Input.GetAxisRaw("Manete Vertical") != 0)
        {
        RodasEsquerdaParaTracao.motorTorque = movimentar;
        RodasDireitaParaTracao.motorTorque = movimentar;
        }else{
            RodasEsquerdaParaTracao.motorTorque = 0f;
            RodasDireitaParaTracao.motorTorque = 0f;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotacionar, transform.eulerAngles.z);        
    }

    //Movimentos com o manche
    void MovimentandoBracoComManche()
    {
        if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.JoystickButton5))
        {
            movimentarBraco -= Time.deltaTime * velocidadeDoBraco;

            //Alinhamento do Intake com o Braço
            movimentarIntake -= Time.deltaTime * velocidadeDoIntake;
        }
        else if(Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.JoystickButton3))
        {
            movimentarBraco += Time.deltaTime * velocidadeDoBraco;

            //Alinhamento do Intake com o Braço
            movimentarIntake += Time.deltaTime * velocidadeDoIntake;
        }
        if (movimentarBraco <= -90) movimentarBraco = -90;
        if (movimentarBraco >= 0) movimentarBraco = 0;

        Braco.eulerAngles = new Vector3(Braco.eulerAngles.x, Braco.eulerAngles.y, movimentarBraco);

        #region Movimentação regular ao braço
                //Intake.eulerAngles = new Vector3(Intake.eulerAngles.x, Intake.eulerAngles.y, movimentarIntake);
        #endregion
    }

    //Movimentos com o manche
    void MovimentandoIntakeComManche()
    {
        if(Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.JoystickButton4))
        {
            movimentarIntake -= Time.deltaTime * velocidadeDoIntake;
        }
        else if(Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.JoystickButton2))
        {
            movimentarIntake += Time.deltaTime * velocidadeDoIntake;
        }
        if (movimentarIntake <= -90) movimentarIntake = -90;
        if (movimentarIntake >= 0) movimentarIntake = 0;

        Intake.eulerAngles = new Vector3(Intake.eulerAngles.x, Intake.eulerAngles.y, movimentarIntake);
    }

    //Movimentos com o Joystick
    void MovimentandoBracoComJoystick()
    {
        // Levantar braço
        if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.JoystickButton7))
        {
            movimentarBraco -= Time.deltaTime * velocidadeDoBraco;

            //Alinhamento do Intake com o Braço
            movimentarIntake -= Time.deltaTime * velocidadeDoIntake;
        }

        // Abaixar braço
        else if(Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.JoystickButton6))
        {
            movimentarBraco += Time.deltaTime * velocidadeDoBraco;

            //Alinhamento do Intake com o Braço
            movimentarIntake += Time.deltaTime * velocidadeDoIntake;
        }
        if (movimentarBraco <= -90) movimentarBraco = -90;
        if (movimentarBraco >= 0) movimentarBraco = 0;

        Braco.eulerAngles = new Vector3(Braco.eulerAngles.x, Braco.eulerAngles.y, movimentarBraco);
    }

    //Movimentos com o Joystick
    void MovimentandoIntakeComJoystick()
    {
        // Levantar intake
        if(Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.JoystickButton5))
        {
            movimentarIntake -= Time.deltaTime * velocidadeDoIntake;
        }

        // Abaixar intake
        else if(Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.JoystickButton4))
        {
            movimentarIntake += Time.deltaTime * velocidadeDoIntake;
        }
        if (movimentarIntake <= -90) movimentarIntake = -90;
        if (movimentarIntake >= 10) movimentarIntake = 10;

        Intake.eulerAngles = new Vector3(Intake.eulerAngles.x, Intake.eulerAngles.y, movimentarIntake);
    }

    void Potenciometro()
    {
        //Para nunca ser 0
        potenciometro = 2f;
        //Para estar sempre recebendo o valor do potênciometro
        potenciaMotor = potenciometro - Input.GetAxisRaw("Potencia do motor");
        
        //Para manter a velocidade inicial
        ForcaMotoraInicial = 150f;
        ForcaMotoraFinal = ForcaMotoraInicial * potenciaMotor * potenciaMotor;
    }

    void Manche()
    {
        //Movimento vertical
        float mancheVertical = Input.GetAxisRaw("Manete Vertical") * 150;
        float mancheRotacional = Input.GetAxisRaw("Manete Rotation") * 180;

        manchePosition += Time.deltaTime * mancheVertical;
        mancheAngulo += Time.deltaTime * mancheRotacional;
       
        //Debug.Log(manchePosition);

        if (manchePosition <= -25) manchePosition = -25;
        if (manchePosition >= 25) manchePosition = 25;
        
        if (mancheAngulo <= -25) mancheAngulo = -25;
        if (mancheAngulo >= 25) mancheAngulo = 25;

        //Para voltar para o lugar
        if (Input.GetAxisRaw("Manete Rotation") == 0) mancheAngulo = 0;
        if (Input.GetAxisRaw("Manete Vertical") == 0) manchePosition = 0;

        //Movimento rotacional
        JoyStick.eulerAngles = new Vector3(JoyStick.eulerAngles.x, mancheAngulo - 90f, manchePosition);
    }

}
