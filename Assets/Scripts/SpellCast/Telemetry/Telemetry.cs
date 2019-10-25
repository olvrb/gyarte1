using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Elements;
using UnityEngine;

public class Telemetry : MonoBehaviour {
    private List<BaseElement> els;

    // Start is called before the first frame update
    private void Start() {
        els = new List<BaseElement>();
    }

    // Update is called once per frame
    private void Update() {
    }

    public void SubmitTelemetry(BaseElement el) {
        els.Add(el);
    }

    private void OnApplicationQuit() {
        if (els.Count <= 0) {
            return;
        }

        // Format a string to be written in the TelemetryData folder.
        string s = els.Select(x => x.Name).Aggregate((x, y) => $"{x}, {y}");
        StreamWriter writer = new StreamWriter(File.Open(
            $@"{Application.dataPath}\\..\\TelemetryData\\{DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss")}.txt",
            FileMode.OpenOrCreate));
        writer.Write(s);
        writer.Close();
    }
}