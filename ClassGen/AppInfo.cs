using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.System;

namespace ClassGen
{
  public static  class AppInfo
    {
        // To get application's name:
        public static  string ApplicationName => SystemInformation.ApplicationName;

        // To get application's version:
        public static  string ApplicationVersion => $"{SystemInformation.ApplicationVersion.Major}.{SystemInformation.ApplicationVersion.Minor}.{SystemInformation.ApplicationVersion.Build}.{SystemInformation.ApplicationVersion.Revision}";

        // To get the most preferred language by the user:
        public static  CultureInfo Culture => SystemInformation.Culture;

        // To get operating syste,
        public static  string OperatingSystem => SystemInformation.OperatingSystem;

        // To get used processor architecture
        public static  ProcessorArchitecture OperatingSystemArchitecture => SystemInformation.OperatingSystemArchitecture;

        // To get operating system version
        public static  OSVersion OperatingSystemVersion => SystemInformation.OperatingSystemVersion;

        // To get device family
        public static  string DeviceFamily => SystemInformation.DeviceFamily;

        // To get device model
        public static  string DeviceModel => SystemInformation.DeviceModel;

        // To get device manufacturer
        public static  string DeviceManufacturer => SystemInformation.DeviceManufacturer;

        // To get available memory in MB
        public static  float AvailableMemory => SystemInformation.AvailableMemory;

        // To get if the app is being used for the first time since it was installed.
        public static  bool IsFirstUse => SystemInformation.IsFirstRun;

        // To get if the app is being used for the first time since being upgraded from an older version.
        public static  bool IsAppUpdated => SystemInformation.IsAppUpdated;

        // To get the first version installed
        public static  PackageVersion FirstVersionInstalled => SystemInformation.FirstVersionInstalled;

        // To get the first time the app was launched
        public static  DateTime FirstUseTime => SystemInformation.FirstUseTime;

        // To get the time the app was launched.
        public static  DateTime LaunchTime => SystemInformation.LaunchTime;

        // To get the time the app was previously launched, not including this instance.
        public static  DateTime LastLaunchTime => SystemInformation.LastLaunchTime;

        // To get the time the launch count was reset, not including this instance
        public static  string LastResetTime => SystemInformation.LastResetTime.ToString(Culture.DateTimeFormat);

        // To get the number of times the app has been launched sicne the last reset.
        public static  long LaunchCount => SystemInformation.LaunchCount;

        // To get the number of times the app has been launched.
        public static long TotalLaunchCount => SystemInformation.TotalLaunchCount;

        // To get how long the app has been running
        public static TimeSpan AppUptime => SystemInformation.AppUptime;

    }
}
