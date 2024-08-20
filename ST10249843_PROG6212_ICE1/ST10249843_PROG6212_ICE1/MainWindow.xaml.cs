using ST10249843_PROG6212_ICE1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ST10249843_PROG6212_ICE1
{
    public partial class MainWindow : Window
    {
        private List<Product> products = new List<Product>();  // List to store the products in the inventory.
        private InventoryManager inventoryManager = new InventoryManager();   // Instance of InventoryManager to handle inventory operations.

        public MainWindow()
        {
            InitializeComponent();
            dgInventory.ItemsSource = products;
            dgInventory.SelectionMode = System.Windows.Controls.DataGridSelectionMode.Extended;
        }


        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Electronics
            {
                ProductID = 101,
                Name = "Laptop",
                Category = "Electronics",
                Price = 999.99m,
                StockQuantity = 15,
                WarrantyPeriod = 2
            };

            if (products.Any(p => p.ProductID == newProduct.ProductID))  // Check if a product with the same ProductID already exists in the inventory.
            {
                MessageBox.Show("A product with the same ProductID already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                products.Add(newProduct); // Add the new product to the inventory.
                dgInventory.Items.Refresh();
            }
        }


        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = dgInventory.SelectedItems.Cast<Product>().ToList(); // Get the list of selected products
            if (selectedProducts.Any())
            {
                foreach (var product in selectedProducts)  // Update the selected products.
                {
                    product.Name = "Updated " + product.Name;
                    product.StockQuantity += 5;
                }
                dgInventory.Items.Refresh();
            }
            else
            {
                MessageBox.Show("No products selected for update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnProcessSale_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = dgInventory.SelectedItems.Cast<Product>().ToList();
            if (selectedProducts.Any())
            {
                foreach (var product in selectedProducts) // Process the sale for each selected product.
                {
                    try
                    {
                        inventoryManager.ProcessSale(product, 1); //Decreases Quantity of the product
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                dgInventory.Items.Refresh();
            }
            else
            {
                MessageBox.Show("No products selected for sale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            // Create a ReportSummary instance to generate the inventory summary.
            ReportSummary report = new ReportSummary();
            var summary = report.GenerateSummary(products);

            string reportText = "Inventory Report:\n";
            foreach (var item in summary)
            {
                reportText += $"Name: {item.Name}, Category: {item.Category}, Stock: {item.StockQuantity}\n";
            }

            MessageBox.Show(reportText, "Inventory Report", MessageBoxButton.OK, MessageBoxImage.Information);  // Display the summary report in a MessageBox.
        }
    }
}
