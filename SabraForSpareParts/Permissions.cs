using System;

namespace SabraForSpareParts
{


        [Flags]
        public enum Permissions 
        {
            // لا توجد أي صلاحيات
            None = 0,

            // Main & Inventory
            Main = 1 << 0,
            InventoryList = 1 << 1,
            AddPart = 1 << 2,
            InventoryAlerts = 1 << 3,
            CarCompatibility = 1 << 4,
            InventoryTransaction = 1 << 5,

            // Sales
            NewInvoice = 1 << 6,
            InvoicesList = 1 << 7,
            Returns = 1 << 8,

            // Purchases
            NewPurchaseOrder = 1 << 9,
            PurchaseOrdersList = 1 << 10,
            ReceiveGoods = 1 << 11,

            // Customers
            Customers = 1 << 12,
            CustomerStatement = 1 << 13,

            // Suppliers
            Suppliers = 1 << 14,
            SupplierStatement = 1 << 15,

            // Finance
            Treasury = 1 << 16,
            Expenses = 1 << 17,
            Salaries = 1 << 18,
            Advances = 1 << 19,
            Reports = 1 << 20,
            CashFlow = 1 << 21,

            // Administration
            Employees = 1 << 22,
            Users = 1 << 23,
            Settings = 1 << 24,
            Backup = 1 << 25,
            ActivityLog = 1 << 26
        }
}
