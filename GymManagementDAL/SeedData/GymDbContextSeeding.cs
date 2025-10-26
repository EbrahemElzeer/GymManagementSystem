using GymManagementDAL.Context;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymManagementDAL.SeedData
{
    public static class GymDbContextSeeding
    {
        public static bool SeedData(GymdbContext context)
        {
            try
            {
                var hasplan = context.Plans.Any();
                var hasCategory = context.categories.Any();

                if (hasplan && hasCategory)

                    return false;

                if (!hasplan)
                {
                    var plans = LoadDataFRomJson<Plan>("Plans.json");
                    if (plans.Count > 0)
                    {
                        context.Plans.AddRange(plans);
                    }
                }

                if (!hasCategory)
                {
                    var categories = LoadDataFRomJson<Category>("Categories.json");
                    if (categories.Count > 0)
                    {
                        context.categories.AddRange(categories);
                    }
                }

                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Seeding Faild");
                return false;
            }
        }
        private static List<T> LoadDataFRomJson<T>(string fileName)
        {
            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\File", fileName);
            if (!File.Exists(FilePath))
                return [];
            var jsonData = File.ReadAllText(FilePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<T>>(jsonData, options) ?? [];
        }


    }
}
