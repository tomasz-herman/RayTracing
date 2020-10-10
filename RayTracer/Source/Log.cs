// MIT License
// Copyright (c) 2020 litetex
// See also https://github.com/litetex/CoreFramework/blob/develop/CoreFramework.Logging/Log.cs

using System;
using System.IO;
using System.Runtime.CompilerServices;
using Serilog;

namespace RayTracer
{
   public static class Log
   {
      private static string FormatForException(this string message, Exception ex)
      {
         return $"{message}: {(ex != null ? "\n" + ex.Message + "\n" + ex.StackTrace : "")}";
      }

      private static string FormatForContext(
         this string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         var fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
         var methodName = memberName;

         return $"{fileName} [{methodName}:{sourceLineNumber}] {message}";
      }

      public static void Verbose(
         string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         Serilog.Log.Verbose(
            message
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Verbose(
         string message, 
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         Serilog.Log.Verbose(
            message
               .FormatForException(ex)
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Verbose(
         Exception ex,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Verbose(
            (ex != null ? ex.ToString() : "")
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Debug(
         string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         Serilog.Log.Debug(
            message
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Debug(
         string message, 
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         Serilog.Log.Debug(
            message
               .FormatForException(ex)
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Debug(
         Exception ex,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Debug(
            (ex != null ? ex.ToString() : "")
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Info(
         string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         Serilog.Log.Information(
            message
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Info(
         string message, 
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Information(
            message
               .FormatForException(ex)
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Info(
         Exception ex,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Information(
            (ex != null ? ex.ToString() : "")
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Warn(string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Warning(
            message
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Warn(
         string message, 
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Warning(
            message
               .FormatForException(ex)
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Warn(
         Exception ex,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Warning(
            (ex != null ? ex.ToString() : "")
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Error(
         string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Error(
            message
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
           );
      }

      public static void Error(
         string message, 
         Exception ex,
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Error(
            message
               .FormatForException(ex)
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Error(
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {

         Serilog.Log.Error(
            (ex != null ? ex.ToString() : "")
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Fatal(
         string message, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         FatalAction();

         Serilog.Log.Error(
            message
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Fatal(
         string message, 
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         FatalAction();

         Serilog.Log.Error(
            message
               .FormatForException(ex)
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      public static void Fatal(
         Exception ex, 
         [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "",
         [CallerLineNumber] int sourceLineNumber = 0)
      {
         FatalAction();

         Serilog.Log.Error(
            (ex != null ? ex.ToString() : "")
               .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
            );
      }

      private static void FatalAction()
      {
         Environment.ExitCode = -1;
      }
      
      public static void Configure()
      {
         var outputTemplate = "{Timestamp:HH:mm:ss,fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
         Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Async(a => a.Console())
            .WriteTo.Async(a => a.File(Path.Combine("logs","ray_tracer.log"), outputTemplate: outputTemplate, rollingInterval: RollingInterval.Day))
            .CreateLogger();
      }
   }
}
