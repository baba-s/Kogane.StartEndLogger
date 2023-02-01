using UnityEngine;

namespace Kogane
{
    public sealed class StartEndLogger
    {
        private readonly IDebugLogger m_logger;
        private readonly object       m_message;
        private readonly float        m_startTime;

        private StartEndLogger( IDebugLogger logger, object message )
        {
            m_logger  = logger;
            m_message = message;

            m_logger.Log( $"{m_message}開始" );

            m_startTime = Time.realtimeSinceStartup;
        }

        internal void EndImpl()
        {
            var elapsedTime = Time.realtimeSinceStartup - m_startTime;
            m_logger.Log( $"{m_message}終了  {elapsedTime:0.00} 秒" );
        }

        internal void EndImpl( object message )
        {
            var elapsedTime = Time.realtimeSinceStartup - m_startTime;
            m_logger.Log( $"{m_message}終了  {elapsedTime:0.00} 秒\n{message}" );
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