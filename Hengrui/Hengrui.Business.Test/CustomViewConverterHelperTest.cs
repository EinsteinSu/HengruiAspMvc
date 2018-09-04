using System;
using System.Collections.Generic;
using Hengrui.Business.Common;
using Hengrui.DataAccess.Models.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Hengrui.Business.Test
{
    [TestClass]
    public class CustomViewConverterHelperTest
    {



        [TestMethod]
        public void GetCriteria()
        {
            const string filter = "a or b and c";
            var items = filter.GetCriteria();
            Assert.AreEqual(3, items.Values.Count);
            Assert.AreEqual(CustomViewConverterHelper.Operator.Or, items.Operators[0]);
            Assert.AreEqual(CustomViewConverterHelper.Operator.And, items.Operators[1]);
        }

        [TestMethod]
        public void GetStateCriteria()
        {
            const string filter = "project: a or b and c";
            var item = filter.GetStateCriteria();
            Assert.AreEqual(item.Type, CustomViewConverterHelper.StateType.Project);
            Assert.AreEqual(3, item.Criteria.Values.Count);
            Assert.AreEqual(CustomViewConverterHelper.Operator.Or, item.Criteria.Operators[0]);
            Assert.AreEqual(CustomViewConverterHelper.Operator.And, item.Criteria.Operators[1]);
        }

        [TestMethod]
        public void FilterProjectByState()
        {
            Mock<IProject> projectMock = new Mock<IProject>(MockBehavior.Strict);
            projectMock.SetupGet(s => s.CurrentProjectState).Returns(new ProjectState { Status = ProjectStateType.接件 });
            projectMock.SetupGet(s => s.CurrentProjectState).Returns(new ProjectState { Status = ProjectStateType.收件 });
            projectMock.Name = "Test project";
            const string filter = "project: 接件 or 收件";
            var result = CustomViewConverterHelper.FilterProjectByState(projectMock.Object, filter);
            Assert.IsTrue(result);
        }
    }
}
