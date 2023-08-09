using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieces : MonoBehaviour
{
    [SerializeField] bool restringirToque = false;
    [SerializeField] float recolDeFalta;
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Game Piece" && restringirToque == false)
        {
            Debug.Log("Vissh perdeu ponto");
            Placar.faltasAzul += 2.5f;
            restringirToque = true;
            recolDeFalta = recolDeFalta + Time.deltaTime;
        }
    }
}
