namespace Bulls
{
    public class ExecutorEnemyBull : IEnemyBull
    {
        private float tempDirection = 1;

        public float DirectionPlayer()
        {
            return tempDirection;
        }
        public void SetDirectionEnemy(float directionX)
        {
            tempDirection = directionX;
        }

    }
}
