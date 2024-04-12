
using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle Group", menuName = "Game/Obstacle Group")]
public class ObstacleGroupSO : ScriptableObject
{
    public enum Difficulty {
        Easy,
        Medium,
        Hard
    }
    public GameObject obstacles;
    public bool isFlippable;
    public float height = 18;
    public Difficulty difficulty;

    void OnEnable()
    {
        //GetHeight();
    }

    void GetHeight()
    {
        {
            float maxY = float.MinValue;
            float minY = float.MaxValue;

            // Iterar a través de todos los hijos del GameObject
            foreach (Transform child in obstacles.transform)
            {
                float childY = child.position.y;

                // Actualizar los valores minY y maxY según sea necesario
                if (childY > maxY) maxY = childY;
                if (childY < minY) minY = childY;
            }

            // Calcular la distancia entre el punto más alto y el más bajo
            height = maxY - minY;
        }
    }
}