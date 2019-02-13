using UnityEngine;

public class Door
{
    private GameObject doorController;

    private GameObject doorBody;

    private float rotation;

    private float speed;

    private bool isOpen;

    public Door
        (
        bool isLeft, 
        bool isOpen, 
        float rotation = 120, 
        float speed = 5, 
        string door_controller = "DoorController", 
        string door_body = "DoorBody"
        )
    {
        this.rotation = rotation;
        this.speed = speed;
        this.isOpen = isOpen;
        doorController = Object.Instantiate(Resources.Load(door_controller, typeof(GameObject))) as GameObject;
        doorBody = Object.Instantiate(Resources.Load(door_body, typeof(GameObject))) as GameObject;
        Shift(isLeft);
        doorBody.transform.parent = doorController.transform;
    }

    public void OpenClose()
    {
        rotation = isOpen ? rotation : 0;

        doorController.transform.rotation = Quaternion.Slerp
        (
            doorController.transform.rotation,
            Quaternion.Euler
            (
                doorController.transform.rotation.x,
                rotation,
                doorController.transform.rotation.z
            ),
            speed * Time.deltaTime
        );
    }

    // Сдвиг оси вращения.
    private void Shift(bool isLeft)
    {
        float width = doorBody.transform.localScale.z / 2;

        width = isLeft ? ((-1) * width) : width;

        doorController.transform.position = new Vector3
        (
            doorController.transform.position.x, 
            doorController.transform.position.y, 
            doorController.transform.position.z + width
        );
    }
}
