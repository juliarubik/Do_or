using UnityEngine;

/// <summary>
/// Класс Door предоставляет конструктор с параметрами, 
/// функцию сдвига оси вращения двери, функцию открытия/закрытия двери.
/// </summary>
public class Door
{
    /// <summary>
    /// Объект, в который передается пустышка.
    /// </summary>
    private GameObject doorController;
    /// <summary>
    /// Объект, в который передается тело двери.
    /// </summary>
    private GameObject doorBody;
    /// <summary>
    /// Угол вращения двери.
    /// </summary>
    private float rotation;
    /// <summary>
    /// Скорость вращения двери.
    /// </summary>
    private float speed;
    /// <summary>
    /// Проверяет, открыта ли дверь.
    /// </summary>
    private bool isOpen;

    /// <summary>
    /// Конструктор класса Door, который создаёт единый префаб двери.
    /// </summary>
    /// <param name="isLeft">В какую сторону сдвинуть ось вращения.</param>
    /// <param name="isOpen">Открыть или закрыть дверь.</param>
    /// <param name="rotation">Угол вращения двери.</param>
    /// <param name="speed">Скорость вращения двери.</param>
    /// <param name="door_controller">Название объекта, которое необходимо
    /// подгрузить из папки "Resources" в качестве пустышки двери.</param>
    /// <param name="door_body">Название объекта, которое небходимо
    /// подгрузить из папки "Resources" в качестве тела двери.</param>
	public class Door(bool isLeft, bool isOpen, float rotation = 120, float speed = 5, string door_controller = "DoorController", string door_body = "DoorBody")
	{
        this.rotation = rotation;
        this.speed = speed;
        this.isOpen = isOpen;

        /// <summary>
        /// Создаются объект пустышки и объект тела двери.
        /// </summary>
        doorController = Object.Instantiate(Prefabs.Load(door_controller, typeof(GameObject))) as GameObject;
        doorBody = Object.Instantiate(Prefabs.Load(door_body, typeof(GameObject))) as GameObject;

        shift(isLeft);

        /// <summary>
        /// Делает тело двери дочерним относительно пустышки.
        /// </summary>
        doorBody.transform.parent = doorController.transform;
    }

    /// <summary>
    /// Функция открытия и закрытия двери.
    /// </summary>
    public void OpenClose()
    {
        rotation = isOpen ? rotation : 0;

        doorController.transform.rotation = Quaternion.Slerp
        (
            doorController.transform.rotation,
            Quaternion.Euler(doorController.transform.rotation.x, rotation, doorController.transform.rotation.z),
            speed * Time.deltaTime
        );
    }

    /// <summary>
    /// Функция сдвига оси вращения двери.
    /// </summary>
    /// <param name="isLeft">В какую сторону необходимо сдвинуть ось вращения.</param>
    private void shift(bool isLeft)
    {
        /// <summary>
        /// Половина ширины двери.
        /// </summary>
        float width = doorBody.transform.localScale.z / 2;

        width = isLeft ? ((-1) * width) : width;

        doorController.transform.position = new Vector3(
		doorController.transform.position.x, 
		doorController.transform.position.y, 
		doorController.transform.position.z + width);
    }
}
