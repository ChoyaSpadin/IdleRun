using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public float delayInicial;

    public float delayEntreblock;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Gerarblock", delayInicial, delayEntreblock);
    }

    // Update is called once per frame
    void Gerarblock()
    {
        var quantidadeBlock = blockPrefabs.Length;
        var indiceAleatorio = Random.Range(0, quantidadeBlock);
        var blockPrefab = blockPrefabs[indiceAleatorio];
        Instantiate(blockPrefab, transform.position, Quaternion.identity);
    }
}
