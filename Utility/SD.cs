namespace LaptopStore.Utility
{
    public class SD
    {
        public const string Proc_CoverType_Create = "usp_CreateCoverType";
        public const string Proc_CoverType_Get = "usp_GetCoverType";
        public const string Proc_CoverType_GetAll = "usp_GetAllCoverType";
        public const string Proc_CoverType_Update = "usp_UpdateCoverType";
        public const string Proc_CoverType_Delete = "usp_DeleteCoverType";

        public const string Role_Indi = "Individual Customer";
        public const string Role_Company = "Company Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        public const string ssShoppingCart = "Shopping Cart Session";
        
        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusRefunded = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusPaymentDelay = "ApproveForDelayPayment";
        public const string PaymentStatusRejected = "Rejected";



    }
}