using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using Clinica.Site.Negocio.Estrutura;

namespace Clinica.Site.Comum
{
    public class Log : LayoutSkeleton
    {
        static readonly string ProcessSessionId = Guid.NewGuid().ToString();
        static readonly int ProcessId = Process.GetCurrentProcess().Id;
        static readonly string MachineName = Environment.MachineName;
        static readonly string MacAddress = (
                      from nic in NetworkInterface.GetAllNetworkInterfaces()
                      where nic.OperationalStatus == OperationalStatus.Up
                      select nic.GetPhysicalAddress().ToString()
                  ).FirstOrDefault();
        //static readonly Usuario User =;

        public override void ActivateOptions()
        {
            throw new NotImplementedException();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var dic = new Dictionary<string, object>
            {
                ["processSessionId"] = ProcessSessionId,
                ["level"] = loggingEvent.Level.DisplayName,
                ["messageObject"] = loggingEvent.MessageObject,
                ["renderedMessage"] = loggingEvent.RenderedMessage,
                ["timestampUtc"] = loggingEvent.TimeStamp.ToUniversalTime().ToString("O"),
                ["logger"] = loggingEvent.LoggerName,
                ["thread"] = loggingEvent.ThreadName,
                ["exceptionObject"] = loggingEvent.ExceptionObject,
                ["exceptionObjectString"] = loggingEvent.ExceptionObject == null ? null : loggingEvent.GetExceptionString(),
                ["userName"] = loggingEvent.UserName,
                ["domain"] = loggingEvent.Domain,
                ["identity"] = loggingEvent.Identity,
                ["location"] = loggingEvent.LocationInformation.FullInfo,
                ["pid"] = ProcessId,
                ["machineName"] = MachineName,
                ["workingSet"] = Environment.WorkingSet,
                ["osVersion"] = Environment.OSVersion.ToString(),
                ["is64bitOS"] = Environment.Is64BitOperatingSystem,
                ["is64bitProcess"] = Environment.Is64BitProcess,
                ["properties"] = loggingEvent.GetProperties(),
                ["macAddress"] = MacAddress
            };
        }
    }
}
