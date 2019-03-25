using UnityEngine;

/// <summary>
/// Класс CreatePrefab создаёт экземпляры класса Door.
/// </summary>
/// <remarks>
/// Через параметры можно задать скорость, угол и ось вращения
/// двери отдельно для каждого экземпляра.
/// </remarks>
public class CreatePrefab: MonoBehaviour
{
    /// <summary>
    /// Здесь объявляются экземпляры класса Door.
    /// </summary>
    private Door door1;
    private Door door2;
    private Door door3;

    /// <summary>
    /// Здесь создаются экземпляры класса Door.
    /// </summary>
    private void Start()
    {
        /// <example>
        /// Примеры экземпляров (Параметры можно передавать любые).
        /// </example>
        door1 = new Door(true, true);
        door2 = new Door(false, true, rotation: 50, speed: 8);
        door3 = new Door(false, true, rotation: 180, speed: 1);
    }

    /// <summary>
    /// Здесь выполняется функция отдельно для каждого экземпляра,
    /// отвечающая за открытие и закрытие двери.
    /// </summary>
    private void Update()
    {
        door1.OpenClose();
        door2.OpenClose();
        door3.OpenClose();
    }
}
