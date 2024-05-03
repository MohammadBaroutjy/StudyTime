using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudyTime.Entites;
using StudyTime.Models;
using System;
using System.Security.Cryptography.Xml;

namespace StudyTime.Services
{
    public class HallService
    {
        private readonly IHostEnvironment environment;

        private readonly List<Hall> _services = new();
        public HallService(IHostEnvironment environment)
        {
            this.environment = environment;
            LoadList();
        }
        public void LoadList()
        {
            string pathFolder = Path.Combine(environment.ContentRootPath, $"wwwroot", "files", "Table.json").ToLower();
            string json = File.ReadAllText(pathFolder);
            var people = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Hall>>(json);
            _services.AddRange(people!);
        }


        public IEnumerable<HallModel> GetHallsBySpecialty(string specialty, string year)
        {
            var Hall = new List<HallModel>();
            foreach (var item in _services)
            {
                if (item.Specialty == specialty + year && item.HallName != 0)
                {
                    Hall.Add(new HallModel()
                    {
                        Id = item.Id,
                        HallName = item.HallName,
                        HallTime = item.HallTime,
                        Day = item.Day.ToDayArabic(),
                        Specialty = item.Specialty
                    });
                }
            }
            return Hall;
        }

        public IEnumerable<string> GetHallIsEmptyByDayAndTime(string day, int HallTime)
        {
            var HallList = new List<string> { "1", "2", "3", "0", "0", "0", "0", "0", "0", "10", "11", "12", "13", "0", "15", "16", "17", "18", "0", "20", "21", "22", "23", "24", "25", "26", "0", "0", "0", "0", "0", "0", "33" };
            var HallsEmpty = new List<string>();
            foreach (var item in _services)
            {
                if (item.Day == day && item.HallTime == HallTime && item.HallName != 0)
                {
                    HallList[item.HallName - 1] = "0";
                }
            }
            foreach (var item in HallList)
            {
                if (item is not "0")
                    HallsEmpty.Add(item);
            }
            return HallsEmpty;
        }

    }

    public static class Convert
    {
        public static string ToDayArabic(this string day)
        {
            switch (day)
            {
                case "Sunday":
                    return "الأحد";
                case "Monday":
                    return "الاثنين";
                case "Tuesday":
                    return "الثلاثاء";
                case "Wednesday":
                    return "الأربعاء";
                case "Thursday":
                    return "الخميس";
                default:
                    return day;

            }
        }

    }
}
