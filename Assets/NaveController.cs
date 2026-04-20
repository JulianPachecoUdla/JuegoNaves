using UnityEngine;

public class NaveController : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad de movimiento de la nave
    private Rigidbody2D rb;       // Componente Rigidbody2D

    private Camera cam;           // Referencia a la c�mara principal
    private float anchoPantalla;  // Ancho de la pantalla en unidades del mundo
    private float altoPantalla;   // Alto de la pantalla en unidades del mundo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtener el componente Rigidbody2D
        cam = Camera.main;  // Obtener la c�mara principal

        // Calcular los l�mites de la pantalla en unidades del mundo
        anchoPantalla = cam.orthographicSize * cam.aspect;
        altoPantalla = cam.orthographicSize;
    }

    void Update()
    {
        // Obtener las entradas del jugador
        float movimientoHorizontal = Input.GetAxis("Horizontal");  // Teclas A/D o flechas izquierda/derecha
        float movimientoVertical = Input.GetAxis("Vertical");      // Teclas W/S o flechas arriba/abajo

        // Crear el vector de movimiento
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        // Mover la nave
        rb.linearVelocity = movimiento * velocidad;  // Aplicar la velocidad al Rigidbody2D

        // Limitar la posici�n de la nave dentro de los bordes de la pantalla
        LimitarPosicion();
    }

    // Funci�n para limitar la posici�n de la nave dentro de los l�mites de la pantalla
    void LimitarPosicion()
    {
        Vector3 posicion = transform.position;

        // Limitar la posici�n horizontal (izquierda/derecha)
        posicion.x = Mathf.Clamp(posicion.x, -anchoPantalla, anchoPantalla);

        // Limitar la posici�n vertical (arriba/abajo)
        posicion.y = Mathf.Clamp(posicion.y, -altoPantalla, altoPantalla);

        // Actualizar la posici�n de la nave
        transform.position = posicion;
    }
}