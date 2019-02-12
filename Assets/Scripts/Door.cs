using UnityEngine;

public class Door
{
    private GameObject doorController;

    private GameObject doorBody;

    private float rotationAngle;

    private float rotationSpeed;

    private bool isLeft;

    private bool isOpen;

    public Door(bool left, bool isOpen, float rotation = 120, float speed = 5, string door_controller = "DoorController", 
    string door_body = "DoorBody")
    {
        this.rotation = rotation;
        this.speed = speed;
        this.left = left;
        this.isOpen = isOpen;
        DoorController = Object.Instantiate(Resources.Load(door_controller, typeof(GameObject))) as GameObject;
        DoorBody = Object.Instantiate(Resources.Load(door_body, typeof(GameObject))) as GameObject;
        Movement();
        SetParent();
    }

    // Сдвиг оси вращения.
    public void Movement()
    {
        if (left)
        {
            LeftShift();
        }
        else
        {
            RightShift();
        }
    }

    public void OpenClose()
    {
        if (isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    // Сдвиг пустышки влево.
    private void LeftShift()
    {
        float width = DoorBody.transform.localScale.z / 2;
        DoorController.transform.position = new Vector3(DoorController.transform.position.x, DoorController.transform.position.y, 
        DoorController.transform.position.z - width);
    }

    // Сдвиг пустышки вправо.
    private void RightShift()
    {
        float width = DoorBody.transform.localScale.z / 2;
        DoorController.transform.position = new Vector3(DoorController.transform.position.x, DoorController.transform.position.y, 
        DoorController.transform.position.z + width);
    }

    private void Open()
    {
        DoorController.transform.rotation = Quaternion.Slerp(DoorController.transform.rotation, Quaternion.Euler(DoorController.transform.rotation.x, 
        rotation, DoorController.transform.rotation.z), speed * Time.deltaTime);
    }

    private void Close()
    {
        DoorController.transform.rotation = Quaternion.Slerp(DoorController.transform.rotation, Quaternion.Euler(DoorController.transform.rotation.x,
        0, DoorController.transform.rotation.z), speed * Time.deltaTime);
    }

    public void SetParent()
    {
        DoorBody.transform.parent = DoorController.transform;
    }
}
