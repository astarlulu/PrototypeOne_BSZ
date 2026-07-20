using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Camera_1;
    public GameObject Camera_2;
    public int CameraManager;

    public void ManageCamera()
    {
        if (CameraManager == 0)
        {
            Cam_2();
            CameraManager = 1;
        }
        else
        {
            Cam_1();
            CameraManager = 0;
        }
    }

    void Cam_1()
    {
        Camera_1.SetActive(true);
        Camera_1.SetActive(false);
    }

    void Cam_2()
    {
        Camera_1.SetActive(false);
        Camera_1.SetActive(true);
    }
}
