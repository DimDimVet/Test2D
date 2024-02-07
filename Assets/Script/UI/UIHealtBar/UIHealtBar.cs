using UnityEngine;
using UnityEngine.UI;

public class UIHealtBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject trackingObject;
    //êýø
    private int thisHash;
    private Camera currentCamera;
    private Canvas canvas;
    //private Construction cameraObject, thisObject;

    private bool isRun = false;
    private void GetSet()
    {
        canvas = GetComponent<Canvas>();
        //cameraObject = GetCamera();
        //currentCamera = cameraObject.CameraComponent;
        canvas.worldCamera = currentCamera;
        thisHash = trackingObject.GetHashCode();
        //thisObject = GetObjectHash(thisHash);
        //if (thisObject.HealtEnemy != null)
        //{
        //    slider.maxValue = thisObject.HealtEnemy.HealtCount;
        //    slider.value = thisObject.HealtEnemy.HealtCount;
        //}
        //else if (thisObject.HealtPlayer != null)
        //{
        //    slider.maxValue = thisObject.HealtPlayer.HealtCount;
        //    slider.value = thisObject.HealtPlayer.HealtCount;
        //}
    }
    //private void OnEnable()
    //{
    //    OnGetUIDamage += ThisUIDamage;
    //}
    //private void OnDisable()
    //{
    //    OnGetUIDamage -= ThisUIDamage;
    //}
    private void ThisUIDamage(int getHash, int healt)
    {
        if (thisHash == getHash) { SetUIDamage(healt); }
    }
    private void SetUIDamage(int healt)
    {
        slider.value = healt;
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            if (slider != null & currentCamera != null & trackingObject != null) { isRun = true; }
            else { isRun = false; GetSet(); }
        }
    }
    void Update()
    {
        if (!isRun)
        {
            GetIsRun();
            return;
        }
    }
    //private void LateUpdate()
    //{
    //    this.gameObject.transform.LookAt(currentCamera.transform);
    //}
}
