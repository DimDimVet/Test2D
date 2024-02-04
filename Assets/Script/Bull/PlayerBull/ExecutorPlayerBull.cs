namespace Bulls
{
    public class ExecutorPlayerBull : IPlayerBull
    {
        private float tempDirection = 1;

        public float DirectionPlayer()
        {
            return tempDirection;
        }
        public void SetDirectionPlayer(float directionX)
        {
            tempDirection = directionX;
        }

    }
}

