using WoodenLeg.CrossCutting.Logger;
using static WoodenLeg.CrossCutting.Enums.GeneralEnum;

namespace WoodenLeg.CrossCutting.Helpers
{
    public static class Logger
    {
        #region [Attributes]

        private static LogBase _logbase = new FileLogger();
        private static string _message = string.Empty;

        #endregion

        #region Methods
        

        private static void SetMessage( LogType logtype, string message )
        {
            switch ( logtype )
            {
                case LogType.info:
                    _message = $"[INFO]\t\t{message}";
                    break;
                case LogType.error:
                    _message = $"[ERROR]\t\t{message}";
                    break;
                case LogType.warning:
                    _message = $"[WARNING]\t\t{message}";
                    break;
            }

            _logbase.Log( _message );
        }

        /// <summary>
        /// Defines the warning default message
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning( string message )
        {
            SetMessage( LogType.warning, message );
        }

        /// <summary>
        /// Defines the error default message
        /// </summary>
        /// <param name="message"></param>
        public static void LogError( string message )
        {
            SetMessage( LogType.error, message );
        }

        /// <summary>
        /// Defines the info default message
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo( string message )
        {
            SetMessage( LogType.info, message );
        }

        /// <summary>
        /// Returns the path where is located the log file
        /// </summary>
        /// <returns></returns>
        public static string GetLogPath()
        {
            return _logbase.Path;
        }

        #endregion
    }
}
