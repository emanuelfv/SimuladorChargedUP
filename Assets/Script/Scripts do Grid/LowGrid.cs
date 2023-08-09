using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGrid : MonoBehaviour
{
    //Objeto de jogo dentro do GRID
    [SerializeField] Transform GamePiece;
    void Create()
    {
        GamePiece = GetComponent<Transform>();
    }

    void Update() 
    {
        GamePieceDentroDoGrid();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Game Piece")
        {
            Placar.pontosAzul += 2;
            Placar.pontosDoGrid += 2;
            Debug.Log("Colidiu");
            GamePiece = collision.transform.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Game Piece")
        {
             Placar.pontosAzul -= 2;
             Placar.pontosDoGrid -= 2;
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
