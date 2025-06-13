using UnityEngine;

public class Recollect_Objects : MonoBehaviour
{
    public GameObject Door;
     float puntaje;
    bool puedeAbrirPuerta = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Door.SetActive(false);
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (puntaje == 2)
        {
            Door.SetActive(true);
        }

        if (puedeAbrirPuerta && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Abriste la puerta y ya puedes salir");
            // Puedes agregar aquí una animación, o desactivar la puerta, etc.
            // Por ejemplo: Door.SetActive(false);
        }




    }


    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Colisioné con: " + col.gameObject.name);
        if (col.gameObject.CompareTag("soccer_boot"))
        {
            Debug.Log("Recogiste un objeto");
            Destroy(col.gameObject); // Desaparece el objeto
            //col.gameObject.SetActive(false);
            puntaje = puntaje + 1;
        }

        if (col.gameObject.CompareTag("bottle"))
        {
            Debug.Log("Recogiste un objeto");
            Destroy(col.gameObject); // Desaparece el objeto
            //col.gameObject.SetActive(false);
            puntaje = puntaje + 1;
        }

        if ((col.gameObject.CompareTag("Door")) && (puntaje==2))
        {
            Debug.Log("Estás frente a la puerta. Presiona P para abrirla.");
            puedeAbrirPuerta = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Door"))
        {
            puedeAbrirPuerta = false;
        }
    }


}
