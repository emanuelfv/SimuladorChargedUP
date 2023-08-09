using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float rodar;
    [SerializeField] float velocidade;

    void Update()
    {
        rodar += Time.deltaTime * velocidade;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rodar, transform.eulerAngles.z);
        // Time.deltaTime
    }
}
