using Healt;
using UnityEngine;
using Zenject;

public class KillZone : MonoBehaviour
{
    private int damage;
    private int tempHash;

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
        damage = 10000;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempHash = collision.gameObject.GetHashCode();
        if (tempHash != 0)
        {
            healtExecutor.SetDamage(tempHash, damage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        tempHash = collision.gameObject.GetHashCode();
        if (tempHash != 0)
        {
            healtExecutor.SetDamage(tempHash, damage);
        }
    }
}
