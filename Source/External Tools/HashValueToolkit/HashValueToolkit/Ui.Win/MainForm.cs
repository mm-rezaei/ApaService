using System.Globalization;
using System.Windows.Forms;
using HashValueToolkit.Bol;

namespace HashValueToolkit.Ui.Win
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            comboBoxHashCount.SelectedIndex = 1;
        }

        #endregion

        #region Private Methods

        private void buttonHash_Click(object sender, System.EventArgs e)
        {
            #region String Result

            textBoxStringResult.Text = HashService.GetHashString(textBoxPassword.Text.Trim(), comboBoxHashCount.SelectedIndex + 1);

            #endregion

            #region Hash Value

            var hashBytes = HashService.GetHashValue(textBoxPassword.Text.Trim(), comboBoxHashCount.SelectedIndex + 1);

            var hashValue = "";

            foreach (var value in hashBytes)
            {
                if (hashValue != "")
                {
                    hashValue += ", ";
                }

                hashValue += value.ToString(CultureInfo.InvariantCulture);
            }

            hashValue = "new byte[] {" + hashValue + "}";

            textBoxArrayResult.Text = hashValue;

            #endregion
        }

        #endregion
    }
}
