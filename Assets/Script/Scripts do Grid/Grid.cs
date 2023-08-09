using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //Objeto de jogo dentro do GRID
    [SerializeField] Transform GamePiece;
    static int pontos;

    void Update() 
    {
        GamePieceDentroDoGrid();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Game Piece")
        {
            pontos++;
            Debug.Log("Colidiu papai");
            GamePiece = collision.transform.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Game Piece")
        {
            pontos--;
            Debug.Log("Eita, saiu");
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
