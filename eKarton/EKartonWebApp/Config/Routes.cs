namespace EKartonWebApp
{
    public static class Routes
    {
        #region API Routes
        public static string APIBaseURI = "https://localhost:5001/api/";

        #region Doctor Controller
        public static string GetDoctors = "Doctor/GetDoctors";
        public static string GetDoctor = "Doctor/GetDoctor/";
        public static string PutDoctor = "Doctor/PutDoctor/";
        public static string PostDoctor = "Doctor/PostDoctor";
        public static string DeleteDoctor = "Doctor/DeleteDoctor/";
        #endregion

        #region Patient Controller
        public static string GetPatients = "Patient/GetPatients";
        public static string GetPatient = "Patient/GetPatient";
        public static string PutPatient = "Patient/PutPatient/";
        public static string PostPatient = "Patient/PostPatient";
        public static string DeletePatient = "Patient/DeletePatient/";
        #endregion

        #region AllergyController
        public static string GetAllergies = "Allergy/GetAllergies";
        public static string GetAllergy = "Allergy/GetAllergy";
        public static string PutAllergy = "Allergy/PutAllergy/";
        public static string PostAllergy = "Allergy/PostAllergy";
        public static string DeleteAllergy = "Allergy/DeleteAllergy/";
        #endregion

        #region AnamnesisController
        public static string GetAnamnesies = "Anamnesis/GetAnamnesies";
        public static string GetAnamnesis = "Anamnesis/GetAnamnesis";
        public static string PutAnamnesis = "Anamnesis/PutPatient/";
        public static string PostAnamnesis = "Anamnesis/PostAnamnesis";
        public static string DeleteAnamnesis = "Anamnesis/DeleteAnamnesis/";
        #endregion

        #region DiseaseController
        public static string GetDiseases = "Disease/GetDiseases";
        public static string GetDisease = "Disease/GetDisease";
        public static string PutDisease = "Disease/PutDisease/";
        public static string PostDisease = "Disease/PostDisease";
        public static string DeleteDisease = "Disease/DeleteDisease/";
        #endregion

        #region MedicalRecordController
        public static string GetMedicalRecords = "MedicalRecord/GetMedicalRecords";
        public static string GetMedicalRecord = "MedicalRecord/GetMedicalRecord";
        public static string PutMedicalRecord = "MedicalRecord/PutMedicalRecord/";
        public static string PostMedicalRecord = "MedicalRecord/PostMedicalRecord";
        public static string DeleteMedicalRecord = "MedicalRecord/DeleteMedicalRecord/";
        #endregion

        #region MedicineController
        public static string GetMedicines = "Medicine/GetMedicines";
        public static string GetMedicine = "Medicine/GetMedicine";
        public static string PutMedicine = "Medicine/PutMedicine/";
        public static string PostMedicine = "Medicine/PostMedicine";
        public static string DeleteMedicine = "Medicine/DeleteMedicine/";
        #endregion

        #region VaccinationStatusController
        public static string GetVaccinationStatuses = "VaccinationStatus/GetVaccinationStatuses";
        public static string GetVaccinationStatus = "VaccinationStatus/GetVaccinationStatus";
        public static string PutVaccinationStatus = "VaccinationStatus/PutVaccinationStatus/";
        public static string PostVaccinationStatus = "VaccinationStatus/PostVaccinationStatus";
        public static string DeleteVaccinationStatus = "VaccinationStatus/DeleteVaccinationStatus/";
        #endregion

        #region VaccineController
        public static string GetVaccines = "Vaccine/GetVaccines";
        public static string GetVaccine = "Vaccine/GetVaccine";
        public static string PutVaccine = "Vaccine/PutVaccine/";
        public static string PostVaccine = "Vaccine/PostVaccine";
        public static string DeleteVaccine = "Vaccine/DeleteVaccine/";
        #endregion

        #region
        public static string GetVisits = "visit/GetVisits";
        public static string GetVisit = "Visit/GetVisit";
        public static string PutVisit = "Visit/PutVisit/";
        public static string PostVisit = "Visit/PostVisit";
        public static string DeleteVisit = "Visit/DeleteVisit/";
        #endregion
        #endregion
    }
}
