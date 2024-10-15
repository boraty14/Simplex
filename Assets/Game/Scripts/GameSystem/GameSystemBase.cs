namespace Game.Scripts.GameSystem
{
    public abstract class GameSystemBase
    {
        protected abstract bool IsRunnable();
        protected abstract void RunInternally();

        protected GameSystemBase(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        public bool IsEnabled;

        public void Run()
        {
            if (!IsRunnable() || !IsEnabled)
            {
                return;
            }
            
            RunInternally();
        }

    }
}