using UnityEngine;

public class interaction : MonoBehaviour
{



    public void Interact(string triggerID)
    {
        // В зависимости от идентификатора триггера выполняем разные действия
        switch (triggerID)
        {
            case "suicide":
                Debug.Log("Взаимодействие с триггером 1");
                // Действия для триггера 1
                break;

            case "takebook":
                Debug.Log("Взаимодействие с триггером 2");
                // Действия для триггера 2
                break;

            default:
                Debug.Log("Неизвестный триггер");
                break;
        }
    }
}
