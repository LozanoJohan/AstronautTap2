using UnityEngine;

public class Anchor : MonoBehaviour
{
    public float speed;
    public float minDistance;
    public GameObject anchor;
    private bool isAnchoring;
    // El ancla es un line renderer
    private LineRenderer anchorLine;
    public static Anchor I;

    // Start is called before the first frame update
    void Awake()
    {
        if (I == null) I = this;
        else Destroy(this);
    }

    void Start()
    {
        anchorLine = GetComponent<LineRenderer>();
    }

    // Función de Unity, se ejecuta un poco después del "Update"
    void LateUpdate()
    {
        // No hacer nada si el juego no ha empezado
        if (!GameManager.I.gameStarted) return;

        // La primera punta del ancla siempre está con el personaje
        anchorLine.SetPosition(0, Player.I.gameObject.transform.position);

        if (!isAnchoring)
        {
            anchor.transform.position = Player.I.gameObject.transform.position;
            anchorLine.SetPosition(1, Player.I.gameObject.transform.position);
        }
    }

    public bool HasReachedTarget()
    {
        bool isTouched = TouchS.I.touchedObj != null;
        float distance = Vector2.Distance(anchorLine.GetPosition(1), TouchS.I.gameObject.transform.position);

        return distance < minDistance && isTouched;
    }

    public void Unanchor()
    {
        isAnchoring = false;
    }

    public void AnchorTo(GameObject obj)
    {
        isAnchoring = true;
        // Mueve el ancla hacia el objeto touched, asegurándose de usar Vector3 para incluir la Z en la interpolación.
        Vector3 targetPosition = Vector3.Lerp(anchorLine.GetPosition(1), obj.transform.position,
                                                    Time.deltaTime * speed);

        anchor.transform.position = targetPosition;

        // Actualiza la posición del ancla en el line renderer. El segundo parámetro es la posición del ancla.
        anchorLine.SetPosition(1, targetPosition);
    }
}
