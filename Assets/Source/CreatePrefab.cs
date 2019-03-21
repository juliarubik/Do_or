using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    private Door door1;
    private Door door2;
    private Door door3;
    private Door door4;

    private void Start()
    {
        // Создание экземпляров класса Door с использованием необязательных и именованных параметров.
        door1 = new Door(true, true);
        door2 = new Door(false, true, rotation: 50, speed: 8);
        door3 = new Door(false, true, rotation: 180, speed: 1);
        door4 = new Door(true, true, rotation: 130, speed: 1);
    }

    private void Update()
    {
        door1.OpenClose();
        door2.OpenClose();
        door3.OpenClose();
        door4.OpenClose();
    }

}
