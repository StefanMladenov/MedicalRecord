using eKarton.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class MedicalRecordService : IService<MedicalRecord>
    {
        private readonly MedicalRecordContext _context;

        public MedicalRecordService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<MedicalRecord> GetAll()
        {
            return _context.MedicalRecords
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Include(x => x.Allergy).ThenInclude(y => y.Medicines)
                .Include(x => x.VaccinationStatus).ThenInclude(y => y.Vaccines)
                .Include(x => x.Snapshots)
                .Include(x => x.Analysis)
                .Include(x => x.Instructions)
                .Include(x => x.Anamnesis).ThenInclude(y => y.Diseases).ToList();
        }

        public MedicalRecord GetByGuid(string guid)
        {
            return _context.MedicalRecords
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Include(x => x.Allergy).ThenInclude(y => y.Medicines)
                .Include(x => x.VaccinationStatus).ThenInclude(y => y.Vaccines)
                .Include(x => x.Snapshots)
                .Include(x => x.Analysis)
                .Include(x => x.Instructions)
                .Include(x => x.Anamnesis).ThenInclude(y => y.Diseases)
                .SingleOrDefault(x => x.Guid.Equals(guid));
        }

        public void Create(MedicalRecord obj)
        {
            _context.MedicalRecords.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, MedicalRecord obj, MedicalRecord objToUpdate)
        {
            #region Allergy
            if (objToUpdate.Allergy != null)
            {
                foreach (Medicine med in objToUpdate.Allergy.Medicines)
                {
                    _context.Medicines.Remove(med);
                } 
            }
            else
            {
                objToUpdate.Allergy = new Allergy();
                _context.Allergies.Add(objToUpdate.Allergy);
            }
            objToUpdate.Allergy.Medicines = new List<Medicine>();
            if (obj.Allergy.Medicines != null && obj.Allergy.Medicines.Count != 0)
            {
                foreach (Medicine med in obj.Allergy.Medicines)
                {
                    _context.Medicines.Add(med);
                    objToUpdate.Allergy.Medicines.Add(med);
                }
            }
            objToUpdate.Allergy.Food = new List<string>();
            objToUpdate.Allergy.Other = new List<string>();
            foreach (string s in obj.Allergy.Food)
            {
                objToUpdate.Allergy.Food.Add(s);
            }
            foreach (string s in obj.Allergy.Other)
            {
                objToUpdate.Allergy.Other.Add(s);
            }

            #endregion

            #region Anamnesis
            if (objToUpdate.Anamnesis != null)
            {
                foreach (Disease dis in objToUpdate.Anamnesis.Diseases)
                {
                    _context.Diseases.Remove(dis);
                }
            }
            else
            {
                objToUpdate.Anamnesis = new Anamnesis();
                _context.Anamnesis.Add(objToUpdate.Anamnesis);
            }
            objToUpdate.Anamnesis.Diseases = new List<Disease>();
            if (obj.Anamnesis.Diseases != null && obj.Anamnesis.Diseases.Count != 0)
            {
                foreach (Disease dis in obj.Anamnesis.Diseases)
                {
                    _context.Diseases.Add(dis);
                    objToUpdate.Anamnesis.Diseases.Add(dis);
                }
            }
            objToUpdate.Anamnesis.SocioEpidemiologicalStatus = obj.Anamnesis.SocioEpidemiologicalStatus;
            #endregion

            #region Analysis
            foreach (Analysis an in objToUpdate.Analysis)
            {
                _context.Analysis.Remove(an);
            }
            objToUpdate.Analysis = new List<Analysis>();
            if (obj.Analysis != null)
            {
                foreach (Analysis an in obj.Analysis)
                {
                    if (_context.Analysis.Find(an.Guid) != null)
                    {
                        _context.Analysis.Update(an);
                    }
                    else
                    {
                        _context.Analysis.Add(an);
                    }
                    objToUpdate.Analysis.Add(an);
                }
            }
            #endregion

            #region Instructions
            foreach (Instruction instr in objToUpdate.Instructions)
            {
                _context.Instructions.Remove(instr);
            }
            objToUpdate.Instructions = new List<Instruction>();
            if (obj.Instructions != null)
            {
                foreach (Instruction instr in obj.Instructions)
                {
                    if (_context.Instructions.Find(instr.Guid) != null)
                    {
                        _context.Instructions.Update(instr);
                    }
                    else
                    {
                        _context.Instructions.Add(instr);
                    }
                    objToUpdate.Instructions.Add(instr);
                }
            }
            #endregion

            #region Snapshots
            foreach (Snapshot ss in objToUpdate.Snapshots)
            {
                _context.Snapshots.Remove(ss);
            }
            objToUpdate.Snapshots = new List<Snapshot>();
            if (obj.Snapshots != null)
            {
                foreach (Snapshot ss in obj.Snapshots)
                {
                    if (_context.Snapshots.Find(ss.Guid) != null)
                    {
                        _context.Snapshots.Update(ss);
                    }
                    else
                    {
                        _context.Snapshots.Add(ss);
                    }
                    objToUpdate.Snapshots.Add(ss);
                } 
            }
            #endregion

            #region VaccinationStatus
            if (objToUpdate.VaccinationStatus != null)
            {
                foreach (Vaccine vacc in objToUpdate.VaccinationStatus.Vaccines)
                {
                    _context.Vaccines.Remove(vacc);
                }
            }
            else
            {
                objToUpdate.VaccinationStatus = new VaccinationStatus();
                _context.VaccinationStatuses.Add(objToUpdate.VaccinationStatus);
            }
            objToUpdate.VaccinationStatus.Vaccines = new List<Vaccine>();
            if (obj.VaccinationStatus.Vaccines != null && obj.VaccinationStatus.Vaccines.Count != 0)
            {
                foreach (Vaccine vacc in obj.VaccinationStatus.Vaccines)
                {
                    _context.Vaccines.Add(vacc);
                    objToUpdate.VaccinationStatus.Vaccines.Add(vacc);
                }
            }
            _context.VaccinationStatuses.Update(objToUpdate.VaccinationStatus);

            #endregion

            #region VisitGuids
            objToUpdate.VisitGuids = new List<string>();
            foreach (string s in obj.VisitGuids)
            {
                objToUpdate.VisitGuids.Add(s);
            }
            #endregion

            #region Doctor
            if (obj.Doctor != null)
            {
                if (objToUpdate.Doctor != null)
                {
                    objToUpdate.Doctor.FirstName = obj.Doctor.FirstName;
                    objToUpdate.Doctor.LastName = obj.Doctor.LastName;
                    objToUpdate.Doctor.EMail = obj.Doctor.EMail;
                    objToUpdate.Doctor.Specialization = obj.Doctor.Specialization;
                    objToUpdate.Doctor.DateOfBirth = obj.Doctor.DateOfBirth;
                    objToUpdate.Doctor.UniqueCitizensIdentityNumber = obj.Doctor.UniqueCitizensIdentityNumber;
                    _context.Doctors.Update(objToUpdate.Doctor);
                }
                else
                {
                    _context.Doctors.Add(obj.Doctor);
                    objToUpdate.Doctor = obj.Doctor;
                }
            }
            #endregion

            #region Patient
            if (obj.Patient != null)
            {
                objToUpdate.Patient.DateOfBirth = obj.Patient.DateOfBirth;
                objToUpdate.Patient.EMail = obj.Patient.EMail;
                objToUpdate.Patient.FathersName = obj.Patient.FathersName;
                objToUpdate.Patient.FirstName = obj.Patient.FirstName;
                objToUpdate.Patient.Gender = obj.Patient.Gender;
                objToUpdate.Patient.HealthInsuranceNumber = obj.Patient.HealthInsuranceNumber;
                objToUpdate.Patient.LastName = obj.Patient.LastName;
                objToUpdate.Patient.MothersName = obj.Patient.MothersName;
                objToUpdate.Patient.TypeOfInsurance = obj.Patient.TypeOfInsurance;
                objToUpdate.Patient.UniqueCitizensIdentityNumber = obj.Patient.UniqueCitizensIdentityNumber;
                _context.Patients.Update(objToUpdate.Patient);
            }
            #endregion

            _context.MedicalRecords.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var medicalRecord = GetByGuid(guid);
            if (medicalRecord != null)
            {
                #region Allergy
                if (medicalRecord.Allergy != null)
                {
                    if (medicalRecord.Allergy.Medicines != null && medicalRecord.Allergy.Medicines.Count != 0)
                    {
                        foreach (Medicine med in medicalRecord.Allergy.Medicines)
                        {
                            _context.Medicines.Remove(med);
                        }
                    }
                    _context.Allergies.Remove(medicalRecord.Allergy);
                }
                #endregion

                #region Anamnesis
                if (medicalRecord.Anamnesis != null)
                {
                    if (medicalRecord.Anamnesis.Diseases != null && medicalRecord.Anamnesis.Diseases.Count != 0)
                    {
                        foreach (Disease dis in medicalRecord.Anamnesis.Diseases)
                        {
                            _context.Diseases.Remove(dis);
                        }
                    }
                    _context.Anamnesis.Remove(medicalRecord.Anamnesis);
                }
                #endregion

                #region Analysis
                if (medicalRecord.Analysis != null && medicalRecord.Analysis.Count != 0)
                {
                    foreach (Analysis an in medicalRecord.Analysis)
                    {
                        _context.Analysis.Remove(an);
                    }
                }
                #endregion

                #region Instructions
                if (medicalRecord.Instructions != null && medicalRecord.Instructions.Count != 0)
                {
                    foreach (Instruction instr in medicalRecord.Instructions)
                    {
                        _context.Instructions.Remove(instr);
                    }
                }
                #endregion

                #region Snapshots
                if (medicalRecord.Snapshots != null && medicalRecord.Snapshots.Count != 0)
                {
                    foreach (Snapshot ss in medicalRecord.Snapshots)
                    {
                        _context.Snapshots.Remove(ss);
                    }
                }
                #endregion

                #region Vaccination Status
                if (medicalRecord.VaccinationStatus != null)
                {
                    if(medicalRecord.VaccinationStatus.Vaccines != null && medicalRecord.VaccinationStatus.Vaccines.Count != 0)
                    {
                        foreach (Vaccine vacc in medicalRecord.VaccinationStatus.Vaccines)
                        {
                            _context.Vaccines.Remove(vacc);
                        }
                    }
                    _context.VaccinationStatuses.Remove(medicalRecord.VaccinationStatus);
                }
                #endregion

                if (medicalRecord.Doctor != null)
                {
                    _context.Doctors.Remove(medicalRecord.Doctor);
                }
                _context.Patients.Remove(medicalRecord.Patient);
                _context.MedicalRecords.Remove(medicalRecord);
                _context.SaveChanges();
            }    
        }
    }
}

