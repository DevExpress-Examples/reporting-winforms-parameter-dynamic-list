using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;
// ...

namespace MultiValueParametersExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a report instance.
            XtraReport1 report = new XtraReport1();

            // Create a parameter and specify its name.
            Parameter param1 = new Parameter();
            param1.Name = "CatID";

            // Specify other parameter properties.
            param1.Type = typeof(System.Int32);
            param1.MultiValue = true;
            param1.Description = "Categories: ";

            DynamicListLookUpSettings lookupSettings = new DynamicListLookUpSettings();
            lookupSettings.DataSource = report.DataSource;
            lookupSettings.DataMember = "Categories";
            lookupSettings.DisplayMember = "CategoryName";
            lookupSettings.ValueMember = "CategoryId";

            param1.LookUpSettings = lookupSettings;
            param1.Visible = true;

            //Pass multiple values to the multi-value parameter
            //Note that a multi-value report parameter expects to receive an array of values of a parameter's type
            param1.Value = new int[] { 1, 2, 4 };

            //Or, enable this option to preselect all values
            //param1.SelectAllValues = true; 

            // Add the parameter to the report.
            report.Parameters.Add(param1);

            //Allow the report to create a document without prompting a user to click Submit
            report.RequestParameters = false;

            // Specify the report's filter string.
            report.FilterString = "[CategoryID] In (?CatID)";

            // Assign the report to a ReportPrintTool,
            ReportPrintTool pt = new ReportPrintTool(report);
            pt.ShowPreviewDialog();
        }
    }
}
