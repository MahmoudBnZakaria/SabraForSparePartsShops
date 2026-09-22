using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabra.LogicLayer { 

        /// <summary>
        /// أسماء الجداول المرجعية كما هي في الداتابيز بالظبط.
        /// لو غيّرت أي اسم هنا لازم تغيّره في سكريبت الـ Seed كمان.
        /// </summary>
        public static class clsSystemNames
        {
            // Transaction_Types
            public const string TxIn = "وارد";
            public const string TxOut = "صادر";
            public const string TxInvoiceCollection = "تحصيل فاتورة";
            public const string TxSupplierPayment = "سداد مورد";
            public const string TxExpense = "مصروف";
            public const string TxExpenseReversal = "عكس مصروف";
            public const string TxPayroll = "صرف مرتبات";
            public const string TxAdvance = "صرف سلفة";
            public const string TxManualDeposit = "إيداع يدوي";
            public const string TxManualWithdraw = "سحب يدوي";

            // Payment_Status
            public const string PaidFull = "مدفوع بالكامل";
            public const string PaidPartial = "مدفوع جزئياً";
            public const string PaidDeferred = "آجل";

            // Advance_Status
            public const string AdvPending = "قيد الانتظار";
            public const string AdvApproved = "موافق عليها";
            public const string AdvRejected = "مرفوضة";
            public const string AdvSettled = "مسددة";
            public const string AdvCancelled = "ملغاة";

            // Purchase_Order_Status
            public const string POOpen = "مفتوح";
            public const string POPartiallyReceived = "مستلم جزئياً";
            public const string POFullyReceived = "مستلم بالكامل";
            public const string POCancelled = "ملغي";

            // Movement_Types
            public const string MovSale = "بيع";
            public const string MovPurchase = "شراء";
            public const string MovSaleReturn = "مرتجع بيع";
            public const string MovStockCount = "تسوية جرد";
            public const string MovDamaged = "تالف";

            // Item_Status (المرتجعات)
            public const string ItemBackToStock = "سليمة ترجع للمخزون";
            public const string ItemDamaged = "تالفة";
            public const string ItemUnderReview = "قيد الفحص";

            // Payment_Methods
            public const string MethodCash = "نقدي";
            public const string MethodWallet = "محفظة إلكترونية";
        }

        [Flags]
        public enum Permission
        {
            None = 0,
            Sales = 1,
            Inventory = 2,
            Purchases = 4,
            Treasury = 8,
            Payroll = 16,
            Reports = 32,
            UsersAdmin = 64,
            VoidAndReverse = 128
        }    
}
