using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raster : MonoBehaviour
{
    Renderer render;
    Texture2D texture;

    void Start()
    {
        render = GetComponent<Renderer>();

        texture = new Texture2D(101, 101);
        texture.filterMode = FilterMode.Point;

        render.material.mainTexture = texture;

        Refrash();
    }

    public void LineDDA(Vector2 p1, Vector2 p2, Color color)
    {
        Vector2 delta = p2 - p1;
        Vector2 ponto = p1;

        float passo = Mathf.Max(Mathf.Abs(delta.x), Mathf.Abs(delta.y));
        if (passo != 0) delta = delta / passo;
        for (int i = 0; i <= passo; i++)
        {
            texture.SetPixel((int)ponto.x, (int)ponto.y, color);
            ponto = ponto + delta;
        }
    }

    void Refrash()
    {
        // Coordenadas do quadrado
        Vector2 p1 = new Vector2(20, 20);
        Vector2 p2 = new Vector2(80, 20);
        Vector2 p3 = new Vector2(80, 80);
        Vector2 p4 = new Vector2(20, 80);



        // Desenho do quadrado
        LineDDA(p1, p2, Color.red);    // Linha inferior
        LineDDA(p2, p3, Color.blue);    // Linha direita
        LineDDA(p3, p4, Color.magenta);    // Linha superior
        LineDDA(p4, p1, Color.black);    // Linha esquerda

        texture.Apply();
    }
}
