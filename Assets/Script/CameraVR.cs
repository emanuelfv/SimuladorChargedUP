using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVR : MonoBehaviour
{
    public bool travarMouse = true; //Vai controlar se o cursor do mouse será exibido
    public float sensibilidade = 2.0f; //Vai controlar a sensibilidade do mouse

    private float mouseX = 0.0f, mouseY = 0.0f; //Serão nossas variáveis de rotação do mouse
    void Start()
    {
        if (!travarMouse)
        {
            return;
        }

        Cursor.visible = false; //Oculta o cursor do mouse
        Cursor.lockState = CursorLockMode.Locked; //Trava o cursor no centro da tela
    }

    void Update()
    {
        //Incrementa um valor para o eixo X que será multiplicado conforme a sensibilidade
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;
        //Incrementa um valor para o eixo Y que será multiplicado conforme a sensibilidade invertendo o eixo
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;
        
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
