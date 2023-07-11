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
        Android,
        WebGL,
    }

    public enum Architecture
    {
        None,
        Windows_x86,
        Linux_x64,
        Android,
        WebGL,
    }

    public enum Distribution
    {
        None,
    }

    public static readonly DateTime buildDate = new DateTime(638246641590003737);
    public const string version = "beta-4.5";
    public const ReleaseType releaseType = ReleaseType.light_game;
    public const Platform platform = Platform.Linux;
    public const Architecture architecture = Architecture.Linux_x64;
    public const Distribution distribution = Distribution.None;
}

