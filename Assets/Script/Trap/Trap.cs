using Healt;
using Traps;
using UnityEngine;
using Zenject;

public class Trap : MonoBehaviour
{
    [SerializeField] private TrapSettings settings;
    private int damage;
    private int tempHash;
    private bool isStopRun = false;

    private IHealt healtExecutor;
    [Inject]
    public void Init(IHealt _healtExecutor)
    {
        healtExecutor = _healtExecutor;
    }

    void Start()
    {
        SetSettings();
    }
    private void SetSettings()
    {
        damage = settings.Damage;
    }
    void Update()
    {
        if (isStopRun) { return; }
        DamageObject();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempHash = collision.gameObject.GetHashCode();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        tempHash = collision.gameObject.GetHashCode();
    }
    private void DamageObject()
    {
        if (tempHash != 0)
        {
            healtExecutor.SetDamage(tempHash, damage);
        }
    }

}
