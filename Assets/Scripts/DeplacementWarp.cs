using UnityEngine;

public class DeplacementWarp : MonoBehaviour
{
    public bool cheminInversee;
    public float vitesseY;
    public float limiteHaute;
    public float limiteBasse;

    private float positionX;
    private bool downScale = false;
    private float scale = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positionX = Random.Range(-2f, 2f);
        vitesseY = Random.Range(1.5f, 4f);

        Transform transformX = GetComponent<Transform>();
        transformX.Translate(positionX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        // logique de déplacement
        positionX = transform.position.x;
        

        if (cheminInversee)
        {
            transform.position -= new Vector3(0, vitesseY, 0) * Time.deltaTime;

            if (transform.position.y < limiteBasse)
            {
                transform.position = new Vector3(positionX, limiteHaute);
            }
        }
        else
        {
            transform.position += new Vector3(0, vitesseY, 0) * Time.deltaTime;

            if (transform.position.y > limiteHaute)
            {
                transform.position = new Vector3(positionX, limiteBasse);
            }
        }

        // logique de l'échelle

        if (transform.localScale.x >= 4f)
        {
            downScale = true;
            transform.localScale -= new Vector3(scale, scale, 0) * Time.deltaTime;
        }
        else if (transform.localScale.x >= 1f && downScale)
        {
            transform.localScale -= new Vector3(scale, scale, 0) * Time.deltaTime;
        }
        else if (transform.localScale.x <= 4f && !downScale)
        {
            transform.localScale += new Vector3(scale, scale, 0) * Time.deltaTime;
        }
        else if (transform.localScale.x <= 1f)
        {
            downScale = false;
            transform.localScale += new Vector3(scale, scale, 0) * Time.deltaTime;
        }
    }
}
