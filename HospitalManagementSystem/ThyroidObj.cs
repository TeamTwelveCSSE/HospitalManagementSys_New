using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem
{
    public class ThyroidObj
    {
        private int reportId;

        public int ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }

        private int patientId;

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private string patientName;

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        private float tsh;

        public float TSH
        {
            get { return tsh; }
            set { tsh = value; }
        }

        private float t4Total;

        public float T4Total
        {
            get { return t4Total; }
            set { t4Total = value; }
        }

        private float freeT4;

        public float FreeT4
        {
            get { return freeT4; }
            set { freeT4 = value; }
        }

        private float freeT3;

        public float FreeT3
        {
            get { return freeT3; }
            set { freeT3 = value; }
        }
    }
}