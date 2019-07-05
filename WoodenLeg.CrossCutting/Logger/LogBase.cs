namespace WoodenLeg.CrossCutting.Logger
{
    public abstract class LogBase
    {
        public abstract void Log( string message );
        
        protected readonly object lockObj = new object();

        public abstract string Path { get; }
    }
}
