using UnityEngine;

/// <summary>
/// Класс CreatePrefab создаёт экземпляры класса Door.
/// </summary>
/// <remarks>
/// Через параметры можно задать скорость, угол и ось вращения
/// двери отдельно для каждого экземпляра.
/// </remarks>
public class CreatePrefab : MonoBehaviour
{
    /// <summary>
    /// Здесь объявляются экземпляры класса Door.
    /// </summary>
    private Door _door1;
    private Door _door2;
    private Door _door3;

    /// <summary>
    /// Здесь создаются экземпляры класса Door.
    /// </summary>
    private void Start()
    {
        /// <example>
        /// Примеры экземпляров (Параметры можно передавать любые).
        /// </example>
        _door1 = new Door(true, true);
        _door2 = new Door(false, true, rotation: 50, speed: 8);
        _door3 = new Door(false, true, rotation: 180, speed: 1);
    }

    /// <summary>
    /// Здесь выполняется функция отдельно для каждого экземпляра,
    /// отвечающая за открытие и закрытие двери.
    /// </summary>
    private void Update()
    {
        _door1.OpenClose();
        _door2.OpenClose();
        _door3.OpenClose();
    }
}
