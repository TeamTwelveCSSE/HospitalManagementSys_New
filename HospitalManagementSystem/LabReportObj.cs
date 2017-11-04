using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem
{
    public class LabReportObj
    {
        private int labTestId;

        public int LabTestId
        {
            get { return labTestId; }
            set { labTestId = value; }
        }

        private int patientNumber;

        public int PatientNumber
        {
            get { return patientNumber; }
            set { patientNumber = value; }
        }

        private string patientName;

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int testNumber;

        public int TestNumber
        {
            get { return testNumber; }
            set { testNumber = value; }
        }

        private string testName;

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private float amount;

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}