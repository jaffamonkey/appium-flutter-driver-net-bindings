﻿using Appium.Flutter.Bounds;
using Appium.Flutter.Finder;
using OpenQA.Selenium.Internal;
using System.Collections.Generic;

namespace Appium.Flutter.Contracts
{
    public interface IFlutterDriver : IWrapsDriver
    {
        string CheckHealth();
        void ClearTimeline();
        object ExecuteScript(string script, params object[] args);
        void ForceGC();
        string GetRenderTree();
        string GetElementText(FlutterBy by);
        void Click(FlutterBy by);
        long GetSemanticsId(FlutterBy by);
        Position GetBottomLeft(FlutterBy by);
        Position GetBottomRight(FlutterBy by);
        Position GetTopLeft(FlutterBy by);
        Position GetTopRight(FlutterBy by);
        Position GetCenter(FlutterBy by);
        byte[] Screenshot();
        void Screenshot(string path);
        void WaitFor(FlutterBy by);
        void WaitFor(FlutterBy by, int timeoutInSeconds);
        void WaitForAbsent(FlutterBy by);
        void WaitForAbsent(FlutterBy by, int timeoutInSeconds);
        Dictionary<string, object> GetRenderObjectDiagnostics(FlutterBy by, bool includeProperties = true, int subtreeDepth = 2);
    }
}
