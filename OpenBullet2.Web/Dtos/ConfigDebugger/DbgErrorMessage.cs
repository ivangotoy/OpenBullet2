﻿namespace OpenBullet2.Web.Dtos.ConfigDebugger;

/// <summary>
/// A new error was raised.
/// </summary>
public class DbgErrorMessage
{
    /// <summary>
    /// The error type.
    /// </summary>
    public string Type { get; set; } = "Generic Error";

    /// <summary>
    /// The error message.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The full stack trace of the exception.
    /// </summary>
    public string StackTrace { get; set; } = string.Empty;
}
