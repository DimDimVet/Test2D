using Healt;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIHealtBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject trackingObject;
    [SerializeField] private Camera currentCamera;
    //êýø
    private int thisHash;
    private Canvas canvas;
    //private Construction cameraObject, thisObject;
    private bool isRun = false;

    private IHealt healtExecutor;
    [Inject]
    public void Init(IHealt h)
    {
        healtExecutor = h;
    }
    
    private void GetSet()
    {
        canvas = GetComponent<Canvas>();
        //cameraObject = GetCamera();
        //currentCamera = cameraObject.CameraComponent;
        //currentCamera = canvas.worldCamera;
        canvas.worldCamera = currentCamera;
        thisHash = trackingObject.GetHashCode();
        //thisObject = GetObjectHash(thisHash);
        //slider.maxValue = thisObject.HealtEnemy.HealtCount;
        //slider.value = thisObject.HealtEnemy.HealtCount;
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
    private void OnEnable()
    {
        thisHash = trackingObject.GetHashCode();
        healtExecutor.OnStatisticHealt += ThisUIDamage;
    }
    //private void OnDisable()
    //{
    //    OnGetUIDamage -= ThisUIDamage;
    //}
    private void ThisUIDamage(int getHash, int healt, int maxHealt)
    {
        
        if (thisHash == getHash) { SetUIDamage(healt, maxHealt); }
    }
    private void SetUIDamage(int healt, int maxHealt)
    {
        slider.maxValue = maxHealt;
        slider.value = healt;
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            if (slider != null & trackingObject != null) { isRun = true; }
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
    private void LateUpdate()
    {
        gameObject.transform.localScale = Vector3.right;
        gameObject.transform.LookAt(currentCamera.transform);
    }
}
