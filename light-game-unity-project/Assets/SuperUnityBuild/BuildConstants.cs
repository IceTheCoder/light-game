using System;

// This file is auto-generated. Do not modify or move this file.

public static class BuildConstants
{
    public enum ReleaseType
    {
        None,
        light_game,
    }

    public enum Platform
    {
        None,
        PC,
        Linux,
        WebGL,
        macOS,
        Android,
    }

    public enum Architecture
    {
        None,
        Windows_x86,
        Linux_x64,
        WebGL,
        macOS,
        Android,
    }

    public enum Distribution
    {
        None,
    }

    public static readonly DateTime buildDate = new DateTime(638253639256886368);
    public const string version = "beta-4.6";
    public const ReleaseType releaseType = ReleaseType.light_game;
    public const Platform platform = Platform.macOS;
    public const Architecture architecture = Architecture.macOS;
    public const Distribution distribution = Distribution.None;
}

