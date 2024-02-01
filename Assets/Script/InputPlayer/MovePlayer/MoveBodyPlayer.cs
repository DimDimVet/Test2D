using Input;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using Zenject;

public class MoveBodyPlayer : MonoBehaviour
{
    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform pointStart;
    private float speedForward, speedBack/*, speedTurn*/;
    private float weight;
    private Rigidbody rigidbodyPlayer;
    //private Vector3 newPosition;
    private Vector3 eulerAngleVelocity;
    private Quaternion deltaRotation;
    private RaycastHit hit;
    private bool isRun = false;
    Vector3 yy;

    private IInput inputData;
    [Inject]
    public void Init(IInput x)
    {
        inputData = x;
    }

    void Start()
    {

        if (moveSettings == null) { print($"Не установлен Settings в MovePlayer"); }
        GetIsRun();
        GetSetting();
    }

    private void GetSetting()
    {
        speedForward = moveSettings.SpeedForward;
        speedBack = moveSettings.SpeedBack;
        eulerAngleVelocity.y = moveSettings.SpeedTurn;
        weight = moveSettings.Weight;
        rigidbodyPlayer.mass = weight;
        moveSettings.IsUpDate = false;
    }

    private void GetIsRun()
    {
        rigidbodyPlayer = gameObject.GetComponent<Rigidbody>();

        if (!(rigidbodyPlayer is Rigidbody))
        {
            rigidbodyPlayer = gameObject.AddComponent<Rigidbody>();
            rigidbodyPlayer.mass = weight;
            isRun = false;
        }
        else
        {
            isRun = true;
        }
    }

    private void Move()
    {
        
        if (isRun)
        {
            ////кнопки и канвас
            //if (inputData.Updata().Move.y > 0 )
            //{
            //    var f = transform.forward * speedForward;
            //    f.z = 0;
            //    rigidbodyPlayer.velocity = f;
            //    //newPosition = transform.position + (transform.forward) * speedForward * Time.deltaTime;
            //    //gameObject.transform.position = newPosition;
            //}
            //if (inputData.Updata().Move.y < 0 )
            //{
            //    var f = -transform.forward * speedForward;
            //    f.z = 0;
            //    rigidbodyPlayer.velocity = f;
            //    //newPosition = transform.position + (-transform.forward) * speedBack * Time.deltaTime;
            //    //gameObject.transform.position = newPosition;
            //}
            if (inputData.Updata().Move.x > 0)
            {
                var f = transform.right * speedForward;
                f.z = 0;
                rigidbodyPlayer.velocity = f;
                //newPosition = transform.position + (transform.forward) * speedForward * Time.deltaTime;
                //gameObject.transform.position = newPosition;
            }
            if (inputData.Updata().Move.x < 0)
            {
                var f = -transform.right * speedForward;
                f.z = 0;
                rigidbodyPlayer.velocity = f;
                //newPosition = transform.position + (-transform.forward) * speedBack * Time.deltaTime;
                //gameObject.transform.position = newPosition;
            }

            if (inputData.Updata().Jamp > 0 && ScanGND())
            {
                
                var f = transform.up * speedForward;
                f.z = 0;
                rigidbodyPlayer.velocity = f;
            }
            //if (inputData.Updata().Move.x > 0)
            //{
            //    deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
            //    rigidbodyPlayer.MoveRotation(rigidbodyPlayer.rotation * deltaRotation);
            //    //transform.Rotate(transform.up * Time.deltaTime * speedTurn);//поворот мышью
            //}
            //if (inputData.Updata().Move.x < 0)
            //{
            //    deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.fixedDeltaTime);
            //    rigidbodyPlayer.MoveRotation(rigidbodyPlayer.rotation * deltaRotation);
            //    //transform.Rotate(-transform.up * Time.deltaTime * speedTurn);//поворот мышью
            //}
        }
    }
    private bool ScanGND()
    {
        yy=pointStart.position*1.1f;
        //yy.y += 1;
        if (Physics.Linecast(pointStart.position, yy, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "Cube") { return true; }
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pointStart.position, yy);
    }
    private void FixedUpdate()
    {
        //if (IsDead) { return; }

        //if (moveSettings.IsUpDate)
        //{
        //    GetSetting();
        //}
        Move();
    }
}
