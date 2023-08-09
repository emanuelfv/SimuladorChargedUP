using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeGrid : MonoBehaviour
{
    //Objeto de jogo dentro do GRID
    [SerializeField] Transform GamePiece;
    [SerializeField] int pontos;

    void Update()
    {
        GamePieceDentroDoGrid();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Game Piece" && collision.gameObject.layer == 7)
        {
            Placar.pontosAzul += pontos;
            Placar.pontosDoGrid += pontos;
            Debug.Log("Colidiu");
            GamePiece = collision.transform.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Game Piece" && collision.gameObject.layer == 7)
        {
            Placar.pontosAzul -= pontos;
            Placar.pontosDoGrid -= pontos;
            Debug.Log("Saiu");
            GamePiece = transform.GetComponent<Transform>();
        }
    }
    void GamePieceDentroDoGrid()
    {
        //Objeto de jogo seguindo o Intake
        GamePiece.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GamePiece.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
