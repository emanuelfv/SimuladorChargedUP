using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField] float tempoDasGamePieces;
    public Transform spawnCubos, spawnCones;
    public GameObject conePrefab, cuboPrefab;
    public Collider areaDeColetaAzul;
    public bool gamePieceColetada;
    
    void Start()
    {
        Instantiate(conePrefab, spawnCones.position, Quaternion.identity);
        Instantiate(cuboPrefab, spawnCubos.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        tempoDasGamePieces = tempoDasGamePieces + Time.deltaTime;

        if (tempoDasGamePieces >= 45f)
        {
            //Spawnar Cones
            Instantiate(conePrefab, spawnCones.position, Quaternion.identity);
            Instantiate(cuboPrefab, spawnCubos.position, Quaternion.identity);
            tempoDasGamePieces = 0f;
        }
    }
    private void OnTriggerEnter(Collider areaDeColetaAzul)
    {
        // Area Azul
        if (areaDeColetaAzul.gameObject.tag == "Game Piece")
        {
            Debug.Log("Tem objetos de jogo na zona de coleta");
            gamePieceColetada = true;
        }
        
        // // Area Vermelha Falta
        // if (areaDeColetaVermelha.gameObject.tag == "Player")
        // {
        //     Debug.Log("Area de coleta errada");
        //     Placar.faltasAzul += 5f;
        // }
    }
    private void OnTriggerExit(Collider areaDeColetaAzul)
    {
        if (areaDeColetaAzul.gameObject.tag == "Game Piece")
        {
            Debug.Log("Não tem objetos de jogo na zona de coleta");
            gamePieceColetada = true;
        }
    }
}
