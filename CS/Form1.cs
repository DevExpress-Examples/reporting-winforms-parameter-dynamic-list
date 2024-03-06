using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.Parameters;
using Parameter = DevExpress.XtraReports.Parameters.Parameter;
using System.Windows.Forms;
using System;
using DevExpress.XtraReports.UI;

namespace Reporting_Create_Report_Parameter_with_Predefined_Dynamic_Values {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create and set up an Object data source.
            var objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "Employees";
            objectDataSource.DataSource = typeof(EmployeeDataSource);
            objectDataSource.DataMember = "GetEmployeeList";
            objectDataSource.Constructor = new ObjectConstructorInfo();
            objectDataSource.Fill();

            // Create a report parameter.
            Parameter param = new Parameter();
            param.Name = "employeePosition";
            param.Description = "Employee position:";
            param.Type = typeof(string);

            // Create a DynamicListLookUpSettings instance and
            // set up its properties.
            var lookupSettings = new DynamicListLookUpSettings();
            lookupSettings.DataSource = objectDataSource;
            lookupSettings.ValueMember = "Name";
            lookupSettings.DisplayMember = "Position";

            // Assign data storage settings to the parameter's ValueSourceSettings property.
            param.ValueSourceSettings = lookupSettings;

            // Create a report instance and add the parameter to the report's Parameters collection.
            var report = new XtraReport1();
            report.Parameters.Add(param);

            report.ShowPreview();
        }
    }
}
