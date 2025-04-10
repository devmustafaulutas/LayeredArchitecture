using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Queries;

namespace LayeredArchitecture.Application.Validators.PlannedCourse;

public class CreatePlannedCourseValidator(ILayeredArchitectureDbContext dbContext)
{
    public bool IsTimeAvaliable(CreatePlannedCourseDto plannedCourseDto)
    {
        if (plannedCourseDto == null)
        {
            Console.WriteLine("❌ plannedCourseDto nesnesi null! Hata oluştu.");
            return false;
        }

        if (plannedCourseDto.startTime == null)
        {
            Console.WriteLine("❌ plannedCourseDto içindeki startTime null!");
            return false;
        }
        if (plannedCourseDto.day == null)
        {
            Console.WriteLine("❌ plannedCourseDto içindeki day null!");
            return false;
        }

        var time = plannedCourseDto.startTime;
        var day = plannedCourseDto.day;

        Console.WriteLine("🔍 Kurs zaman kontrolü başlıyor...");

        // Aynı gün ve o gün için planlanmış tüm kursları alıyoruz
        var plannedCourseSame = dbContext.PlannedCourses
            .Where(plannedCourse => plannedCourse.DayOfWeek == day)
            .ToList();

        if (plannedCourseSame.Count == 0)
        {
            Console.WriteLine("✅ Bu gün için planlanmış kurs bulunmamaktadır.");
        }

        foreach (var course in plannedCourseSame)
        {
            var existingCourseStartTime = course.StartTime;
            var existingCourseDuration = course.Course?.Time; // Süreyi buradan alıyoruz
            var existingCourseEndtime = existingCourseStartTime + existingCourseDuration;

            // Konsola detaylı loglama ekleyelim
            Console.WriteLine($"🕒 Mevcut Kurs: Başlangıç = {existingCourseStartTime}, Bitiş = {existingCourseEndtime}, Süre = {existingCourseDuration}");
            Console.WriteLine($"⏱️ Kontrol Edilen Zaman: {time}");

            // Kurs zaman çakışmalarını kontrol edelim
            // 1. Eğer yeni kursun saati mevcut kursun başlangıç ve bitiş saati arasında ise çakışma var
            if (time >= existingCourseStartTime && time < existingCourseEndtime)
            {
                Console.WriteLine("❌ Zaman çakışması tespit edildi. Kurs planı uygun değil.");
                return false;
            }
            // 2. Eğer mevcut kursun bitiş saati, yeni kursun başlangıç saatinden önce ise çakışma yok
            else if (existingCourseEndtime <= time)
            {
                Console.WriteLine("✅ Zaman çakışması yok. Kurs eklenebilir.");
            }
            else
            {
                Console.WriteLine("❌ Zaman çakışması tespit edildi. Kurs planı uygun değil.");
                return false;
            }
        }

        Console.WriteLine("✅ Tüm kontroller başarıyla geçildi, zaman uygun.");
        return true;
    }

}