using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad del movimiento
    public float rangoMovimiento = 10f;  // Rango máximo en el que el enemigo se moverá (de izquierda a derecha)
    public int colisionesMaximas = 5;  // Número máximo de colisiones antes de destruir al enemigo

    private Vector2 puntoInicio;  // Punto inicial de movimiento
    private bool moviendoDerecha = true;  // Dirección del movimiento (derecha o izquierda)
    private float anchoPantalla;  // Ancho de la pantalla en unidades del mundo
    private int contadorColisiones = 0;  // Contador de las colisiones

    void Start()
    {
        // Guardamos la posición inicial del enemigo
        puntoInicio = transform.position;

        // Obtener el ancho de la pantalla en unidades del mundo
        Camera cam = Camera.main;
        anchoPantalla = cam.orthographicSize * cam.aspect;
    }

    void Update()
    {
        // Mover al enemigo de izquierda a derecha dentro del rango
        MoverEnemigo();
    }

    void MoverEnemigo()
    {
        // Calcular la dirección de movimiento
        float movimiento = moviendoDerecha ? 1 : -1;

        // Mover el enemigo hacia la derecha o hacia la izquierda
        transform.Translate(Vector2.right * velocidad * movimiento * Time.deltaTime);

        // Comprobar si el enemigo ha llegado al límite del rango de pantalla
        if (transform.position.x >= anchoPantalla)
        {
            moviendoDerecha = false;  // Cambiar dirección hacia la izquierda
        }
        else if (transform.position.x <= -anchoPantalla)
        {
            moviendoDerecha = true;   // Cambiar dirección hacia la derecha
        }
    }

    // Método que se ejecuta cuando el enemigo colisiona con algo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Missile"))  // Si colisiona con un misil
        {
            contadorColisiones++;  // Incrementar el contador de colisiones
            if (contadorColisiones >= colisionesMaximas)  // Si llega a las colisiones máximas
            {
                Destroy(gameObject);  // Destruir el enemigo
            }
        }
    }
}