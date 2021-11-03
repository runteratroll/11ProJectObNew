
using UnityEngine;

public class DataInputManager : MonoBehaviour
{
    public DataInput inputData;

    // Update is called once per frame
    void Update()
    {
        WriteInputData();
    }

    void WriteInputData()
    {
        inputData.isPressed = Input.GetMouseButtonDown(0);
        inputData.isHeld = Input.GetMouseButton(0);
        inputData.isReleased = Input.GetMouseButtonUp(0);
    }
}
