using UnityEngine;

public class Orbitre : MonoBehaviour
{
    public float vitesse;
    public GameObject objetCible;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(objetCible.transform.position, Vector3.forward, vitesse * Time.deltaTime);
    }
}
