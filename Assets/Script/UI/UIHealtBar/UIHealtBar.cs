using Bulls;
using Healt;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIHealtBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject trackingObject;
    [SerializeField] private Camera currentCamera;
    private Vector3 flipPlus=new Vector3(1,1,1);
    private Vector3 flipMinus = new Vector3(-1, 1, 1);
    private int thisHash;
    private Canvas canvas;
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
        canvas.worldCamera = currentCamera;
        thisHash = trackingObject.GetHashCode();

    }
    private void OnEnable()
    {
        thisHash = trackingObject.GetHashCode();
        healtExecutor.OnStatisticHealt += ThisUIDamage;
    }
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
        if (trackingObject.transform.localScale.x > 0) { slider.transform.localScale = flipPlus; }
        else { slider.transform.localScale = flipMinus; }
        gameObject.transform.LookAt(currentCamera.transform);
    }
}
