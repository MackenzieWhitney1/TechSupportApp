using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TechSupportApp.Models;

namespace TechSupportApp
{
    public partial class frmTechSupportMain : Form
    {
        public frmTechSupportMain()
        {
            InitializeComponent();
        }

        // define selectedProduct to be used when modifying or deleting a product shown in data grid view.

        Product selectedProduct = null!;
        private void frmTechSupportMain_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        // method for displaying products in data grid view
        private void DisplayProducts()
        {
            dgvProducts.Columns.Clear();
            try
            {
                dgvProducts.DataSource = ProductDB.GetProducts();

            // add column for modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvProducts.Columns.Add(modifyColumn);

            // add column for delete button
            DataGridViewButtonColumn deleteColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvProducts.Columns.Add(deleteColumn);


            // format the grid
            dgvProducts.Columns[0].HeaderText = "Product Code";
            dgvProducts.Columns[0].Width = 200;
            dgvProducts.Columns[3].HeaderText = "Release Date";
            dgvProducts.Columns[3].Width = 200;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("SegoeUI", 12, FontStyle.Bold);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            // auto resize the columns
            dgvProducts.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred when retrieving products. {ex.Message}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // button to show Add Product dialog
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct frmAddProduct = new frmAddModifyProduct();
            DialogResult = frmAddProduct.ShowDialog();
            if (DialogResult == DialogResult.OK) {
                try
                {
                    Product product = frmAddProduct.Product;
                    ProductDB.AddProduct(product);  
                }
                catch (DbUpdateException ex) // thrown when save changes fails - can be multiple errors.
                {
                    string msg = "";
                    var sqlException =
                        (SqlException)ex.InnerException!;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        msg += $"ERROR CODE {error.Number}: {error.Message}\n";
                        MessageBox.Show(msg, "Database Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding product: {ex.Message}",
                        ex.GetType().ToString());
                }
                DisplayProducts();
            }
        }

        // method to add functionality to modify and delete buttons populated in data grid view
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // index values for Modify and Delete button columns
            const int ModifyIndex = 4;
            const int DeleteIndex = 5;

            if (e.RowIndex > -1)  // make sure header row wasn't clicked
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    DataGridViewCell cell = dgvProducts.Rows[e.RowIndex].Cells[0];
                    string productCode = cell.Value?.ToString()?.Trim() ?? "";
                    selectedProduct = ProductDB.FindProduct(productCode)!;
                }

                if (selectedProduct != null)
                {
                    if (e.ColumnIndex == ModifyIndex)
                    {
                        ModifyProduct();
                    }
                    else if (e.ColumnIndex == DeleteIndex)
                    {
                        DeleteProduct();
                    }
                }
            }
        }

        // method to show Modify Product dialog
        private void ModifyProduct()
        {
            frmAddModifyProduct modifyForm = new frmAddModifyProduct
            {
                Product = selectedProduct
            };
            DialogResult result = modifyForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = modifyForm.Product;
                    ProductDB.UpdateProduct(selectedProduct);
                }
                catch (DbUpdateException ex) // thrown when save changes fails - can be multiple errors.
                {
                    string msg = "";
                    var sqlException =
                        (SqlException)ex.InnerException!;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        msg += $"ERROR CODE {error.Number}: {error.Message}\n";
                        MessageBox.Show(msg, "Database Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while modifying product: {ex.Message}",
                        ex.GetType().ToString());
                }
                DisplayProducts();  
            }
        }

        // method to show message box and give the user the option to delete selected product
        private void DeleteProduct()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedProduct.ProductCode.Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    ProductDB.RemoveProduct(selectedProduct);
                }
                catch (DbUpdateException ex) // thrown when save changes fails - can be multiple errors.
                {
                    string msg = "";
                    var sqlException =
                        (SqlException)ex.InnerException!;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        msg += $"ERROR CODE {error.Number}: {error.Message}\n";
                        MessageBox.Show(msg, "Database Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting product: {ex.Message}",
                        ex.GetType().ToString());
                }
            }
            DisplayProducts();
        }
    }
}
