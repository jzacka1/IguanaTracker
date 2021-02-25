using IguanaTracker.API.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IguanaTracker.API.Services
{
	/// <summary>
	/// 
	/// </summary>
	public class LoggerService : ILoggerService
	{
		private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

		public void LogDebug(string message) => Logger.Debug(message);

		public void LogError(string message) => Logger.Error(message);

		public void LogInfo(string message) => Logger.Info(message);

		public void LogWarn(string message) => Logger.Warn(message);
	}
}
