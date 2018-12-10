using System;
using Xunit;
using Launchpad.Controllers;
using System.Collections.Generic;
using Launchpad.Models;
using System.Linq;

namespace XUnitTestLaunchPad
{
    public class UnitTest1
    {
        LaunchpadController _controller;

        public UnitTest1()
        {
            _controller = new LaunchpadController();

        }

        [Fact]
        public void GetAllLaunchPads()
        {
            var pads = _controller.Get();
            List<LaunchPadInfo> items = pads.ToList();
            Assert.Equal(6, items.Count);

        }
    }
}
