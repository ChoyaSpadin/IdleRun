using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forcaPulo = 800;

    public LayerMask layerChao;

    public float distanciaMinimaChao = 1;

    private bool estaNoChao;

    private float pontos;

    private float highscore;

    public float multiplacadorPontos = 1;

    public Text pontosText;

    public Text highscoreText;

    public Animator animatorCompoent;

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
        highscoreText.text = $"Highscore: {Mathf.FloorToInt(highscore)}";
    }

    void Update()
    {
        pontos += Time.deltaTime * multiplacadorPontos;

        pontosText.text = $"Pontos: {Mathf.FloorToInt(pontos)}";

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            correndo();
        }
    }

    void correndo()
    {
        animatorCompoent.SetBool("pulando", false);
    }

    void Pular()
    {
        if (estaNoChao)
        {
            rb.AddForce(Vector2.up * forcaPulo);
            animatorCompoent.SetBool("pulando", true);
        }
    }

    private void FixedUpdate()
    {
        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            if (pontos > highscore)
            {
                highscore = pontos;

                PlayerPrefs.SetFloat("HIGHSCORE", highscore);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
