using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using System;
// Output the build size or a failure depending on BuildPlayer.

public class ScriptBatch : MonoBehaviour
{
    public static void MyBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/_Completed-Game/Roll-a-ball.unity" };
        buildPlayerOptions.locationPathName = "webGLBuild";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        Console.WriteLine("Building started...");
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            Console.WriteLine("Build succeeded");
            
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}