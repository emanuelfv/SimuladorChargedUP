using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntakeComRayCast : MonoBehaviour
{
    //Necessário para o Intake funcionar
    public float alcanceDaColeta = 50;
    public Transform pivotColeta;
    public Transform intakeColeta;
    [SerializeField] WaitForSeconds tempoDeColeta = new WaitForSeconds(.1f); //INUTIL MAS UMA HORA VOU USAR
    [SerializeField] Camera Intake;
    [SerializeField] AudioSource somDeMotor;
    [SerializeField] LineRenderer guia;
    [SerializeField] float recolDeSugada;

    //Objeto de jogo dentro do Intake
    [SerializeField] Transform GamePiece;


    // Start is called before the first frame update
    void Start()
    {
        guia = GetComponent<LineRenderer>();
        somDeMotor = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ColetandoComoJoystick();
        FuncionamentoGamePiece();
    }

    void ColetandoComManche()
    {
        //Apertando o botão, ele coleta a Game Piece 
        if (Input.GetButton("Fire2"))
        {
            StartCoroutine(EfeitoDeColeta());
            Vector3 origemDaGuia = Intake.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            guia.SetPosition(0,pivotColeta.transform.position);

            if(Physics.Raycast(origemDaGuia, intakeColeta.transform.forward, out hit, alcanceDaColeta))
            {
                guia.SetPosition(1, hit.point);
            }else{
                guia.SetPosition(1, origemDaGuia + (intakeColeta.transform.forward * alcanceDaColeta));
            }

            if(hit.rigidbody != null)
            {
                Debug.Log("Você selecionou uma Game Piece");
                GamePiece = hit.transform.GetComponent<Transform>();
            }
        }
        //Apertando o botão, ele expulsa a Game Piece
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(EfeitoDeColeta());
            Vector3 origemDaGuia = Intake.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            guia.SetPosition(0,pivotColeta.transform.position);

            if(Physics.Raycast(origemDaGuia, intakeColeta.transform.forward, out hit, alcanceDaColeta))
            {
                guia.SetPosition(1, hit.point);
                Debug.Log("Você lançou uma Game Piece");
                //hit.rigidbody.AddForce(1.0f, 1.0f, 1.0f, ForceMode.Impulse);
                GamePiece = pivotColeta.transform.GetComponent<Transform>();
            }else{
                guia.SetPosition(1, origemDaGuia + (intakeColeta.transform.forward * alcanceDaColeta));
            }
        }
    }

    void ColetandoComoJoystick()
    {
        //Apertando o botão, ele coleta a Game Piece 
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            StartCoroutine(EfeitoDeColeta());
            Vector3 origemDaGuia = Intake.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            guia.SetPosition(0,pivotColeta.transform.position);

            if(Physics.Raycast(origemDaGuia, intakeColeta.transform.forward, out hit, alcanceDaColeta))
            {
                guia.SetPosition(1, hit.point);
            }else{
                guia.SetPosition(1, origemDaGuia + (intakeColeta.transform.forward * alcanceDaColeta));
            }

            if(hit.rigidbody != null)
            {
                Debug.Log("Você selecionou uma Game Piece");
                GamePiece = hit.transform.GetComponent<Transform>();
            }
        }
        //Apertando o botão, ele expulsa a Game Piece
        if (Input.GetKey(KeyCode.JoystickButton3))
        {
            StartCoroutine(EfeitoDeColeta());
            Vector3 origemDaGuia = Intake.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            guia.SetPosition(0,pivotColeta.transform.position);

            if(Physics.Raycast(origemDaGuia, intakeColeta.transform.forward, out hit, alcanceDaColeta))
            {
                guia.SetPosition(1, hit.point);
                Debug.Log("Você lançou uma Game Piece");
                //hit.rigidbody.AddForce(1.0f, 1.0f, 1.0f, ForceMode.Impulse);
                GamePiece = pivotColeta.transform.GetComponent<Transform>();
            }else{
                guia.SetPosition(1, origemDaGuia + (intakeColeta.transform.forward * alcanceDaColeta));
            }
        }
    }

    void FuncionamentoGamePiece()
    {
        //Objeto de jogo seguindo o Intake
        GamePiece.position = new Vector3(pivotColeta.position.x, pivotColeta.position.y, pivotColeta.position.z);
        GamePiece.eulerAngles = new Vector3(pivotColeta.eulerAngles.x, pivotColeta.eulerAngles.y, pivotColeta.eulerAngles.z);
    }
    private IEnumerator EfeitoDeColeta()
    {
        // somDeMotor.Play();
        guia.enabled = true;
        yield return tempoDeColeta;
        guia.enabled = false;
    }
}
