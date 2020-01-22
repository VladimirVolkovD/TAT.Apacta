using System;
using System.Configuration;

namespace Core.WebDriver
{
	/// <summary>
	/// Represents work with test setting and configuration
	/// </summary>
	public static class Configuration
	{

        public static int ElementTimeout => Convert.ToInt32(GetEnvironmentVariable("ElementTimeout", "60"));

        public static BrowserType Browser => GetBrowserTypeVariable("Browser", "Chrome");
		
		private static string GetEnvironmentVariable(string var, string defaultValue)
		{
			
			return ConfigurationManager.AppSettings[var] ?? defaultValue;
		}

		private static string[] GetEnvironmentVariables(string var, string[] defaultValue)
		{
			return ConfigurationManager.AppSettings[var].Split('|') ?? defaultValue;
		}

		private static BrowserType GetBrowserTypeVariable(string var, string defaultValue)
		{
			var actualBrowser = GetEnvironmentVariable(var, defaultValue);
			Enum.TryParse(actualBrowser, out BrowserType currentBrowser);

			return currentBrowser;
		}
	}
}