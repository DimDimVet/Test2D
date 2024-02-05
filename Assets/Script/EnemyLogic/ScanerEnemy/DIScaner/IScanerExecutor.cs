using RegistratorObject;

namespace EnemyLogic
{
    public interface IScanerExecutor
    {
        Construction[] GetRezultScaner();
        void SetRezultScaner(Construction[] _rezult);
        void LossTarget();
        bool ControlLoss();
    }
}
