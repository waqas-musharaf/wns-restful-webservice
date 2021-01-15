using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace rest_client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            // Draws and initialises components on form
            InitializeComponent();

            // Sets combobox as dropdown and adds item selection
            cbRequest.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRequest.Items.AddRange(new string[] {"Cat Fact", "Dictionary", "IP Location"});

            // Initialises response textbox with usage instructions
            txtResponse.Text = "Usage Instructions: \r\n\r\nRequests:\r\n\r\nCat Fact: Returns a random cat fact."
                + "\r\n\r\nDictionary: Specify a word within <parameters> to retrieve its definition."
                + "\r\n\r\nIP Location: Return location information based on your current public IP address. "
                + "Specify an IP within <parameters> to return location information for that IP instead.";

            // Configures textboxes and submit button
            txtResponse.ReadOnly = true;
            txtParams.Text = "";
            txtParams.ReadOnly = true;
            btnSubmit.Enabled = false;
        }

        private void cbRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If request textbox is edited, sets parameters textbox as empty
            txtParams.Text = "";
            // If request textbox is empty, sets parameters textbox as uneditable and submit button as unclickable
            if (String.IsNullOrEmpty(cbRequest.GetItemText(cbRequest.SelectedItem)))
            {
                txtParams.ReadOnly = true;
                btnSubmit.Enabled = false;
            }
            // If request textbox equals 'Cat Fact', sets parameters textbox as uneditable and submit button as clickable
            else if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("Cat Fact"))
            {
                txtParams.ReadOnly = true;
                btnSubmit.Enabled = true;
            }
            // If request textbox equals 'Dictionary', sets parameters textbox as editable and submit button as unclickable
            else if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("Dictionary"))
            {
                txtParams.ReadOnly = false;
                btnSubmit.Enabled = false;
            }
            // If request textbox equals 'IP Location', sets parameters textbox as editable and submit button as clickable
            else if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("IP Location"))
            {
                txtParams.ReadOnly = false;
                btnSubmit.Enabled = true;
            }
        }

        private void txtParams_TextChanged(object sender, EventArgs e)
        {
            if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("Dictionary"))
            {
                // If request textbox equals 'Dictionary' and parameters textbox includes at least one alphabetical character,
                // sets submit button as clickable, otherwise, sets submit button as unclickable
                if (String.IsNullOrEmpty(Regex.Replace(txtParams.Text, "[^A-Za-z]", "")))
                {
                    btnSubmit.Enabled = false;
                }
                else
                {
                    btnSubmit.Enabled = true;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Sets baseUrl as an uneditable string variable as defined below
            const string baseUrl = "http://127.0.0.1:5000/";
            // Calls a new instance of the RestClient class
            RestClient restClient = new RestClient();

            // Uses RegEx to remove all non-alphanumerical characters (except periods and hyphens) from the parameters textbox
            txtParams.Text = Regex.Replace(txtParams.Text, "[^A-Za-z0-9.-]", "");

            // Configures rest client endpoint as per user inputs, based on the hard-coded base URL            
            if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("Cat Fact"))
            {
                restClient.EndPoint = baseUrl + "catfact";
            }
            else if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("Dictionary"))
            {
                restClient.EndPoint = baseUrl + "dictionary/" + txtParams.Text;
            }
            else if (cbRequest.GetItemText(cbRequest.SelectedItem).Equals("IP Location"))
            {
                if (String.IsNullOrEmpty(txtParams.Text))
                {
                    restClient.EndPoint = baseUrl + "location";
                }
                else
                {
                    restClient.EndPoint = baseUrl + "location/" + txtParams.Text;
                }
            }
            else
            {
                throw new Exception("Error: Unknown Request.");
            }
            
            // Returns and stores rest client request output
            string responseString = string.Empty;
            responseString = restClient.MakeRequest();

            // Displays rest client request output in the response textbox
            txtResponse.Text = responseString;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // Auto-generated method stub, not required
        }
    }
}
