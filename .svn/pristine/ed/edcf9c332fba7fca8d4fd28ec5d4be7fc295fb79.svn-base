using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FSHH.HQ.XYJ.Web.xyj.Vendor.CertifcateCategory
{
    public class ResultView
    {
        private string isOK;
        private string message;
        private object entity;
        private DataTable list;
   
        private Dictionary<string, object> data;

        public ResultView()
        {
            this.isOK = "Y";
            this.message = null;
            this.entity = null;
            this.list = null;
            this.data = new Dictionary<string, object>();
        }

        public string IsOK
        {
            set
            {
                this.isOK = value;
            }
            get
            {
                return this.isOK;
            }
        }
        public string Message
        {
            set
            {
                this.message = value;
            }
            get
            {
                return this.message;
            }
        }
        public object Entity
        {
            set
            {
                this.entity = value;
            }
            get
            {
                return this.entity;
            }
        }

        public DataTable List
        {
            set
            {
                this.list = value;
            }
            get
            {
                return this.list;
            }
        }


        public Dictionary<string, object> Data
        {
            set
            {
                this.data = value;
            }
            get
            {
                return this.data;
            }
        }

        public void putData(string key, object value)
        {
            this.data.Add(key, value);
        }
    }
}