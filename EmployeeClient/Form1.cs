using System;
using System.Windows.Forms;

namespace EmployeeClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        #region UI Event Handlers
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            EmpClient rClient = new EmpClient();
            rClient.endPoint = txtRestUri.Text;

            txtResponse.Clear();

            debugOutput(rClient.makeRequest());
        }
        #endregion

        #region Debug Function
        // Writes strings to a textbox and output window.
        // Provides a quick, convenient way to understand what's happening in the code. 
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        #endregion
    }
}
