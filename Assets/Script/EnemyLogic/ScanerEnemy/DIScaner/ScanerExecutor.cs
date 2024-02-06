using RegistratorObject;

namespace EnemyLogic
{
    public interface IScanerRezult
    {
        int Hash { get; set; }
    }
    public struct ScanerRezult : IScanerRezult
    {
        public int Hash { get; set; }
        public Construction[] Rezult { get; set; }
    }
    public class ScanerExecutor : IScanerExecutor
    {
        private ScanerRezult[] scanRezultHash;
        private MasivScaner<ScanerRezult> massiv = new MasivScaner<ScanerRezult>();
        private ScanerRezult tempData;
        private bool isLoss = false;
        public void SetRezultScaner(Construction[] _rezult, int thisHash)
        {
            if (scanRezultHash == null)
            {
                tempData = new ScanerRezult { Hash = thisHash, Rezult = _rezult };
                scanRezultHash = new ScanerRezult[] { tempData };
            }
            else
            {
                for (int i = 0; i < scanRezultHash.Length; i++)
                {
                    if (scanRezultHash[i].Hash == thisHash)
                    {
                        scanRezultHash[i].Rezult = _rezult;
                        return;
                    }
                }
                tempData = new ScanerRezult { Hash = thisHash, Rezult = _rezult };
                scanRezultHash = massiv.Creat(tempData, scanRezultHash);
            }
        }
        public Construction[] GetRezultScaner(int thisHash)
        {
            if (scanRezultHash == null) { return null; }
            for (int i = 0; i < scanRezultHash.Length; i++)
            {
                if (scanRezultHash[i].Hash == thisHash)
                {
                    return scanRezultHash[i].Rezult;
                }
            }
            return null;
        }

        public void LossTarget()
        {
            isLoss = true;
        }

        public bool ControlLoss()
        {
            if (isLoss) { isLoss = !isLoss; return true; }
            return isLoss;
        }
    }
}

