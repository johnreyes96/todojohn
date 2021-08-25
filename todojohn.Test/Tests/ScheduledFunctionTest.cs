using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using todojohn.Functions.Functions;
using todojohn.Test.Helpers;
using Xunit;

namespace todojohn.Test.Tests
{
    public class ScheduledFunctionTest
    {
        [Fact]
        public void ScheduledFunction_Should_Log_Message()
        {
            // Arrange
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);

            // Act
            _ = ScheduledFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            // Assert
            Assert.Contains("Deleting completed", message);
        }
    }
}
