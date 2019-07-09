namespace WoodenLeg.CrossCutting.Helpers
{
    public static class StringUtils
    {
        #region [Methods]

        /// <summary>
        /// Check if the string is empty or null as extension method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmptyOrNull( this string value )
        {
            return value == null || string.IsNullOrEmpty( value );
        }

        /// <summary>
        /// Check if a string has value as extension method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this string value )
        {
            return value != null && !string.IsNullOrEmpty( value );
        }

        #endregion
    }
}
