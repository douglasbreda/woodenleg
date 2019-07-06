using System.IO;
using WoodenLeg.CrossCutting.Helpers;
using Xunit;
using System.Linq;

namespace WoodenLeg.CrossCuttingTest.LogTest
{
    public class LoggerTest
    {
        [Fact]
        public void LoggerTestWarning()
        {
            Logger.LogWarning( "It should be this message" );

            string lastLine = File.ReadAllLines( Logger.GetLogPath() ).ToList().LastOrDefault();

            if ( !string.IsNullOrEmpty( lastLine ) )
            {
                Assert.Equal( "[WARNING]\t\tIt should be this message", lastLine );
            }
            else
                Assert.True( false, "The file is empty" );
            
        }

        [Fact]
        public void LoggerTestInfo()
        {
            Logger.LogInfo( "It should be this message" );

            string lastLine = File.ReadAllLines( Logger.GetLogPath() ).ToList().LastOrDefault();

            if ( !string.IsNullOrEmpty( lastLine ) )
            {
                Assert.Equal( "[INFO]\t\tIt should be this message", lastLine );
            }
            else
                Assert.True( false, "The file is empty" );

        }

        [Fact]
        public void LoggerTestErro()
        {
            Logger.LogError( "It should be this message" );

            string lastLine = File.ReadAllLines( Logger.GetLogPath() ).ToList().LastOrDefault();

            if ( !string.IsNullOrEmpty( lastLine ) )
            {
                Assert.Equal( "[ERROR]\t\tIt should be this message", lastLine );
            }
            else
                Assert.True( false, "The file is empty" );

        }
    }
}
