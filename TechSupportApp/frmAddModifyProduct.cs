using ElectricityBillGUI;
using TechSupportApp.Models;
namespace TechSupportApp
{

    public partial class frmAddModifyProduct : Form
    {

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        public Product Product { get; set; } = null!;

        // ensure that new modal using this class is in either the Add or Modify Product context
        // It's in the modify context if when creating the modal that selectedProduct is passed in.

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            if (Product == null)
            {
                Text = "Add Product";
                txtProductCode.ReadOnly = false;
                Product = new Product();
            } else
            {
                Text = "Modify Product";
                txtProductCode.ReadOnly = true;
                txtProductCode.Text = Product.ProductCode;
                txtName.Text = Product.Name;
                txtVersion.Text = Product.Version.ToString();
                txtReleaseDate.Text = Product.ReleaseDate.ToShortDateString();
            }
        }

        // method to set Product attributes with an OK result if accept button is clicked and
        // inputs have been validated.
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (validateProduct())
            {
                Product.ProductCode = txtProductCode.Text;
                Product.Name = txtName.Text;
                Product.Version = Decimal.Parse(txtVersion.Text);
                Product.ReleaseDate = DateTime.Parse(txtReleaseDate.Text);
                DialogResult = DialogResult.OK;
            }
        }

        // extracted method to validate product
        private bool validateProduct()
        {
            return Validator.IsPresent(txtProductCode) &&
                            Validator.IsPresent(txtName) &&
                            Validator.IsPresent(txtVersion) &&
                            Validator.IsPresent(txtReleaseDate) &&
                            Validator.IsNonNegativeDecimal(txtVersion) &&
                            Validator.IsValidDateLaterThan1970(txtReleaseDate); 
            // there are issues adding/modifying product if date is too early
            // would otherwise see error message boxes with inputs like 1000-01-01
        }
    }
}
