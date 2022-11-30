namespace Kogane
{
    public sealed class StartEndLogger
    {
        private readonly IDebugLogger m_logger;
        private readonly object       m_message;

        private StartEndLogger( IDebugLogger logger, object message )
        {
            m_logger  = logger;
            m_message = message;

            m_logger.Log( $"{m_message}開始" );
        }

        internal void EndImpl()
        {
            m_logger.Log( $"{m_message}終了" );
        }

        internal void EndImpl( object message )
        {
            m_logger.Log( $"{m_message}終了\n{message}" );
        }

        public static StartEndLogger Start( IDebugLogger logger )
        {
#if KOGANE_DISABLE_DEBUG_LOGGER
            return null;
#else
            return Start( logger, string.Empty );
#endif
        }

        public static StartEndLogger Start( IDebugLogger logger, object message )
        {
#if KOGANE_DISABLE_DEBUG_LOGGER
            return null;
#else
            return new StartEndLogger( logger, message );
#endif
        }
    }
}