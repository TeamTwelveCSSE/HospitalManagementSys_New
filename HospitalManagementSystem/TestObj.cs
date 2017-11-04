using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem
{
    public class TestObj
    {
        private int testId;

        public int TestId
        {
            get { return testId; }
            set { testId = value; }
        }

        private string testCategory;

        public string TestCategory
        {
            get { return testCategory; }
            set { testCategory = value; }
        }

        private string testName;

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }

        private string testDesc;

        public string TestDesc
        {
            get { return testDesc; }
            set { testDesc = value; }
        }

        private string testStatus;

        public string TestStatus
        {
            get { return testStatus; }
            set { testStatus = value; }
        }

        private string testUnit;

        public string TestUnit
        {
            get { return testUnit; }
            set { testUnit = value; }
        }

        private float testAmount;

        public float TestAmount
        {
            get { return testAmount; }
            set { testAmount = value; }
        }
    }
}