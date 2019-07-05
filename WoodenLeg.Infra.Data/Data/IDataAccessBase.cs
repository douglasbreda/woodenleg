namespace WoodenLeg.Infra.Data.Data
{
    /// <summary>
    /// Generic interface to allow easy changes of database technology
    /// </summary>
    public interface IDataAccessBase
    {
        #region [Definitions]

        ///<summary>
        /// Starts a new connection with the server
        ///</summary>
        bool StartConnection();

        ///<summary>
        /// To control if is connected or not
        ///</summary>
        bool IsConnected { get; set; }

        #endregion
    }
}
