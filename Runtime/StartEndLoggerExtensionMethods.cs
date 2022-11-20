namespace Kogane
{
    public static class StartEndLoggerExtensionMethods
    {
        private const string CONDITIONAL_STRING = "aCQHuF32pvyB";

#if KOGANE_DISABLE_DEBUG_LOGGER
        [System.Diagnostics.Conditional( CONDITIONAL_STRING )]
#endif
        public static void End( this StartEndLogger self )
        {
            self?.EndImpl();
        }

#if KOGANE_DISABLE_DEBUG_LOGGER
        [System.Diagnostics.Conditional( CONDITIONAL_STRING )]
#endif
        public static void End( this StartEndLogger self, string message )
        {
            self?.EndImpl( message );
        }
    }
}