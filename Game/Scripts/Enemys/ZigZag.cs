using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{

    public float speed = 5f; //velocidade da nave
    public float amplitude = 2f; //amplitude do movimento
    public float frequency = 2f; //frequência do movimento

    private float timer = 0f;

    void Update()
    {
        //atualiza o timer
        timer += Time.deltaTime;

        //calcula o valor do movimento
        float movement = Mathf.Sin(timer * frequency) * amplitude;

        //movimenta a nave
        transform.position += new Vector3(movement, 0f, 0f) * Time.deltaTime;
    }
}
