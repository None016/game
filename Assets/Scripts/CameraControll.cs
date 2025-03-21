using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform target; // Объект, за которым следует камера (например, игрок)
    public float smoothing = 5f; // Плавность перемещения камеры

    private Vector3 offset; // Смещение камеры относительно цели

    void Start()
    {
        // Вычисляем начальное смещение камеры относительно цели
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Вычисляем новую позицию камеры
        Vector3 targetCamPos = target.position + offset;

        // Плавно перемещаем камеру к новой позиции
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
