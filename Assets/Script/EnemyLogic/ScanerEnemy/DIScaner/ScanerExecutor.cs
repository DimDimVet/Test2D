using RegistratorObject;

namespace EnemyLogic
{
    public class ScanerExecutor : IScanerExecutor
    {
        private Construction[] rezult;
        private bool isLoss=false;
        public void SetRezultScaner(Construction[] _rezult)
        {
            rezult = _rezult;
        }
        public Construction[] GetRezultScaner()
        {
            return rezult;
        }

        public void LossTarget()
        {
            isLoss=true;
        }

        public bool ControlLoss()
        {
            if (isLoss) { isLoss = !isLoss; return true; }
            return isLoss;
        }
    }
}

