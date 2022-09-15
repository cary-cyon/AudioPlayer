using Microsoft.VisualStudio.TestTools.UnitTesting;
using AudioPlayer2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AudioPlayer2.ViewModel.Tests
{
    [TestClass()]
    public class ApplicationViewModelTests
    {
        private ApplicationViewModel viewModel = new ApplicationViewModel();

        [TestInitialize]
        public void SetDuration()
        {
            viewModel.Duration = new Duration(TimeSpan.FromSeconds(10));
        }

        [TestMethod()]
        public void SetDurationTest_10Sec_Expected10Sec()
        {
            var duration = new Duration(TimeSpan.FromSeconds(10));
            var expectedDuration = new Duration(TimeSpan.FromSeconds(10));

            viewModel.SetDuration(duration);

            Assert.AreEqual(expectedDuration, viewModel.Duration);
        }

        [TestMethod]
        public void SetPlayerPosition_0_Expected0()
        {
            double playerPosition = 0;

            viewModel.SetPlayerPosition.Execute(playerPosition);

            Assert.AreEqual(playerPosition, viewModel.Position);
        }
        [TestMethod]
        public void SetViewModelPosition_1_Expected1()
        {
            double playerPosition = 1.0;

            viewModel.SetViewModelPositionOrZeroIfObjNull.Execute(playerPosition);

            Assert.AreEqual(playerPosition, viewModel.Position);
        }

        [TestMethod]
        public void SetViewModelPosition_1000_Expected1000()
        {
            double playerPosition = 1000.0;

            viewModel.SetViewModelPositionOrZeroIfObjNull.Execute(playerPosition);

            Assert.AreEqual(playerPosition, viewModel.Position);
        }
        [TestMethod]
        public void SetViewModelPosition_null_Expected0()
        {
            viewModel.SetViewModelPositionOrZeroIfObjNull.Execute(null);

            Assert.AreEqual(0, viewModel.Position);
        }
    }
}