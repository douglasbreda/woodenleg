using System.IO;

namespace WoodenLeg.CrossCutting.Logger
{
    internal class FileLogger : LogBase
    {
        #region [Attributes]

        private readonly string _path = string.Empty;

        #endregion

        #region [Constructor]

        public FileLogger()
        {
            _path = $"{System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetEntryAssembly().Location )}//WLOG.txt";
        }

        public override string Path
        {
            get { return _path; }
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Records the information into a file
        /// </summary>
        /// <param name="message"></param>
        public override void Log( string message )
        {
            lock ( lockObj )
            {
                using ( StreamWriter streamWriter = new StreamWriter( _path ) )
                {
                    streamWriter.WriteLine( message );
                    streamWriter.Close();
                }
            }
        }

        #endregion
    }
}
