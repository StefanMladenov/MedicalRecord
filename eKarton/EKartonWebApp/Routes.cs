namespace EKartonWebApp
{
    public static class Routes
    {
        #region Doctor Controller
        public static string GetDoctors = "Doctor/GetDoctors";
        public static string GetDoctor = "Doctor/GetDoctor/";
        public static string PutDoctor = "Doctor/PutDoctor/1";
        public static string PostDoctor = "Doctor/PostDoctor";
        public static string DeleteDoctor = "Doctor/DeleteDoctor/";
        #endregion

        #region Patient Controller
        public static string GetPatients = "Doctors/GetPatients";
        public static string GetPatient = "Doctors/GetPatient";
        public static string PutPatient = "Doctors/PutPatient";
        public static string PostPatient = "Doctors/PostPatient";
        public static string DeletePatient = "Doctors/DeletePatient/";
        #endregion


        //public static string GetDoctors = "Doctors/GetDoctors";
        //public static string GetDoctors = "Doctors/GetDoctors";
        //public static string GetDoctors = "Doctors/GetDoctors";
        //public static string GetDoctors = "Doctors/GetDoctors";

    }
}
