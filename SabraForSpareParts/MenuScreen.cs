using System;

namespace SabraForSpareParts
{
    /// <summary>
    /// كل شاشة (وبالتبعية كل صلاحية) موجودة في القائمة الجانبية ucMenue.
    /// اسم كل قيمة هنا هو نفسه المفروض يتخزن في جدول الصلاحيات بالداتابيز
    /// لو هتستخدم الأوفرلود اللي بياخد قائمة string في ApplyPermissions.
    /// </summary>
    public enum MenuScreen
    {
        Main,                   // الرئيسية
        InventoryList,          // قائمة المخزون
        AddPart,                // إضافة قطعة
        InventoryAlerts,        // تنبيهات المخزون
        CarCompatibility,       // توافق السيارات
        InventoryTransaction,   // سجل الحركة
        NewInvoice,             // فاتورة جديدة
        InvoicesList,           // قائمة الفواتير
        Returns,                // المرتجعات
        NewPurchaseOrder,       // أمر شراء جديد
        PurchaseOrdersList,     // قائمة الأوامر
        ReceiveGoods,           // استلام بضاعة
        Customers,              // العملاء
        CustomerStatement,      // كشف حساب عميل
        Suppliers,              // الموردين
        SupplierStatement,      // كشف حساب مورد
        Treasury,               // الخزانة
        Expenses,               // المصروفات
        Salaries,               // الرواتب
        Advances,               // السلف
        Reports,                // التقارير
        CashFlow,               // Cash Flow
        Employees,              // الموظفين
        Users,                  // المستخدمين
        Settings,               // الإعدادات
        Backup,                 // نسخ احتياطي
        ActivityLog             // سجل الأنشطة
    }

    /// <summary>
    /// بيانات الحدث اللي بيبعته ucMenue لما المستخدم يدوس على أي زرار.
    /// الفورم اللي حاطة الكنترول (frmMain) هي اللي تستقبل الحدث وتقرر
    /// تفتح أنهي شاشة فعليًا.
    /// </summary>
    public class MenuScreenSelectedEventArgs : EventArgs
    {
        public MenuScreen Screen { get; }

        public MenuScreenSelectedEventArgs(MenuScreen screen)
        {
            Screen = screen;
        }
    }
}