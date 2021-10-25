using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class CADViewModel
    {
        public tAdvertising advertising { get; set; }
        public CADViewModel() { this.advertising = new tAdvertising(); }

        [DisplayName("廣告")]

        public int cADSN
        {
            get { return this.advertising.cADSN; }
            set { this.advertising.cADSN = value; }
        }
        [Required(ErrorMessage = "!")] //表示必填
        [DisplayName("123")]

        public string cFirmSN
        {
            get { return this.advertising.cFirmSN; }
            set { this.advertising.cFirmSN = value; }
        }
        [DisplayName("123")] //顯示名稱
        //[StringLength(100, MinimumLength = 0, ErrorMessage = "{0}至少要{2}個字，不超過{1}個字")]
        public string cADName
        {
            get { return this.advertising.cADName; }
            set { this.advertising.cADName = value; }
        }
        public string cADFileName
        {
            get { return this.advertising.cADFileName; }
            set { this.advertising.cADFileName = value; }
        }
        public Nullable<DateTime> cADStartDate
        {
            get { return this.advertising.cADStartDate; }
            set { this.advertising.cADStartDate = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<DateTime> cADDueDate
        {
            get { return this.advertising.cADDueDate; }
            set { this.advertising.cADDueDate = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public string cADActionDate
        {
            get { return this.advertising.cADActionDate; }
            set { this.advertising.cADActionDate = value; }
        }
        public Nullable<DateTime> cADCreateDate
        {
            get { return this.advertising.cADCreateDate; }
            set { this.advertising.cADCreateDate = value; }
        }
        public Nullable<DateTime> cADEditDate
        {
            get { return this.advertising.cADEditDate; }
            set { this.advertising.cADEditDate = value; }
        }
        public Nullable<bool> cADStatus
        {
            get { return this.advertising.cADStatus; }
            set { this.advertising.cADStatus = value; }
        }
        public string cADGroup
        {
            get { return this.advertising.cADGroup; }
            set { this.advertising.cADGroup = value; }
        }
        public string cADURL
        {
            get { return this.advertising.cADURL; }
            set { this.advertising.cADURL = value; }
        }
    }
}