using EFBaigiamasisStudentai.Database;
using EFBaigiamasisStudentai.Database.Interfaces;
using EFBaigiamasisStudentai.Database.Repositories;
using EFBaigiamasisStudentai.Interfaces;
using EFBaigiamasisStudentai.Services;

namespace EFBaigiamasisStudentai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentaiContext context = new StudentaiContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            IDepartmentRepository departmentRepository = new DepartmentRepository(context);
            ILectureRepository lectureRepository = new LectureRepository(context);
            IStudentRepository studentRepository = new StudentRepository(context);
            IValidationService validationService = new ValidationService(context,departmentRepository, lectureRepository, studentRepository);
            IDepartmentService departmentService = new DepartmentService(departmentRepository, validationService);
            ILectureService lectureService = new LectureService(lectureRepository, validationService);
            IStudentService studentService = new StudentService(studentRepository, validationService);

            StudentaiProject studentaiProject = new StudentaiProject(departmentService, lectureService, studentService, validationService);
            studentaiProject.Run();

        }
    }
}
/*
EmployeeManagementContext context = new EmployeeManagementContext();
IDarbuotojasRepository darbuotojasRepository = new DarbuotojasRepository(context);
IProjektasRepository projektasRepository = new ProjektasRepository(context);
IDarbuotojasService darbuotojasService = new DarbuotojasService(darbuotojasRepository);
IProjektasService projektasService = new ProjektasService(projektasRepository);
DarbuotojuValdymas darbuotojuValdymas = new DarbuotojuValdymas(darbuotojasService, projektasService);
darbuotojuValdymas.Run();
//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();
*/