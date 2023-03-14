﻿namespace DotNetTask.Application
{
    public static class ServerPath
    {
        public static string MapPath(string path)
        {
            return Path.Combine(
                (string)AppDomain.CurrentDomain.GetData("ContentRootPath") ?? string.Empty,
                path);
        }
        public static string RootPath()
        {
            return (string)AppDomain.CurrentDomain.GetData("ContentRootPath") ?? string.Empty;
        }
    }
}
