using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Grpc.Net.Client;

using Cheetah.Platform;
using Cheetah.System.Compatibility;

public class Connector : MonoBehaviour
{
    public static string Url =  "stage1.kube.syncario.com";
    public static int Port = 443;
    public static bool UseSsl = true;

    [MenuItem("Cluster/Connect")]
    static async void Connect()
    {
        Debug.Log($"Connecting to {Url}:{Port}, ssl: {UseSsl}");
        var clusterConnector = new ClusterConnector(Url, Port, UseSsl);
        var compatibilityChecker = new CompatibilityChecker(clusterConnector);
        var status = await compatibilityChecker.Check("0.0.11");
    }
}
