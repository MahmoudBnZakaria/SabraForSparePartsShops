using System;

namespace SabraForSpareParts
{

    public static class MenuScreenExtensions
        {
            public static string GetDisplayName(this MenuScreen screen)
            {
                return screen switch
                {
                    MenuScreen.Main => "الرئيسية",
                    MenuScreen.InventoryList => "قائمة المخزون",
                    MenuScreen.AddPart => "إضافة قطعة",
                    MenuScreen.InventoryAlerts => "تنبيهات المخزون",
                    MenuScreen.CarCompatibility => "توافق السيارات",
                    MenuScreen.InventoryTransaction => "سجل الحركة",
                    MenuScreen.NewInvoice => "فاتورة جديدة",
                    MenuScreen.InvoicesList => "قائمة الفواتير",
                    MenuScreen.Returns => "المرتجعات",
                    MenuScreen.NewPurchaseOrder => "أمر شراء جديد",
                    MenuScreen.PurchaseOrdersList => "قائمة الأوامر",
                    MenuScreen.ReceiveGoods => "استلام بضاعة",
                    MenuScreen.Customers => "العملاء",
                    MenuScreen.CustomerStatement => "كشف حساب عميل",
                    MenuScreen.Suppliers => "الموردين",
                    MenuScreen.SupplierStatement => "كشف حساب مورد",
                    MenuScreen.Treasury => "الخزانة",
                    MenuScreen.Expenses => "المصروفات",
                    MenuScreen.Salaries => "الرواتب",
                    MenuScreen.Advances => "السلف",
                    MenuScreen.Reports => "التقارير",
                    MenuScreen.CashFlow => "التدفق النقدي (Cash Flow)",
                    MenuScreen.Employees => "الموظفين",
                    MenuScreen.Users => "المستخدمين",
                    MenuScreen.Settings => "الإعدادات",
                    MenuScreen.Backup => "النسخ الاحتياطي",
                    MenuScreen.ActivityLog => "سجل الأنشطة",
                    _ => "غير محدد"
                };
            }
        }



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