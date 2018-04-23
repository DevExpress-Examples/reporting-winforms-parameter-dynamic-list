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

            // Add the parameter to the report.
            report.Parameters.Add(param1);

            // Specify the report's filter string.
            report.FilterString = "[CategoryID] In (?CatID)";

            // Assign the report to a ReportPrintTool,
            ReportPrintTool pt = new ReportPrintTool(report);
            pt.ShowPreviewDialog();
        }
    }
}
