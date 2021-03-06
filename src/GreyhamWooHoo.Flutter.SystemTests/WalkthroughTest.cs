﻿using FluentAssertions;
using FluentAssertions.Execution;
using GreyhamWooHoo.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class WalkthroughTest : TestBase
    {
        protected static FlutterBy Control = FlutterBy.Type("FlatButton");

        [TestInitialize]
        public void NavigateToFindersPage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }

        [TestMethod]
        public void GetRenderObjectDiagnostics_Javascript()
        {
            var by = FlutterBy.ValueKey("counter");

            var response = FlutterDriver.ExecuteScript("flutter:getRenderObjectDiagnostics", by.ToBase64(), new Dictionary<string, object>()
            {
                { "includeProperties", true },
                { "subtreeDepth", 2 }
            });

            var responseAsDictionary = response as Dictionary<string, object>;

            AssertGetRenderObjectDiagnosticsResponse(responseAsDictionary);
        }

        [TestMethod]
        public void GetRenderObjectDiagnostics_Driver()
        {
            var response = FlutterDriver.GetRenderObjectDiagnostics(FlutterBy.ValueKey("counter"), includeProperties: true, subtreeDepth: 2);

            AssertGetRenderObjectDiagnosticsResponse(response);
        }

        private void AssertGetRenderObjectDiagnosticsResponse(Dictionary<string, object> response)
        {
            using (var scope = new AssertionScope("GetRenderDiagnosticsResponse"))
            {
                response.ContainsKey("description").Should().BeTrue();
                response.ContainsKey("type").Should().BeTrue();
                response.ContainsKey("children").Should().BeTrue();
                response.ContainsKey("allowWrap").Should().BeTrue();
                response.ContainsKey("properties").Should().BeTrue();
                response.ContainsKey("children").Should().BeTrue();

                response["type"].Should().Be("DiagnosticableTreeNode");
            }
        }
    }
}
