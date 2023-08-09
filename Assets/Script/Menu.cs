using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string[] Cenas;
    public int numeroDaCena;
    void Start()
    {
        //Indicar que a cena está sendo carregada
        Debug.Log("Carregamento de cena ativado...");
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            NavegarEntreCenas();
        }
    }
    public void NavegarEntreCenas()
    {
        Debug.Log("Estamos carregando: " + Cenas[numeroDaCena]);
        SceneManager.LoadScene(Cenas[numeroDaCena]);
    }
    
}
