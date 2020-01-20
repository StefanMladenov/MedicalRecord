using System;

public class Allergy
{
    public int Id { get; set; }

    public List<string> Food { get; set; }

    public ICollection<Medicine> Medicines { get; set; }

    public List<string> Other { get; set; }
}

public class Anamnesis
{
    public int Id { get; set; }

    public ICollection<Disease> Diseases { get; set; }

    public string SocioEpidemiologicalStatus { get; set; }
}

public class Disease
{
    public int Id { get; set; }

    public string DiseaseCode { get; set; }

    public string DiseaseName { get; set; }

    public string Therapy { get; set; }

    public DiseaseDiscriminator DiseaseDiscriminator { get; set; }
}


public class Image
{
    public int Id { get; set; }

    public string ImagePath { get; set; }

    public DateTime Date { get; set; }

    public ImageType ImageType { get; set; }
}

public class Instruction : Image
{
    public Institute Institute { get; set; }
    public Doctor DoctorFrom { get; set; }
    public Doctor DoctorTo { get; set; }
}

public class Snapshot : Image
{
    public string BodyPart { get; set; }

    public SnapshotType SnapshotType { get; set; }
}

public class Institute
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Doctor> Doctors { get; set; }
}

public class MedicalRecord
{
    public int Id { get; set; }

    public Doctor Doctor { get; set; }

    public Patient Patient { get; set; }

    public MedicalRecord FathersMedicalRecord { get; set; }

    public MedicalRecord MothersMedicalRecord { get; set; }

    public ICollection<VisitEntity> Visits { get; set; }

    public Allergy Allergy { get; set; }

    public VaccinationStatus VaccinationStatus { get; set; }

    public ICollection<Image> Images { get; set; }

    public Anamnesis Anamnesis { get; set; }
}

public class Medicine
{
    public int Id { get; set; }

    public string NameOfMedicine { get; set; }

    public bool Allergic { get; set; }
}

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UniqueCitizensIdentityNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string EMail { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

}

public class Doctor : Person
{
    public string Specialization { get; set; }
    public Institute Institute { get; set; }
    public int FacsimileNumber { get; set; }
}

public class Patient : Person
{
    public string FathersName { get; set; }

    public string MothersName { get; set; }

    // 1 - male , 2 - female
    public int Gender { get; set; }

    public int HealthInsuranceNumber { get; set; }

    // 1 - public, 2 - private
    public int TypeOfInsurance { get; set; }
}

public class VaccinationStatus
{
    public int Id { get; set; }

    public ICollection<Vaccine> VaccineList { get; set; }
}

public class VisitEntity
{
    public int Id { get; set; }

    public DateTime Datum { get; set; }
}

public enum ImageType
{
    Laboratory,
    Spirometry,
    AllergologicalTests
}

public enum SnapshotType
{
    XRay,
    Ultrasound,
    Scanner,
    NuclearMagneticResonance,
    Other
}

public enum DiseaseDiscriminator
{
    Current,
    Moved,
    Family
}
