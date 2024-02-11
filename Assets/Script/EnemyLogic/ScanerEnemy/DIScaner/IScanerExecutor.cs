using RegistratorObject;

namespace EnemyLogic
{
    public interface IScanerExecutor
    {
        Construction[] GetRezultScaner(int thisHash);
        void SetRezultScaner(Construction[] _rezult, int thisHash);
    }
}
